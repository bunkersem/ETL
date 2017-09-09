using System;
using System.Collections.Generic;
using System.Text;

namespace CA
{
    class AssertionFailedException : Exception
    {
        public AssertionFailedException(string message) : base(message) { }
        public AssertionFailedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
