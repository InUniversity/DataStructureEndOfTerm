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

        public void PrependTheCurrentNode(Node<T>? currentNode, T item)
        {
            if (currentNode == nFirstItem)
                AddFirst(item);
            else if (currentNode == null)
                AddLast(item);
            else
            {
                Node<T> add = new Node<T>(item);
                add.next = currentNode;
                currentNode.previous.next = add;
                add.previous = currentNode.previous;
                currentNode.previous = add;
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

        public void RemoveCurrentNode(Node<T> currentNode)
        {
            if (IsEmpty()) return;

            if (nFirstItem == currentNode)
                nFirstItem = currentNode.next;

            if (currentNode.next != null)
                currentNode.next.previous = currentNode.previous;
            if (currentNode.previous != null)
                currentNode.previous.next = currentNode.next;
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