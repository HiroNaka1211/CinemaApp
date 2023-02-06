using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_app
{
    public class DoublyNode<T>  //This class is used for the node of dobuly linked list.
    {                           //The node of doubly linked list should have two pointers. Node<T> class already has next pointer which indicate next node.
        private T element;                                 //Therefore, we need to add one more pointer which indicates previous node.
        private DoublyNode<T> previous;
        private DoublyNode<T> next;
        public DoublyNode(T element, DoublyNode<T> previous, DoublyNode<T> next) 
        {
            this.element = element;
            this.previous = previous;
            this.next = next;
        }
        public DoublyNode() {}
        public DoublyNode<T> Previous //This property have the pointer which shows the previous node.
        {
            get { return previous; }
            set { previous = value; }
        }
        public T Element  //This property has the element of node.
        {
            get { return element; }
            set { element = value; }
        }


        public DoublyNode<T> Next //This property have the pointer which shows the next node.
        {
            get { return next; }
            set { next = value; }
        }
    }
}
