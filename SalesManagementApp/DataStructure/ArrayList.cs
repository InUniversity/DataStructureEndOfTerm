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
        // Truyền vào một biểu thức lambda để so sánh 2 phần tử trong mảng
        public void Sorted(Func<T, T, int> compare)
        {
            for (int i = 0; i < this.iSize - 1; i++)
                for (int j = i + 1; j < this.iSize; j++)
                    if (compare(list_[j], list_[i]) > 0)
                    {
                        T temp = list_[j];
                        list_[j] = list_[i];
                        list_[i] = temp;
                    }
        }
        
        public bool IsEmpty()
        {
            return this.iSize == 0;
        }

        public bool IsFull()
        {
            return this.iSize >= iCapacity;
        }

        public abstract T Get(int index);

        public abstract void AddLast(T item);

        public abstract void AddItem(int index, T item);

        public abstract void AddRange(ArrayList<T> sourceList);

        public abstract void RemoveItem(int index);

        public abstract void Print();

        public abstract int SearchItem(T item);
    }
}

