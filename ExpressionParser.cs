using System.Collections.Generic;
using CA.Expressions;
using CA.Factories;
using CA.Tokens;

namespace CA
{
    public abstract class ExpressionParser
    {
        public abstract Expression Parse(IEnumerable<Token> postFixTokens, ExpressionFactory expressionFactory);
    }
}