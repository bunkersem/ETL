using CA.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Expressions
{
    abstract class ValueExpression : ConstantExpression
    {
        public ValueExpression(IEnumerable<Expression> children, Func<IEnumerable<Expression>, Value> func) : base(children, func)
        {
        }
    }
}
