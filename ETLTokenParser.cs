using CA.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA
{
    class ETLTokenParser : TokenParser
    {
        public override IEnumerable<IEnumerable<Token>> ELTSyntaxToPostfix( IEnumerable<Token> tokenSequence)
        {
            return tokenSequence
                .Split(token => token is DelimeterToken)
                .Where(_tokenSequence => _tokenSequence.Count() != 0) // Filter out empty expressions.
                .Select(_tokenSequence =>
                {
                    List<Token> tokens = _tokenSequence.ToList();
                    Stack<Token> operators = new Stack<Token>();
                    Stack<Token> postFix = new Stack<Token>();

                    Action<Token> processOperator = (o) =>
                    {
                        while (operators.Count > 0 && o.GetPrecedence() <= operators.Peek().GetPrecedence())
                            postFix.Push(operators.Pop());

                        operators.Push(o);
                    };

                    foreach (Token t in tokens)
                    {
                        if (t.IsOperand())
                            postFix.Push(t);
                        else if (t.IsOperator())
                            processOperator(t);
                        else if (t.IsSpecial())
                        {
                            if (t is OpeningParentheseToken)
                                operators.Push(t);
                            else if (t is ClosingParentheseToken)
                            {
                                try
                                {
                                    while (operators.Peek() is OpeningParentheseToken == false)
                                        postFix.Push(operators.Pop());
                                    operators.Pop(); // Pop Opening Parenthese.
                                }
                                catch (InvalidOperationException ex)
                                {
                                    throw new InvalidExpressionException("Parenthese(s) are /is not closed.");
                                }
                            }
                        }
                        else
                            throw new ArgumentException("Unrecognized token of name: " + t.GetName());
                    }

                    // End of expression
                    while (operators.Count > 0)
                        postFix.Push(operators.Pop());
                    if (postFix.Any(t => t is ClosingParentheseToken || t is OpeningParentheseToken))
                        throw new InvalidExpressionException("Parenthese(s) are/is not closed.");

                    return postFix.Reverse();
                })
                .Where(_tokenSequence => _tokenSequence.Count() != 0); // Filter out expressions that evaluated to an empty expression.
        }
    }
}
