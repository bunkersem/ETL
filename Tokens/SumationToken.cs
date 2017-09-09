using CA.Expressions;
using CA.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Tokens
{
    class SumationToken : BinaryToken
    {
        public override int GetChildCount() => 2;
        public override ExpressionType GetExpressionType() => ExpressionType.Sum;
        public override string GetName() => "Sumation";
        public override int GetPrecedence() => 30;
    }
}
