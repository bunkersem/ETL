using CA.Expressions;
using CA.Factories;
using CA.Tokens;
using CA.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA
{
    class ETLExpressionParser : ExpressionParser
    {
        public override Expression Parse(IEnumerable<Token> postFixTokens, ExpressionFactory expressionFactory)
        {
            Stack<Expression> expTree = new Stack<Expression>();
            List<Expression> children = new List<Expression>(4);
            foreach (Token t in postFixTokens)
            {
                
                for (int i = 0; i < t.GetChildCount(); i++)
                {
                    try
                    {
                        children.Add(expTree.Pop());
                    }
                    catch(InvalidOperationException emptyStackError)
                    {
                        throw new InvalidExpressionException("InvalidExpression TODO", emptyStackError);
                    }
                }
                children.Reverse();
                expTree.Push(expressionFactory.CreateExpression(t, children));
                children = new List<Expression>();
                
            }
            if (expTree.Count != 1)
                throw new InvalidExpressionException("InvalidExpression Or Expressions consists of multiple uncombinable expressions. TODO");
            return expTree.Pop();
        }

        private object IntegerValue(IntegerToken integerToken)
        {
            throw new NotImplementedException();
        }
    }
}
