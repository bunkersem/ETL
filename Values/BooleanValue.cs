using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Values
{
    public class BooleanValue : Value
    {
        private bool value;
        public BooleanValue(bool value) : base(value)
        {
            this.value = value;
        }
        public static implicit operator BooleanValue(bool val)
        {
            return new BooleanValue(val);
        }
        public static IntegerValue operator +(BooleanValue first, BooleanValue second)
        {
            throw new InvalidOperationException("Cannot add two boolean values.");
        }

        public static BooleanValue operator -(BooleanValue first, BooleanValue second)
        {
            throw new InvalidOperationException("Cannot subtract two boolean values.");
        }
        public static BooleanValue operator *(BooleanValue first, BooleanValue second)
        {
            throw new InvalidOperationException("Cannot multiply two boolean values.");
        }
        public static BooleanValue operator /(BooleanValue first, BooleanValue second)
        {
            throw new InvalidOperationException("Cannot divide two boolean values.");
        }
        public override string ToString()
        {
            return value.ToString();
        }

        public override object GetValue() => value;
    }
}
