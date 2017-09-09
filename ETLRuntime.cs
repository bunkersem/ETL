using CA.Expressions;
using CA.Factories;
using CA.Tokens;
using CA.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CA
{
    /// <summary>
    /// ETL Runtime
    /// </summary>
    public class ETLRuntime
    {
        static void DebugPrint(Expression exp, StringBuilder sb)
        {
            PrintExpTree(exp , sb);
        }
        static void PrintExpTree(Expression exp, StringBuilder sb, bool[] scopes = null)
        {
            Console.OutputEncoding = Encoding.UTF8;
            if (scopes == null) scopes = new bool[1] { false };

            const char lineHorizontal = '\u2501';
            const char lineCrossed = '\u2523';
            const char lineCurved = '\u2517';
            const char lineChildren = '\u2533';
            const char lineVertical = '\u2503';

            for (int i = 0; i < scopes.Length - 1; i++)
            {
                if (scopes[i])
                    sb.Append(lineVertical);
                else
                    sb.Append(' ');
            }
            if (scopes.Last() == false)
                sb.Append(lineCurved);
            else
                sb.Append(lineCrossed);
            if (exp.getChildren().Count() > 0)
                sb.Append(lineChildren);
            else
                sb.Append(lineHorizontal);
            sb.Append(' ');
            sb.AppendLine(exp.ToString());

            int counter = 0;
            foreach (var item in exp.getChildren())
            {
                counter++;
                PrintExpTree(item, sb, scopes.Append(exp.getChildren().Count() != counter).ToArray());
            }
        }

        public string Run(string str, bool debug = false)
        {
            if (Environment.GetEnvironmentVariable("DEBUG") != null) // Set debug mode from environment variable.
                bool.TryParse(Environment.GetEnvironmentVariable("DEBUG"), out debug);
            

            TokenFactory tf = new ETLTokenFactory();
            StringParser sp = new ETLStringParser();
            ETLTokenParser tp = new ETLTokenParser();
            ETLExpressionParser ep = new ETLExpressionParser();
            ExpressionFactory ef = new ETLExpressionFactory();

            
            StringBuilder sb = new StringBuilder();
            IEnumerable<IEnumerable<Token>> tokensSequences;
            IEnumerable<Expression> exps;
            IEnumerable<Value> values;

            Expression _currentProcessingExpression;
            try
            {
                tokensSequences = tp.ELTSyntaxToPostfix(sp.Parse(str, tf));

                exps = tokensSequences.Select(tokens => ep.Parse(tokens, ef));
                values = exps.Select(exp => {
                    _currentProcessingExpression = exp;
                    return exp.Resolve();
                });
                foreach (var val in values)
                    if (val != null && debug)
                        sb.AppendLine(val.ToString());
                if (debug)
                    foreach (var e in exps)
                        DebugPrint(e, sb);
                sb.AppendLine("Script finished succesfully. ");

                }
                catch (Exception ex)
                {
                    if (ex is InvalidExpressionException)
                    {
                        sb.AppendLine("Invalid expression: ");
                        sb.AppendLine(ex.Message);
                        if (debug && ex.InnerException != null)
                        {
                            sb.AppendLine("Inner exception: ");
                            sb.AppendLine(ex.InnerException.Message);
                        }
                    } else if (ex is AssertionFailedException)
                    {
                        sb.AppendLine("Failed assertion: ");
                        sb.AppendLine(ex.Message);
                        if (debug && ex.InnerException != null)
                        {
                            sb.AppendLine("Inner exception: ");
                            sb.AppendLine(ex.InnerException.Message);
                        }
                    } else if (ex is ETLRuntimeException) {
                        sb.AppendLine("Runtime exception: ");
                        sb.AppendLine(ex.Message);
                        if (debug && ex.InnerException != null)
                        {
                            sb.AppendLine("Inner exception: ");
                            sb.AppendLine(ex.InnerException.Message);
                        }
                    }
                    else
                    {
                        // A serious error has occured. This error is so serious that if we are debugging the program, we will throw the error.
                        sb.AppendLine("Sorry the program encountered an error.");
                        sb.AppendLine(ex.Message);
                        if (debug && ex.InnerException != null)
                        {
                            sb.AppendLine("Inner exception: ");
                            sb.AppendLine(ex.InnerException.Message);
                        }
                    }
                    if (debug)
                    {
                        sb.AppendLine("StackTrace: ");
                        sb.AppendLine(ex.StackTrace);
                    }
                }
            return sb.ToString();
        }
    }
}
