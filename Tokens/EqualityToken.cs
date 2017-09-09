using System;
using System.Collections.Generic;
using System.Text;
using CA.Expressions;

namespace CA.Tokens
{
    class EqualityToken : BinaryToken
    {
        public override int GetChildCount() => 2;
        public override ExpressionType GetExpressionType() => ExpressionType.Equality;
        public override string GetName() => "Equality";
        public override int GetPrecedence() => 15;
    }
}
