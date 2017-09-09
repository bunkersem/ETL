using CA.Expressions;
using CA.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Tokens
{
    class IntegerToken : ValueToken
    {
        public override int GetChildCount() => 0;
        public override ExpressionType GetExpressionType() => ExpressionType.IntegerValue;
        public override string GetName() => "Integer";
        public override int GetPrecedence() => 95;

        private IntegerValue value = 0;

        public IntegerToken(IntegerValue value) : base(value)
        {
            this.value = value;
        }

        public override object GetValue()
        {
            return value;
        }
    }
}
