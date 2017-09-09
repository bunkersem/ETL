using CA.Expressions;
using CA.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Factories
{
    class ETLTokenFactory : TokenFactory
    {
        public override ConstToken CreateSpecialToken(ExpressionType type)
        {
            switch (type)
            {
                case ExpressionType.Delimeter:
                    return new DelimeterToken();
                case ExpressionType.OpeningParenthese:
                    return new OpeningParentheseToken();
                case ExpressionType.ClosingParenthese:
                    return new ClosingParentheseToken();
                default:
                    throw new ArgumentException("Unknow ExpressionType");
            }
        }

        public override Token CreateToken(ExpressionType type)
        {
            switch (type)
            {
                case ExpressionType.Division:
                    return new DivisionToken();
                case ExpressionType.Subtraction:
                    return new SubtractionToken();
                case ExpressionType.Multiply:
                    return new MultiplicationToken();
                case ExpressionType.Sum:
                    return new SumationToken();
                case ExpressionType.Assert:
                    return new AssertToken();
                case ExpressionType.Equality:
                    return new EqualityToken();
                case ExpressionType.Delimeter:
                    return new DelimeterToken();
                default:
                    throw new ArgumentException("Unknow ExpressionType");
            }
        }
        public override ValueToken CreateValueToken(ExpressionType type, object val)
        {
            switch (type)
            {
                case ExpressionType.IntegerValue:
                    return new IntegerToken((int)val);
                case ExpressionType.BooleanValue:
                    return new BooleanToken((bool)val);
                default:
                    throw new ArgumentException("Unknow ExpressionType");
            }
        }
    }
}
