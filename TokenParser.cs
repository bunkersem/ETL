using System.Collections.Generic;
using CA.Tokens;

namespace CA
{
    public abstract class TokenParser
    {
        public abstract IEnumerable<IEnumerable<Token>> ELTSyntaxToPostfix(IEnumerable<Token> tokenSequence);
    }
}