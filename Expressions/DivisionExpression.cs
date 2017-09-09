using CA.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Expressions
{
    public class DivisionExpression : Expression
    {
        public DivisionExpression(IEnumerable<Expression> children, Func<IEnumerable<Expression>, Value> func) : base(children, func)
        {
        }
        public override string ToString()
        {
            return "/";
        }
    }
}
