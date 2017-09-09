using CA.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA
{
    class InvalidExpressionException : Exception
    {
        public InvalidExpressionException() { }
        public InvalidExpressionException(string message): base(message) { }
        public InvalidExpressionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
