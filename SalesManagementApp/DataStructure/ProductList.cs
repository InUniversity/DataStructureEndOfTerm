using System;
using SalesManagementApp.Models;

namespace SalesManagementApp.DataStructure
{
    public class ProductList : ArrayList<Product>
    {

        public ProductList(int iCapacity) : base(iCapacity)
        {

        }

        // methods
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
            if (!IsValidIndex(index)) return null;
            else return base.list_[index];
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

        public override Product SearchItem(Product item)
        {
            for (int i = 0; i < base.iSize; i++)
                if (item.IsEqual(base.list_[i]))
                    return base.list_[i];
            return null;
        }

        public bool SearchByName(Product name, ref string storage)
        {
            for (int i = 0; i < base.iSize; i++)
                if (string.Compare(name.Name, base.list_[i].Name) == 0)
                {
                    storage = base.list_[i].Name;
                    return true;
                }
            return false;
        }

        public override int IndexOf(Product item)
        {
            for (int i = 0; i < base.iSize; i++)
                if (item.IsEqual(base.list_[i]))
                    return i;
            return -1;
        }
        
        public void SortByNumber(Product number)
        {
            for (int i = 1; i < base.iSize; i++)
            {
                Product t = list_[i];
                int j = i - 1;
                while (j >= 0 && t.NumberOfProduct > list_[j].NumberOfProduct)
                {
                    list_[j + 1] = list_[j];
                    j--;
                }
                list_[j + 1] = t;
            }

        }
        
        //RemoveProductListExpires
        public void RemoveProduct()
        {

        }

        public void CheckListProduct(Date Today, int index)
        {
            Console.WriteLine("Enter Current Date");
            Today.Input();
            for (int i = 0; i < base.iSize; i++)
            {
                if (list_[i].CheckProduct(list_[i], Today) == true)
                {
                    Console.WriteLine("Expiry date is still available");
                }
                else
                {

                    Console.WriteLine("Out Of Date");
                }
            }
        }

        public int TotalGoods()
        {
            int sum = 0;
            for (int i = 0; i < base.iSize; i++)
            {
                sum = list_[i].NumberOfProduct;
            }
            return sum;
        }



    }
}

