using CA.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Expressions
{
    class IntegerExpression : ValueExpression
    {
        public IntegerExpression(IEnumerable<Expression> children, Func<IEnumerable<Expression>, Value> func) : base(children, func)
        {
        }
        public override string ToString()
        {
            return $"INT {{{(IntegerValue)base.Resolve()}}} ";
        }
    }
}
