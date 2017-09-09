using CA.Expressions;
using CA.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Factories
{
    public abstract class TokenFactory
    {
        public abstract Token CreateToken(ExpressionType type);
        public abstract ValueToken CreateValueToken(ExpressionType type, object val);
        public abstract ConstToken CreateSpecialToken(ExpressionType type);
    }
}
