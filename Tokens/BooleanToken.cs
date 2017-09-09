using CA.Expressions;
using CA.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Tokens
{
    class BooleanToken : ValueToken
    {
        public override int GetChildCount() => 0;
        public override ExpressionType GetExpressionType() => ExpressionType.BooleanValue;
        public override string GetName() => "Boolean";
        public override int GetPrecedence() => 95;

        private BooleanValue value = false;

        public BooleanToken(bool value) : base(value)
        {
            this.value = value;
        }

        public override object GetValue()
        {
            return value;
        }
    }
}
