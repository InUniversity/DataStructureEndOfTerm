using System;
using System.Xml.Linq;
using SalesManagementApp.Models;

namespace SalesManagementApp.DataStructure
{
    public class LinkedLst<T>
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

        public T GetItem(int index)
        {
            Node<T>? head = nFirstItem;
            for (int i = 0; i < index; i++)
                head = head.next;
            return head.item;
        }

        public bool IsEmpty()
        {
            return this.nFirstItem == null;
        }

        public void RemoveNodeInList(Node<T> del)
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

        public Node<T>? GetNode(T item)
        {
            Node<T>? head = nFirstItem;
            while (head != null)
            {
                if (item.Equals(head.item))
                    return head;
                head = head.next;
            }
            return null;
        }

        public Node<T>? GetNode(int index)
        {
            Node<T>? head = nFirstItem;
            for (int i = 0; i < index; i++)
                head = head.next;
            return head;
        }
    }
}