using System;
namespace SalesManagementApp.DataStructure
{
    public class Node<T>
    {

        public T item;
        public Node<T>? next;
        public Node<T>? previous;

        public Node(T value)
        {
            this.item = value;
            next = null;
            previous = null;
        }
    }
}

