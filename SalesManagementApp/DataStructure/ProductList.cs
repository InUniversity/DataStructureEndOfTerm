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
                    count -= 1;
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

        public Product SearchItemByID(Product item)
        {
            Product temp = null;
            for (int i = 0; i < base.iSize; i++)
            {
                if (item.IsEqual(base.list_[i]))
                {
                    temp = list_[i];
                    break;
                }
            }
            return temp;
        }

        public ProductList DeleteByProductNumber(Product tempproduct, int n)
        {
            int temp = 0;
            ProductList templist = new ProductList(100);
            for(int i = 0; i < base.iSize; i++)
            {
                if (tempproduct.IsEqual(base.list_[i]))
                {
                    base.list_[i].NumberOfProduct = base.list_[i].NumberOfProduct-n;
                    
                    templist.AddLast(base.list_[i]);  
                }      
            }
            return templist;
        }

        public bool ItemAlreadyExists(Product item)
        {
            ProductList temp = new ProductList(100);
            for (int i = 0; i < base.iSize; i++)
            {
                if (item.IsEqual(base.list_[i]))
                {
                    base.list_[i].NumberOfProduct+=item.NumberOfProduct;
                   return true;
                }
            }
            return false;
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

        public Product QuantityOfAProduct(StringCustom name)
        {
            int tam = 0;
            Product product = new Product();
            for (int i = 0; i < base.iSize; i++)
            {
                StringCustom list = base.list_[i].Name;
                if (list.IsEquals(name))
                {
                    product = base.list_[i];
                    tam++;
                    break;
                }
            }
            if (tam == 0) return null;
            return product;
        }

        public ProductList FindByDate(Date dayStart, Date dayEnd)
        {
            ProductList temp = new ProductList(100);
            for (int i = 0; i < base.iSize; i++)
            {
                if ((list_[i].DateExpires >= dayStart) && (list_[i].DateExpires <= dayEnd))
                {
                    temp.AddLast(list_[i]);
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

        public ProductList ProductQuantityMoreThan100()
        {
            ProductList temp = new ProductList(100);
            for (int i = 0; i < base.iSize; i++)
            {
                if (base.list_[i].NumberOfProduct > 100)
                {
                    temp.AddLast(list_[i]);
                }
            }
            return temp;
        }

        public ProductList MaximumNumberOfProducts()
        {
            ProductList temp = new ProductList(100);
            Product max = base.list_[0];
            for (int i = 1; i < base.iSize; i++)
            {
                if (base.list_[i].NumberOfProduct > max.NumberOfProduct)
                {
                    max = base.list_[i];

                }
            }
            temp.AddLast(max);
            if (temp.Size == 0) return null;
            return temp;
        }

        public ProductList MinimumNumberOfProducts()
        {
            ProductList temp = new ProductList(100);
            Product min = base.list_[0];
            for (int i = 1; i < base.iSize; i++)
            {
                if (base.list_[i].NumberOfProduct < min.NumberOfProduct)
                {
                    min = base.list_[i];

                }
            }
            temp.AddLast(min);
            if (temp.Size == 0) return null;
            return temp;
        }

        public int CheckNumberProduct(Product temp)
        {
            int sum = 0;
            for (int i = 0; i < base.iSize; i++)
            {
                if (temp.IsEqual(base.list_[i]))
                {
                    sum = list_[i].NumberOfProduct;
                    break;
                }
            }
            return sum;
        }

        public bool WriteFile(StringCustom fileName)
        {
            StringCustom path = Directory.GetCurrentDirectory();
            path += "/../../../Database/" + fileName;
            try
            {
                StreamWriter sw = new StreamWriter(path);

                for (int i = 0; i < base.iSize; i++)
                {
                    sw.WriteLine("{0};{1};{2};{3};{4}",
                    list_[i].ID, //0
                    list_[i].Name, //1
                    list_[i].NumberOfProduct,//2
                    list_[i].DayStartedUsing,//3
                    list_[i].DateExpires);//4

                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public void AddLastNoDuplicate(Product product)
        {
            if (FindByID(product.ID) != null)
            {
                Console.WriteLine(Constant.DUPLICATED_MESSAGE);
                return;
            }
            AddLast(product);
        }

        public Product FindByID(StringCustom id)
        {
            Product product = null;
            for (int i = 0; i < base.iSize; i++)
            {
                product = Get(i);
                if (id.IsEquals(product.ID))
                    return product;
            }
            return null;
        }

        public override void Print()
        {
            Console.WriteLine("|{0, 8}|{1, -25}|{2, -16}|{3, -22}|{4, -20}|{5,8}|",
                   "ID ", "Name", "NumberOfProduct", "DayStartedUsing", "DateExpires", "Price");
            for (int i = 0; i < base.iSize; i++)
            {
                Console.WriteLine("|{0, 8}|{1, -25}|{2, -16}|{3, -22}|{4, -20}|{5,8}|",
                    list_[i].ID,
                    list_[i].Name,
                    list_[i].NumberOfProduct,
                    list_[i].DayStartedUsing,
                    list_[i].DateExpires,
                    list_[i].Price);
            }
        }

        public Product Bill(Product temp ,int n)
        {
            Product a = new Product();
            a.ID = temp.ID;
            a.Name = temp.Name;
            a.DayStartedUsing = temp.DayStartedUsing;
            a.DateExpires = temp.DateExpires;
            a.Price = temp.Price;
            a.NumberOfProduct = n;
            return a;
        }
    }
}

