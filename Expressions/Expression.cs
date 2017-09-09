using CA.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Expressions
{
    public abstract class Expression
    {
        private Func<IEnumerable<Expression>, Value> operation;
        private IEnumerable<Expression> children;

        public virtual Value Resolve()
        {
            return operation(children);
        }
        public Expression(IEnumerable<Expression> children, Func<IEnumerable<Expression>, Value> func)
        {
            operation = func;
            this.children = children;
        }
        public virtual IEnumerable<Expression> getChildren() => children;

        public override string ToString()
        {
            return this.GetType().Name;
        }

    }

}
