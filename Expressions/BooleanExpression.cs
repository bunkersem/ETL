using CA.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Expressions
{
    class BooleanExpression : ValueExpression
    {
        public BooleanExpression(IEnumerable<Expression> children, Func<IEnumerable<Expression>, Value> func) : base(children, func)
        {
        }
        public override string ToString()
        {
            return $"BOOL {{{(BooleanValue)base.Resolve()}}} ";
        }
    }
}
