using SalesManagementApp.Activities;
using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.Models
{
    public class Sale : Person
    {
        private int iSalary;
        private LinkedLst<StringCustom> lOrdersSold;
  
        //properties
        public int Salary
        {
            get => iSalary;
            set => iSalary = value;
        }
       
        public LinkedLst<StringCustom> OrdersSold
        {
            get => lOrdersSold;
            set => lOrdersSold = value;
        }

        //constructor
        public Sale():base()
        {
            this.lOrdersSold = new LinkedLst<StringCustom>();
        }

        public Sale(StringCustom id, StringCustom name, StringCustom gender, Date birthday, 
            StringCustom address, StringCustom phoneno, int salary, 
            LinkedLst<StringCustom> ordersSold) :base(id,name,gender,birthday,address, phoneno)
        {
            this.iSalary = salary;
            this.lOrdersSold = ordersSold;
        }

        //destruction
        ~Sale() { }

        //method
        public override void Input()
        {
            base.Input();
            Console.Write("Salary: "); this.iSalary = Convert.ToInt32(Console.ReadLine());
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Salary: " + this.iSalary);
        }

        public int SalaryMonth(int month, int year)
        {
            int price = iSalary;
            BillHash temp = BillData.billHash;
            for(int i = 0; i<this.lOrdersSold.Size; i++)
            {
                 Bill temp2 = temp.GetValue(this.lOrdersSold.GetItem(i));
                if(temp2 != null && temp2.PurchaseDate.Month == month && temp2.PurchaseDate.Year == year)
                    price += Convert.ToInt32(temp2.Price*0.01); 
            }
            return price;
        }
    }
}
