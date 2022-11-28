using SalesManagementApp.Database;
using SalesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



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
            Console.WriteLine("|{0, -8}|{1, -25}|{2, -4}|{3, -10}|{4, -25}|{5, -12}|{6, -9}|",
                "ID",//0
                "Name",//1
                "Sex",//2
                "Birthday",//3
                "Address",//4
                "Phone number",//5
                "Salary",//6
                "Order Number" //7
            );
            for (int i = 0; i < this.iSize; i++)
            {
                Console.WriteLine("|{0, -8}|{1, -25}|{2, -4}|{3, -10}|{4, -25}|{5, -12}|{6, -9}|",

                this.list_[i].ID, // 0
                this.list_[i].Name, // 1
                this.list_[i].Gender, // 2
                this.list_[i].Birthday, // 3
                this.list_[i].Address, // 4
                this.list_[i].PhoneNumber, // 5
                this.list_[i].Salary); // 6
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
            BillHash TEMP = BillData.billHash;
            Sale temp = people;
            int num = 0;
            for(int i = 0; i<temp.OrdersSold.Size; i++)
            {
                StringCustom temp2 = temp.OrdersSold.GetItem(i);
                Bill temp3 = TEMP.GetValue(temp2);
                if(temp3.PurchaseDate.Month == month && temp3.PurchaseDate.Year == year)
                {
                    num++;
                }    
            }    
            return num;
        }
        public int PriceSale(Sale people, int month, int year)
        {
            BillHash TEMP = BillData.billHash;
            Sale temp = people;
            int price = 0;
            for (int i = 0; i < temp.OrdersSold.Size; i++)
            {
                StringCustom temp2 = temp.OrdersSold.GetItem(i);
                Bill temp3 = TEMP.GetValue(temp2);
                if (temp3.PurchaseDate.Month == month && temp3.PurchaseDate.Year == year)
                {
                    price += temp3.Price;
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
            for(int i = 0; i<this   .iSize; i++)
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
            QuickSort(lSale, left, right); ;
            lSale.Print();

        }
        public static void QuickSort(SaleList lSale, int left, int right)
        {
            int pivot = Patation(lSale, left, right);
            if (pivot > 1)
            {
                QuickSort(lSale, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                QuickSort(lSale, pivot + 1, right);
            }
        }
        public static int Patation(SaleList lSale, int left, int right)
        {
            int pivot = left;
            while (true)
            {
                while (lSale.list_[left].Birthday < lSale.list_[pivot].Birthday)
                    left++;
                while (lSale.list_[right].Birthday > lSale.list_[pivot].Birthday)
                    right--;
                if (left < right)
                {
                    if (lSale.list_[left].Birthday == lSale.list_[right].Birthday) return right;

                    Sale temp = lSale.list_[left];
                    lSale.list_[left] = lSale.list_[pivot];
                    lSale.list_[pivot] = temp;
                }
                else return right;
            }
        }
    }
}