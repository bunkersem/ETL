using CA.Expressions;
using CA.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Tokens
{
    class MultiplicationToken : BinaryToken
    {
        public override int GetChildCount() => 2;
        public override ExpressionType GetExpressionType() => ExpressionType.Multiply;
        public override string GetName() => "Multiplication";
        public override int GetPrecedence() => 70;

        
    }
}

