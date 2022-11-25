using SalesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SalesManagementApp.DataStructure
{
   
    public class SaleList : ArrayList<Sale>
    {
        private const int minium = 10;
        private const int maxdayoff = 5;
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
            Console.WriteLine("|{0, -8}|{1, -25}|{2, -4}|{3, -10}|{4, -25}|{5, -12}|{6, -9}|{7, -12}|{8, -14}|",
                "ID",//0
                "Name",//1
                "Sex",//2
                "Birthday",//3
                "Address",//4
                "Phone number",//5
                "Salary",//6
                "Order Number", //7
                "Number of Work"); //8
            for (int i = 0; i < this.iSize; i++)
            {
               Console.WriteLine("|{0, -8}|{1, -25}|{2, -4}|{3, -10}|{4, -25}|{5, -12}|{6, -9}|{7, -12}|{8, -14}|",

               this.list_[i].ID, // 0
               this.list_[i].Name, // 1
               this.list_[i].Sex, // 2
               this.list_[i].Birthday, // 3
               this.list_[i].Address, // 4
               this.list_[i].PhoneNumber, // 5
               this.list_[i].Salary, //6
               this.list_[i].Ordernumber, // 7
               this.list_[i].NoOfWork);// 8
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

        // Xuất ra danh sách nhân viên đi làm đủ 30 ngày trong tháng
        public SaleList Full30days()
        {
            SaleList temp = new SaleList(base.iSize);
            for(int i = 0; i<base.iSize; i++)
                if (base.list_[i].NoOfWork == 30)
                {
                    temp.AddLast(base.list_[i]);
                }
            if (temp.iSize == 0)
                Console.WriteLine("(Empty)");
            return temp;
        }

        // Xuất danh sách nhân viên có doanh số lớn nhất
        public SaleList MaxNumberOfSales()
        {
            SaleList temp = new SaleList(base.iSize);
            int max = base.list_[0].Ordernumber;
            for (int i = 0; i < base.iSize; i++)
                if (base.list_[i].Ordernumber >max)
                {
                    max = base.list_[i].Ordernumber;
                }
            for (int i = 0; i < base.iSize; i++)
                if (base.list_[i].Ordernumber == max)
                {
                    temp.AddLast(base.list_[i]);
                }
            if (temp.iSize == 0)
                Console.WriteLine("(Empty)");
            return temp;
        }

        // Xuất danh sách nhân viên của tháng
        public SaleList EmployeeOfMonth()
        {
            SaleList temp = new SaleList(iCapacity);
            SaleList a = this.Full30days();
            SaleList b = this.MaxNumberOfSales();
            for(int i = 0; i<a.iSize; i++)
            {
                for(int j = i; j < b.iSize; j++)
                {
                    if (a.list_[i].Equals(b.list_[j]))
                    {
                        temp.AddLast(a.list_[i]);
                        break;
                    }    
                }    
            }
            if(temp.iSize == 0)
                Console.WriteLine("(Empty)");
            return temp;
        }

        //Xuất danh sách nhân viên không đạt doanh thu tối thiểu
        public SaleList NotReachingSales()
        {
            SaleList temp = new SaleList(iCapacity);
            for (int i = 0; i<base.iSize; i++)
            {
                if(base.list_[i].Ordernumber < minium)
                {
                    temp.AddLast(base.list_[i]);
                }    
            }
            if (temp.iSize == 0)
                Console.WriteLine("(Empty)");
            return temp;
        }

        //Xuất danh sách nhân viên nghỉ quá số buổi quy định
        public SaleList AbsenceBeyondTheNorm()
        {
            SaleList temp = new SaleList(iCapacity);
            for (int i = 0; i < base.iSize; i++)
            {
                if (base.list_[i].NoOfWork < 30 - maxdayoff)
                {
                    temp.AddLast(base.list_[i]);
                }
            }
            if (temp.iSize == 0)
                Console.WriteLine("(Empty)");
            return temp;
        }
    }
}
