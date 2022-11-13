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
            if (!IsValidIndex(index)) return null;
            else return base.list_[index];
        }

        public override void Print()
        {
            Console.WriteLine("|{0, 8}|{1, -25}|{2, 16}|{3, 17}|{4, 12}|",
                   "ID ","Name","iNumberOfProduct","dDayStartedUsing","dDateExpires");
            for (int i = 0; i < base.iSize; i++)
            {
                // base.list_[i].Print();
                Console.WriteLine("|{0, 8}|{1, -25}|{2, 16}|{3, 17}|{4, 12}|",
                    list_[i].ID,
                    list_[i].Name,
                    list_[i].NumberOfProduct,
                    list_[i].DayStartedUsing,
                    list_[i].DateExpires);
            }
            Console.WriteLine("Enter To Continue");
            Console.ReadKey();

        }

        //public override void Print()
        //{
        //    Console.WriteLine("|{0, -8}|{1, -25}|{2, -4}|{3, -10}|{4, -25}|{5, -12}|{6, -19}|{7, -6}|{8, -14}|{9, -18}|",
        //        "ID",
        //        "Name",
        //        "iNumberOfProduct",
        //        "dDayStartedUsing",
        //        "dDateExpires",

        //    Product temp;
        //    Node<Customer>? head = nFirstItem;
        //    while (head != null)
        //    {
        //        temp = head.item;
        //        Console.WriteLine("|{0, 8}|{1, -25}|{2, 4}|{3, -10}|{4, -25}|{5, -12}|{6, -19}|{7, -6}|{8, -14}|{9, -18}|",
        //        temp.ID, // 0
        //        temp.Name, // 1
        //        temp.Sex, // 2
        //        temp.Birthday, // 3
        //        temp.Address, // 4


        //        head = head.next;
        //    }
        //}


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

        public ProductList SearchItemByID(Product item)
        {
            int temp1 = 0;
            ProductList temp = new ProductList(100);
            for (int i = 0; i < base.iSize; i++)
            {
                if (item.IsEqual(base.list_[i]))
                {
                    temp.AddLast(base.list_[i]);
                    temp1++;
                }
            }
            if (temp1 == 0) return null;
            return temp;
        }

        public ProductList SearchItemByName(Product item)
        {
            ProductList temp = new ProductList(100);
            int temp1 = 0;
            for (int i = 0; i < base.iSize; i++)
                if (String.Equals(item.Name, list_[i].Name))
                {
                    temp.AddLast(base.list_[i]);
                    temp1++;
                }

            if (temp1 == 0) return null;
            return temp;
        }

        public override int IndexOf(Product item)
        {
            for (int i = 0; i < base.iSize; i++)
                if (item.IsEqual(base.list_[i]))
                    return i;
            return -1;
        }

        public ProductList SortByNumber()
        {
            ProductList temp = new ProductList(100);
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
            for (int i = 0; i < base.iSize; i++)
            {
                temp.AddLast(list_[i]);
            }
            return temp;
        }

        public ProductList FindExpiredProducts(Date today)
        {
            ProductList temp = new ProductList(100);
            for (int i = 0; i < base.iSize; i++)
                if (today < list_[i].DateExpires)
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

