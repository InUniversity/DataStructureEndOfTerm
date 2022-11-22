using System;
namespace SalesManagementApp.DataStructure
{
    public abstract class ArrayList<T>
    {
        // fields
        protected T[] list_;
        protected int iSize;
        protected int iCapacity;

        // constructor
        public ArrayList(int capacity)
        {
            list_ = new T[capacity];
            this.iCapacity = capacity;
            iSize = 0;
        }

        // properties
        public int Size
        {
            get { return iSize; }
            set { iSize = value;  }
        }

        public int Capacity
        {
            get { return iCapacity; }
        }

        // methods
        public bool IsEmpty()
        {
            return this.iSize == 0;
        }

        public bool IsFull()
        {
            return this.iSize >= iCapacity;
        }

        protected bool IsValidIndex(int index)
        {
            return index >= 0 && index < this.iSize;
        }

        public abstract T Get(int index);

        public abstract void AddLast(T item);

        public abstract void AddItem(int index, T item);

        public abstract void AddRange(ArrayList<T> sourceList);

        public abstract void RemoveItem(int index);

        public abstract void Print();

        public abstract T SearchItem(T item);

        public abstract int IndexOf(T item);
    }
}

