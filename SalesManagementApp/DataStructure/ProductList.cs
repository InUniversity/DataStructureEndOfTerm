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

        public void AddFirst(Product item)
        {
            if (base.iSize >= iCapacity) return;
            iSize++;
            for (int i = iSize; i > 0; i--)
            {
                base.list_[i] = base.list_[i - 1];
            }
            base.list_[0] = item;
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
            Console.WriteLine("|{0, 8}|{1, -25}|{2, 16}|{3, 17}|{4, 12}|",
                   "ID ", "Name", "NumberOfProduct", "DayStartedUsing", "DateExpires");
            for (int i = 0; i < base.iSize; i++)
            {
                Console.WriteLine("|{0, 8}|{1, -25}|{2, 16}|{3, 17}|{4, 12}|",
                    list_[i].ID,
                    list_[i].Name,
                    list_[i].NumberOfProduct,
                    list_[i].DayStartedUsing,
                    list_[i].DateExpires);
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

        public int RemoveItemByID(Product tempproduct)
        {
            int count = base.iSize;
            for (int i = 0; i < base.iSize; i++)
            {
                if (base.list_[i].ID == tempproduct.ID)
                {
                    RemoveItem(i);
                    count -= 3;
                    break;
                }
            }
            return count;

        }

        public override Product SearchItem(Product item)
        {
            for (int i = 0; i < base.iSize; i++)
                if (item.IsEqual(base.list_[i]))
                    return base.list_[i];
            return null;
        }

        public ProductList SearchItemByID(Product item)
        {
            ProductList temp = new ProductList(100);
            for (int i = 0; i < base.iSize; i++)
            {
                if (item.IsEqual(base.list_[i]))
                {
                    temp.AddLast(base.list_[i]);
                }
            }
            if (temp.Size == 0) return null;
            return temp;
        }

        public ProductList SearchItemByName(StringCustom name)
        {
            ProductList temp = new ProductList(100);
            Product product = new Product();
            for (int i = 0; i < base.iSize; i++)
            {
                StringCustom list = base.list_[i].Name;
                if (list.IsEquals(name))
                {
                    temp.AddLast(base.list_[i]);
                }
            }
            if (temp.Size == 0) return null;
            return temp;
        }

        public override int IndexOf(Product item)
        {
            for (int i = 0; i < base.iSize; i++)
                if (item.IsEqual(base.list_[i]))
                    return i;
            return -1;
        }

        public void SortByNumberOfProduct()
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

        public ProductList FindExpiredProducts(Date today)
        {
            ProductList temp = new ProductList(100);
            for (int i = 0; i < base.iSize; i++)
                if (today > list_[i].DateExpires)
                    temp.AddLast(list_[i]);
            return temp;
        }

        public int TotalGoods()
        {
            int sum = 0;
            for (int i = 0; i < base.iSize; i++)
            {
                sum += list_[i].NumberOfProduct;
            }
            return sum;
        }
    }
}

