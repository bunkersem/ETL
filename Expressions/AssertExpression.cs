using System;
using System.Collections.Generic;
using System.Text;
using CA.Values;

namespace CA.Expressions
{
    class AssertExpression : MonoExpression
    {
        public AssertExpression(IEnumerable<Expression> children, Func<IEnumerable<Expression>, Value> func) : base(children, func)
        {

        }
        public override string ToString()
        {
            return $"ASSERT {{ True }} ";
        }
    }
}
