using CA.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CA.Expressions;
using CA.Values;

namespace CA.Factories
{
    class ETLExpressionFactory : ExpressionFactory
    {
        public override Expression CreateExpression(Token token, IEnumerable<Expression> childExpressions)
        {
            if (token is ConstToken)
            {
                if (token is ValueToken)
                {
                    if (token is IntegerToken)
                    {
                        IntegerValue val = (IntegerValue)(token as IntegerToken).GetValue();
                        return new IntegerExpression(childExpressions, children => val);
                    }
                    else if (token is BooleanToken)
                    {
                        BooleanValue val = (BooleanValue)(token as BooleanToken).GetValue();
                        return new BooleanExpression(childExpressions, children => val);
                    }
                }
            }
            else if (token is MonoToken)
            {
                if (token is AssertToken)
                {
                    return new AssertExpression(childExpressions, children => {
                        Value valToCheck = children.ElementAt(0).Resolve();
                        if (valToCheck is BooleanValue == false) // Sanity check
                            throw new InvalidExpressionException($"\"ASSERT\" can only operate on boolean values. Not on values of type: {valToCheck.GetType().Name}");
                        if ((bool)(valToCheck as BooleanValue).GetValue() == false) // Sanity check
                            throw new AssertionFailedException("Assertion Failed");
                        return null;
                    });
                }
            }
            else if (token is BinaryToken)
            {
                if (token is MultiplicationToken)
                {
                    return new MultiplicationExpression(childExpressions, children => children.ElementAt(0).Resolve() * children.ElementAt(1).Resolve());
                }
                else if (token is SumationToken)
                {
                    return new SummationExpression(childExpressions, children => children.ElementAt(0).Resolve() + children.ElementAt(1).Resolve());
                }
                else if (token is DivisionToken)
                {
                    return new DivisionExpression(childExpressions, children => children.ElementAt(0).Resolve() / children.ElementAt(1).Resolve());
                }
                else if (token is SubtractionToken)
                {
                    return new SubtractionExpression(childExpressions, children => children.ElementAt(0).Resolve() - children.ElementAt(1).Resolve());
                }
                else if (token is EqualityToken)
                {
                    return new EqualityExpression(childExpressions, children => new BooleanValue(children.ElementAt(0).Resolve() == children.ElementAt(1).Resolve()));
                }
            }
            // We should have returned an Expression by now
            throw new ArgumentException($"Cannot find Expression Type that matches token of name: {token.GetName()}");
        }
        
    }
}
