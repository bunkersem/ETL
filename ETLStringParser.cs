using CA.Expressions;
using CA.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using CA.Factories;

namespace CA
{
    class ETLStringParser : StringParser
    {
        private static readonly List<Tuple<string, ExpressionType>> tokenIdentifiers = new List<Tuple<string, ExpressionType>>
        {
            new Tuple<string, ExpressionType> (@"^;$", ExpressionType.Delimeter),
            new Tuple<string, ExpressionType> (@"^-$", ExpressionType.Subtraction),
            new Tuple<string, ExpressionType> (@"^\+$", ExpressionType.Sum ),
            new Tuple<string, ExpressionType> (@"^/$", ExpressionType.Division ),
            new Tuple<string, ExpressionType> (@"^\*$", ExpressionType.Multiply ),
            new Tuple<string, ExpressionType> (@"^==$", ExpressionType.Equality ),
            new Tuple<string, ExpressionType> (@"^\($", ExpressionType.OpeningParenthese ),
            new Tuple<string, ExpressionType> (@"^\)$", ExpressionType.ClosingParenthese ),
            new Tuple<string, ExpressionType> (@"^[0-9]+$", ExpressionType.IntegerValue ),
            new Tuple<string, ExpressionType> (@"^(True|False)$", ExpressionType.BooleanValue ),
            new Tuple<string, ExpressionType> (@"^Assert$", ExpressionType.Assert )
        };
        protected static readonly Dictionary<ExpressionType, Type> ValueExpTypeToValueType = new Dictionary<ExpressionType, Type>
        {
            { ExpressionType.IntegerValue, typeof(int) },
            { ExpressionType.BooleanValue, typeof(bool) }
        };
        public override IEnumerable<Token> Parse(string ETLString, TokenFactory tokenFactory)
        {
            var strs = SplitString(ETLString);
            List<Token> retTokens = new List<Token>(strs.Count());
            Regex _matcher;
            ExpressionType _type;
            foreach (string str in strs)
            {
                try
                {
                    _type = tokenIdentifiers.First(ti =>
                    {
                        _matcher = new Regex(ti.Item1, RegexOptions.IgnoreCase);
                        return _matcher.IsMatch(str);
                    }).Item2;
                } 
                catch(InvalidOperationException ex)
                {
                    throw new InvalidExpressionException($"Unrecognized Token {str}", ex);
                }
                if (_type.IsOperand())
                    retTokens.Add(tokenFactory.CreateValueToken(_type, Convert.ChangeType(str, ValueExpTypeToValueType[_type])));
                else if (_type.IsOperator())
                    retTokens.Add(tokenFactory.CreateToken(_type));
                else if (_type.IsSpecial())
                    retTokens.Add(tokenFactory.CreateSpecialToken(_type));
                else
                    throw new ArgumentException($"Unrecoginzed Type: {_type.ToString()}");
            }
            return retTokens;
        }

        private IEnumerable<string> SplitString(string ETLString)
        {
            string split1 = @"(?<===)(?=\w)";
            string split2 = @"(?<=\w)(?===)";
            string split3 = @"(?<=[+\-*/;()])\s*";
            string split4 = @"\s*(?=[+\-*/;()])";
            string split5 = @"\s+";

            // Split tokens
            Regex splitter = new Regex($"({String.Join("|", split1, split2, split3, split4, split5)})");
            return splitter.Split(ETLString)
                .Select(s => s.Trim('\r', ' ', '\t'))
                .Where(s => String.IsNullOrEmpty(s) == false);
        }

    }
}
