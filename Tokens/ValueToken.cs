using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Tokens
{
    public abstract class ValueToken : ConstToken
    {
        object value;
        public ValueToken(object value)
        {
            this.value = value;
        }
        public abstract object GetValue();
    }
}
