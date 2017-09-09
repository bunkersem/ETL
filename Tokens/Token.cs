using CA.Expressions;
using CA.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Tokens
{
    public abstract class Token
    {
        public abstract string GetName();
        public abstract int GetPrecedence();
        public abstract ExpressionType GetExpressionType();
        public abstract int GetChildCount();
    }
}
