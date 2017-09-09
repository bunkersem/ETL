using CA.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Expressions
{
    public abstract class ConstantExpression : Expression
    {
        public ConstantExpression(IEnumerable<Expression> children, Func<IEnumerable<Expression>, Value> func) : base(children, func)
        {
        }
    }
}
