using CA.Expressions;
using CA.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Factories
{
    public abstract class ExpressionFactory
    {
        public abstract Expression CreateExpression(Token token, IEnumerable<Expression> children);
    }
}
