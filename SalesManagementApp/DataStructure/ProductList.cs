using System;
using SalesManagementApp.Models;

namespace SalesManagementApp.DataStructure
{
    public class ProductList : ArrayList<Product>
    {

        public ProductList(int iCapacity) : base(iCapacity)
        {

        }

        public override void AddItem(int index, Product item)
        {
            if (base.iSize >= iCapacity) return;
            for (int i = base.iSize; i > index; i--)
            {
                base.list_[i] = base.list_[i - 1];
            }
            iSize++;
            base.list_[index] = item;
        }

        public override void AddLast(Product item)
        {
            if (base.iSize >= iCapacity) return;
            base.list_[base.iSize++] = item;
        }

        public override void AddRange(ArrayList<Product> sourceList)
        {
            for (int i = 0; i < sourceList.Size; i++)
            {
                if (base.iSize >= Capacity)
                    return;
                else
                    base.list_[base.iSize++] = sourceList.Get(i);
            }
        }

        public override Product Get(int index)
        {
            return base.list_[index];
        }

        public override void Print()
        {
            for (int i = 0; i < base.iSize; i++)
            {
                base.list_[i].Print();
            }
        }

        public override void RemoveItem(int index)
        {
            for (int i = index; i < base.iSize; i++)
            {
                base.list_[i] = base.list_[i + 1];
            }
            base.iSize--;
        }

        public override int SearchItem(Product item)
        {
            for (int i = 0; i < base.iSize; i++)
                if (item.IsEqual(base.list_[i]))
                    return i;
            return -1;
        }
    }
}

