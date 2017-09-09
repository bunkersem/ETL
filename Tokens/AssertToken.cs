using System;
using System.Collections.Generic;
using System.Text;
using CA.Expressions;

namespace CA.Tokens
{
    class AssertToken : MonoToken
    {
        public override int GetChildCount() => 1;
        public override ExpressionType GetExpressionType() => ExpressionType.Assert;
        public override string GetName() => "Assert";
        public override int GetPrecedence() => 10;
    }
}
