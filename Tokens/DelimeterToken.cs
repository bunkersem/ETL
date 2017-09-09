using System;
using System.Collections.Generic;
using System.Text;
using CA.Expressions;

namespace CA.Tokens
{
    class DelimeterToken : ConstToken
    {
        public override int GetChildCount() => 0;
        public override ExpressionType GetExpressionType() => ExpressionType.Delimeter;
        public override string GetName() => "Delimeter";
        public override int GetPrecedence() => 4;
    }
}
