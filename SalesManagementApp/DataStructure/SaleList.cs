﻿using SalesManagementApp.Database;
using SalesManagementApp.DataStructure.Base;
using SalesManagementApp.Models;

namespace SalesManagementApp.DataStructure
{
   
    public class SaleList : ArrayList<Sale>
    {
        private const int MIN_INUM = 10;
        private const int MAX_DAY_OFF = 5;
        public SaleList(int capacity) : base(capacity)
        {
        }
        ~SaleList() { }

        public bool WriteFile(StringCustom fileName)
        {
            StringCustom path = Directory.GetCurrentDirectory();
            path += "/../../../Database/" + fileName;
            try
            {
                StreamWriter sw = new StreamWriter(path);
                LinkedLst<StringCustom> purchasedOrders;
                Node<StringCustom>? headPurchasedOrders;
                Sale sale = null;
                for (int i = 0; i < iSize; i++)
                {
                    sale = Get(i);
                    sw.Write("{0};{1};{2};{3};{4};{5};{6};",
                    sale.ID, // 0
                    sale.Name, // 1
                    sale.Gender, // 2
                    sale.Birthday, // 3
                    sale.Address, // 4
                    sale.PhoneNumber, // 5
                    sale.Salary); // 6

                    purchasedOrders = sale.OrdersSold;
                    if (purchasedOrders.IsEmpty())
                        sw.Write(Constant.EMPTY_VALUE);
                    else
                    {
                        headPurchasedOrders = purchasedOrders.FirstItem;
                        while (headPurchasedOrders.next != null)
                        {
                            sw.Write("{0},", headPurchasedOrders.item);
                            headPurchasedOrders = headPurchasedOrders.next;
                        }
                        if (headPurchasedOrders != null)
                            sw.Write("{0}", headPurchasedOrders.item);
                    }

                    sw.WriteLine();
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

        public bool AddFromFile(StringCustom fileName)
        {
            StringCustom path = Directory.GetCurrentDirectory();
            path += "/../../../Database/" + fileName;
            try
            {
                Sale sale = new Sale();
                // read the whole file
                string[] lines = File.ReadAllLines(path);

                foreach (string str in lines)
                {
                    sale = GetSaleFromFile(new StringCustom(str));
                    if (SearchItem(sale) == null)
                        AddLast(sale);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        private Sale GetSaleFromFile(StringCustom data)
        {
            StringCustom tempStr;
            LinkedLst<StringCustom> tempBills = new LinkedLst<StringCustom>();
            Node<StringCustom>? head;
            LinkedLst<StringCustom> temp = data.Split(';');

            Sale sale = new Sale();
            sale.ID = temp.GetItem(0);
            sale.Name = temp.GetItem(1);
            sale.Gender = temp.GetItem(2);
            sale.Birthday = (Date)temp.GetItem(3);
            sale.Address = temp.GetItem(4);
            sale.PhoneNumber = temp.GetItem(5);
            sale.Salary = temp.GetItem(6).ToInt();

            tempStr = temp.GetItem(7);
            if (tempStr != Constant.EMPTY_VALUE)
            {
                tempBills = tempStr.Split(',');
                head = tempBills.FirstItem;
                while (head != null)
                {
                    sale.OrdersSold.AddLast(head.item);
                    head = head.next;
                }
            }
            return sale;
        }

        //Thêm nhân viên vào vị trí bất kỳ
        public override void AddItem(int index, Sale item)
        {
            if (base.iSize >= iCapacity) return;
            for (int i = base.iSize; i > index; i--)
            {
                base.list_[i] = base.list_[i - 1];
            }
            iSize++;
            base.list_[index] = item;
        }

        //Thêm nhân viên vào vị trí sau cùng
        public override void AddLast(Sale item)
        {
            if (base.iSize >= iCapacity) return;
            base.list_[base.iSize++] = item;
        }

        //Thêm một danh sach nhân viên vào cuối
        public override void AddRange(ArrayList<Sale> sourceList)
        {
            for (int i = 0; i < sourceList.Size; i++)
                AddLast(sourceList.Get(i));
        }

        //Xuất ra nhân viên với chỉ số index
        public override Sale Get(int index)
        {
            if (!IsValidIndex(index)) return null;
            else return base.list_[index];
        }

        //Tìm chỉ số của nhân viên bằng id
        public override int IndexOf(Sale item)
        {
            for (int i = 0; i < base.iSize; i++)
                if (item.IsEquals(base.list_[i]))
                    return i;
            return -1;
        }

        //Nhập thông tin của một danh sách nhân viên với số lượng nhập từ bàn phím
        public void Input()
        {
            Console.WriteLine("Insert the number of employee: ");
            int no = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i< no; i++)
            {
                this.Input();
            }    
        }

        //In danh sách nhân viên
        public override void Print()
        {
            Console.WriteLine("|{0, -8}|{1, -25}|{2, -4}|{3, -10}|{4, -25}|{5, -12}|",
                "ID",//0
                "Name",//1
                "Sex",//2
                "Birthday",//3
                "Address",//4
                "Phone number" //5
            );
            for (int i = 0; i < this.iSize; i++)
            {
                Console.WriteLine("|{0, -8}|{1, -25}|{2, -4}|{3, -10}|{4, -25}|{5, -12}|",

                this.list_[i].ID, // 0
                this.list_[i].Name, // 1
                this.list_[i].Gender, // 2
                this.list_[i].Birthday, // 3
                this.list_[i].Address, // 4
                this.list_[i].PhoneNumber);//5
            }
        }

        //Xóa nhân viên ở chỉ số index
        public override void RemoveItem(int index)
        {
            for (int i = index; i < base.iSize; i++)
            {
                base.list_[i] = base.list_[i + 1];
            }
            base.iSize--;
        }

        //Tìm xem nhân viên mang ID/ tên có trong danh sách không
        public override Sale SearchItem(Sale item)
        {
            for (int i = 0; i < base.iSize; i++)
                if (item.IsEquals(base.list_[i]))
                    return base.list_[i];
            return null;
        }
        public int NumberSale(Sale people, int month, int year)
        {
            BillHash billHash = BillData.billHash;
            Sale sale = people;
            int num = 0;
            for(int i = 0; i<sale.OrdersSold.Size; i++)
            {
               
                Bill temp2 = billHash.GetValue(sale.OrdersSold.GetItem(i));

                if (temp2 != null && temp2.PurchaseDate.Month == month && temp2.PurchaseDate.Year == year)
                {
                    num++;
                }    
            }
            return num;
        }
        public int PriceSale(Sale people, int month, int year)
        {
            BillHash billHash = BillData.billHash;
            
            Sale sale = people;
            int price = 0;
            for (int i = 0; i < sale.OrdersSold.Size; i++)
            {
                Bill temp2 = billHash.GetValue(sale.OrdersSold.GetItem(i));
                if (temp2 != null && temp2.PurchaseDate.Month == month && temp2.PurchaseDate.Year == year) 
                {
                    price += temp2.Price;
                }
            }
            return price;
        }
        public int MaxNoSale(ArrayList<Sale> SaleList, int month, int year)
        {
            int max = 0;
            for(int i = 0; i<SaleList.Size; i++)
            {
                int temp = NumberSale(SaleList.Get(i), month, year);
                if (max < temp) max = temp;
            }
            return max;
        }
        public int MaxPriceSale(ArrayList<Sale> SaleList, int month, int year)
        {
            int max = 0;
            for (int i = 0; i < SaleList.Size; i++)
            {
                int temp = PriceSale(SaleList.Get(i), month, year);
                if (max < temp) max = temp;
            }
            return max;
        }

        public SaleList BestNoSaler(int month, int year)
        {
            int max = MaxNoSale(this, month, year);
            SaleList temp = new SaleList(this.iCapacity);
            for(int i = 0; i<this.iSize; i++)
            {
                if (NumberSale(this.Get(i), month, year) == max)
                    temp.AddLast(this.Get(i));
            } 
            return temp;
        }
        public SaleList BestPriceSaler(int month, int year)
        {
            int max = MaxPriceSale(this, month, year);
            SaleList temp = new SaleList(this.iCapacity);
            for (int i = 0; i < this.iSize; i++)
            {
                if (PriceSale(this.Get(i), month, year) == max)
                    temp.AddLast(this.Get(i));
            }
            return temp;
        }

        public void DeleteSale(StringCustom id)
        {
            int i;
            for (i = 0; i < this.Size; i++)
                if (this.list_[i].ID == id)
                    break;
            this.RemoveItem(i);
        }

        public static void SortByBirthDay(SaleList lSale)
        {
            int left = 0, right = lSale.Size -1;
            QuickSort(lSale, left, right); 
        }
        public static void QuickSort(SaleList lSale, int left, int right)
        {
           
            int i = left, j = right;

            int pivot = right;
            while(i<=j)
            {
                while (lSale.list_[i].Birthday < lSale.list_[pivot].Birthday)
                    i++;
                while (lSale.list_[j].Birthday > lSale.list_[pivot].Birthday)
                    j--;
                if(i<=j)
                {
                    Sale temp = lSale.list_[i];
                    lSale.list_[i] = lSale.list_[j];
                    lSale.list_[j] = temp;
                    i++;
                    j--;
                }    
            }
            if (left < j)
                QuickSort(lSale, left, j);
            if(i<right)
                QuickSort(lSale, i, right);
        }
        public void NoSaleOfMonth(Date item)
        {
           Console.WriteLine("|{0, -8}|{1, -25}|{2, -4}|{3, -10}|{4, -25}|{5, -12}|{6, -9}|{7, -10}|{8, -10}|",
               "ID",//0
               "Name",//1
               "Sex",//2
               "Birthday",//3
               "Address",//4
               "Phone number",//5
               "Salary",//6 
               "No Sale", //7
               "Price"
           );
           for (int i = 0; i < this.iSize; i++)
            {
                Console.WriteLine("|{0, -8}|{1, -25}|{2, -4}|{3, -10}|{4, -25}|{5, -12}|{6, -9}|{7, -10}|{8, -10}|",
                this.list_[i].ID, // 0
                this.list_[i].Name, // 1
                this.list_[i].Gender, // 2
                this.list_[i].Birthday, // 3
                this.list_[i].Address, // 4
                this.list_[i].PhoneNumber, // 5
                this.list_[i].SalaryMonth(item.Month, item.Year), // 6
                this.NumberSale(this.Get(i), item.Month, item.Year), //7
                this.PriceSale(this.Get(i), item.Month, item.Year)
                );
            }
        }
        public void BillOfSaleByTime(StringCustom id, Date time_)
        {
            Console.WriteLine("Bill of " + id);
            Sale sale = new Sale();
            BillHash billHash = BillData.billHash;
            sale.ID = id;
            int index = this.IndexOf(sale);
            if (index >= 0 && index < this.iSize)
            {
                int count = 0;
                for (int i = 0; i < this.list_[index].OrdersSold.Size; i++)
                {
                    Bill temp2 = billHash.GetValue(this.list_[index].OrdersSold.GetItem(i));
                    if (temp2 != null && temp2.PurchaseDate.Month == time_.Month && temp2.PurchaseDate.Year == time_.Year)
                    {
                        Console.WriteLine(".........................................");
                        count++;
                        temp2.Print();
                    }
                    if(count == 0) Console.WriteLine(Constant.EMPTY_MESSAGE);
                }
            }
            else
                Console.WriteLine(Constant.EMPTY_MESSAGE);
        }
        
    }
}