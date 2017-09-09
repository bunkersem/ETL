using System;
using System.Collections.Generic;
using System.Text;
using CA.Expressions;

namespace CA.Tokens
{
    class OpeningParentheseToken : ConstToken
    {
        public override int GetChildCount() => 0;
        public override ExpressionType GetExpressionType() => ExpressionType.OpeningParenthese;
        public override string GetName() => "Opening Parenthese";
        public override int GetPrecedence() => 12;
    }
}
