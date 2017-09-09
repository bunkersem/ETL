using System;
using System.Collections.Generic;
using System.Text;

namespace CA
{
    class ETLRuntimeException : Exception
    {
        public ETLRuntimeException(string message) : base(message) { }

        public ETLRuntimeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
