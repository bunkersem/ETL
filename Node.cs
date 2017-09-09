using System;
using System.Collections.Generic;
using System.Text;

namespace CA
{
    class Node<T>
    {
        public IEnumerable<Node<T>> Children { get; set; }
        public T Value { get; set; }
    }
}
