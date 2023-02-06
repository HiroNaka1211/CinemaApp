using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_app
{
    public class Node<T>  //This class will be used for stack.
    {                       // A node has to have one value and two pointer (previous and next) for doubly linked list.
        private T element;
        private Node<T> next;
        public Node(T element, Node<T> next)
        {
            this.element = element;
            this.next = next;
        }

        public Node()
        { }

        public T Element  //This property has the element of node.
        {
            get { return element; }
            set { element = value; }
        }


        public Node<T> Next //This property have the pointer which shows the next node.
        {
            get { return next; }
            set { next = value; }
        }

        
    }
}
