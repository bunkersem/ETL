using CA.Expressions;
using CA.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Tokens
{
    class DivisionToken : BinaryToken
    {
        public override int GetChildCount() => 2;
        public override ExpressionType GetExpressionType() => ExpressionType.Division;
        public override string GetName() => "Division";
        public override int GetPrecedence() => 70;

    }
}