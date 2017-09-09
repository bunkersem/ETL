using System;
using System.Collections.Generic;
using System.Text;
using CA.Expressions;

namespace CA.Tokens
{
    class ClosingParentheseToken : ConstToken
    {
        public override int GetChildCount() => 0;
        public override ExpressionType GetExpressionType() => ExpressionType.ClosingParenthese;
        public override string GetName() => "Closing Parenthese";
        public override int GetPrecedence() => 12;
    }
}
