using CA.Expressions;
using CA.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA
{
    static class Core
    {
        private static readonly ExpressionType[] operators = new[] {ExpressionType.Division, ExpressionType.Equality, ExpressionType.Multiply, ExpressionType.Subtraction, ExpressionType.Sum, ExpressionType.Assert };
        private static readonly ExpressionType[] operands = new[] { ExpressionType.IntegerValue, ExpressionType.BooleanValue };
        private static readonly ExpressionType[] special = new[] { ExpressionType.Delimeter, ExpressionType.OpeningParenthese, ExpressionType.ClosingParenthese };

        //public static void ForEach<T> (this IEnumerable<T> set, Action<T> func) {
        //    foreach (T item in set)
        //    {
        //        func(item);
        //    }
        //}
        //public static T Map<T, U> (this IEnumerable<T> set, Func<T, U> func)
        //{
        //    set.Select(p => )
        //}

        public static bool IsOperand(this ExpressionType expType)
        {
            return operands.Any(x => x == expType);
        }

        public static bool IsOperator(this ExpressionType expType)
        {
            return operators.Any(x => x == expType);
        }

        public static bool IsSpecial(this ExpressionType expType)
        {
            return special.Any(x => x == expType);
        }

        public static bool IsOperand(this Token token)
        {
            return operands.Any(x => x == token.GetExpressionType());
        }

        public static bool IsOperator(this Token token)
        {
            return operators.Any(x => x == token.GetExpressionType());
        }

        public static bool IsSpecial(this Token token)
        {
            return special.Any(x => x == token.GetExpressionType());
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> vals, Func<T, bool> splitter, bool includeSplitter = false)
        {
            List<IEnumerable<T>> retSequences = new List<IEnumerable<T>>(
                vals.Sum(v => splitter(v) ? 1 : 0)); // Estimation of list size.
            int lastSplit = 0;
            for (int i = 0; i < vals.Count(); i++)
            {
                if (splitter(vals.ElementAt(i)))
                {
                    retSequences.Add(vals.Skip(lastSplit).Take((i - lastSplit) + (includeSplitter ? 1 : 0)));
                    lastSplit = i + 1;
                }
            }
            retSequences.Add(vals.Skip(lastSplit));
            if (retSequences.Count > 0)
                return retSequences;
            else
                return new IEnumerable<T>[] { vals };
        }
    }
}
