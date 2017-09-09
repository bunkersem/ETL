using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Values
{
    public class IntegerValue : Value
    {
        private int value;

        public IntegerValue(int value) : base(value)
        {
            this.value = value;
        }
        public static implicit operator IntegerValue(int val)
        {
            return new IntegerValue(val);
        }
        public static IntegerValue operator +(IntegerValue first, IntegerValue second)
        {
            return new IntegerValue(first.value + second.value);
        }

        public static IntegerValue operator -(IntegerValue first, IntegerValue second)
        {
            return new IntegerValue(first.value - second.value);
        }
        public static IntegerValue operator *(IntegerValue first, IntegerValue second)
        {
            return new IntegerValue(first.value * second.value);
        }
        public static IntegerValue operator /(IntegerValue first, IntegerValue second)
        {
            return new IntegerValue(first.value / second.value);
        }
        public override string ToString()
        {
            return value.ToString();
        }
        public override object GetValue() => value;
    }
}
