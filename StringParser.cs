using CA.Expressions;
using CA.Factories;
using CA.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CA
{
    abstract class StringParser
    {
        public abstract IEnumerable<Token> Parse(string ETLString, TokenFactory tokenFactory);
    }
}
