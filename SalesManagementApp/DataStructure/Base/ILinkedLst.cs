using System;
namespace SalesManagementApp.DataStructure.Base
{
	public interface ILinkedLst<T>
	{
        public abstract void AddNode(int index, T item);
        public abstract void Remove(T item);
        public abstract void Remove(int index);
        public abstract void RemoveLast();
        public abstract void AddRange(LinkedLst<T> sourceList);
        public abstract void Print();
        public abstract int IndexOf(T item);
    }
}

