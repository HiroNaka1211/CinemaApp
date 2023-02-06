using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Cinema_app
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private DoublyNode<T> pointernode;   //pointer node does not need to have any values. Because this is just used instead of head pointer and tail pointer. 
                                             //Therefore, this can be used to show the start and endelements. This is also useful to stop of loop.
        public DoublyLinkedList()
        {
            this.pointernode = new DoublyNode<T>(default, null, null);
            pointernode.Previous = this.pointernode;          // When the List created, there is no node. Therefore, when pointernode is created, the previous and next popinter indicate itself. 
            pointernode.Next = this.pointernode;              // Then first node except pointernode is created, previous pointer and next pointer of pointernode will indicate new node.
        }                                                      // As I mentioned before, pointernode does not have an element. Therefore, I do not set any values for it.
        public DoublyNode<T> PointerNode //When I search in the list, if the serach get this Pointernode, that means ending search.
        {
            get { return pointernode; }
        }

        public DoublyNode<T> FirstPosition
        {
            get { return this.pointernode.Next; } //The first node is the node which pointernode's next indicate which means the node is the first node which is created after pointernode.
        }                                         //The node which is indicated by pointernode.Next is always changing when the node is inserted in first position in the list.
        public DoublyNode<T> LastPosition
        {
            get { return this.pointernode.Previous; } //The last node is the node which pointernode's previous indicate. Because pointernode's previous always indicates last node. 
        }                                             //The node which is indicated by pointernode.Previous is always changing when the node is inserted in last position in the list.

        public int Count { get; set; }

        public DoublyNode<T> Addafter(DoublyNode<T> place, T value)
        {
            DoublyNode<T> newnode = new DoublyNode<T>(value, place, place.Next);
            place.Next.Previous = newnode;
            place.Next = newnode;
            this.Count += 1;
            return newnode;
        }
        public DoublyNode<T> Find(T x)
        {
            DoublyNode<T> current = this.FirstPosition;
            while (current != default && !EqualityComparer<T>.Default.Equals(current.Element, x))  //EqualityComparer<T> is from .Net.
            {
                current = current.Next;
            }
            return current;
        }

        public DoublyNode<T> Addprevious(DoublyNode<T> place, T value)
        {
            DoublyNode<T> newnode = new DoublyNode<T>(value, place.Previous, place);
            place.Previous.Next = newnode;
            place.Previous = newnode;
            this.Count += 1;
            return newnode;
        }

        public DoublyNode<T> Delete(T obj)
        {
            DoublyNode<T> searchednode = Find(obj);
            if (searchednode == pointernode)
            {
                return this.pointernode;
            }
            searchednode.Previous.Next = searchednode.Next;
            searchednode.Next.Previous = searchednode.Previous;
            this.Count -= 1;
            return searchednode.Next;

        }


        public DoublyNode<T> InsertCustomer(T obj)
        {
            return Addprevious(pointernode, obj); // Pointernode is always at last position. Therefore, add values before pointernode,
        }                                         // New node can be added in the last position in list except the pointernode

        /*public DoublyNode<T> DeleteCustoer()*/
        public IEnumerator<T> GetEnumerator()
        {
            var current = FirstPosition;

            while (current != pointernode)
            {
                yield return current.Element;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }






    }
}
