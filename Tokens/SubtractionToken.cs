using CA.Expressions;
using CA.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Tokens
{
    class SubtractionToken : BinaryToken
    {
        public override int GetChildCount() => 2;
        public override ExpressionType GetExpressionType() => ExpressionType.Subtraction;
        public override string GetName() => "Subtraction";
        public override int GetPrecedence() => 30;

    }
}

