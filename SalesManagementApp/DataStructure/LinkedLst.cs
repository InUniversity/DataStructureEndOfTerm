using System;
using System.Xml.Linq;

namespace SalesManagementApp.DataStructure
{
    public abstract class LinkedLst<T>
    {
        protected Node<T>? nFirstItem;
        protected Node<T>? nLastItem;
        protected int iSize;

        public LinkedLst()
        {
            nFirstItem = null;
            nLastItem = null;
            this.iSize = 0;
        }

        public Node<T>? FirstItem
        {
            get { return nFirstItem; }
            set { nFirstItem = value; }
        }

        public Node<T>? LastItem
        {
            get { return nLastItem; }
            set { nLastItem = value; }
        }

        public int Size
        {
            get { return iSize; }
            set { iSize = value; }
        }

        // methods
        public void AddFirst(T item)
        {
            if (IsFull()) return;

            Node<T> newNode = new Node<T>(item);
            if (IsEmpty())
                nFirstItem = nLastItem = newNode;
            else
            {
                newNode.next = nFirstItem;
                if (nFirstItem != null)
                    nFirstItem.previous = newNode;
                nFirstItem = newNode;
            }
            iSize++;
        }

        public void AddLast(T item)
        {
            if (IsFull()) return;

            Node<T>? newNode = new Node<T>(item);
            if (IsEmpty())
                nFirstItem = nLastItem = newNode;
            else
            {
                nLastItem.next = newNode;
                nLastItem = nLastItem.next;
            }
            iSize++;
        }

        public bool IsEmpty()
        {
            return this.nFirstItem == null;
        }

        public void RemoveNode(Node<T> del)
        {
            if (IsEmpty()) return;

            if (nFirstItem == del)
                nFirstItem = del.next;

            if (del.next != null)
                del.next.previous = del.previous;
            if (del.previous != null)
                del.previous.next = del.next;
            iSize--;
        }

        public void Sort(Func<T, T, int> compare)
        {
            Node<T>? head1 = nFirstItem;
            Node<T>? temp = null;
            while (head1.next != null)
            {
                Node<T>? head2 = head1.next;
                while (head2 != null)
                {
                    if (compare(head2.item, head1.item) > 0)
                    {
                        temp = head1;
                        head1 = head2;
                        head2 = temp;
                    }
                    head2 = head2.next;
                }
                head1 = head1.next;
            }
        }

        public abstract void AddNode(int index, T item);

        public abstract bool IsFull();

        public abstract void Remove(T item);

        public abstract void Remove(int index);

        public abstract void RemoveLast();

        public abstract void AddRange(LinkedLst<T> sourceList);

        public abstract Node<T>? GetNode(int index);

        public abstract Node<T>? SearchNode(T item);

        public abstract void Print();

        public abstract int IndexOf(T item);
    }
}