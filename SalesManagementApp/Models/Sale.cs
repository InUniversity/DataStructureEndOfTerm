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
        public Sale(StringCustom id, StringCustom name, StringCustom sex, Date birthday, 
            StringCustom address, StringCustom phoneno, int salary, 
            LinkedLst<StringCustom> ordersSold) :base(id,name,sex,birthday,address, phoneno)
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
            Console.WriteLine("Salary: "); this.iSalary = Convert.ToInt32(Console.ReadLine());
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Salary: " + this.iSalary);
        }
        public int Salary()
        {
            BillHash TEMP = BillData.billHash;
            for(int i = 0; i<lOrdersSold.Size; i++)
            {
                int temp = TEMP.GetValue(lOrdersSold.GetItem(i)).Price;
                iSalary += Convert.ToInt32(temp * 0.01);
            }    
            return iSalary;
        }

        public override bool IsEquals(Person person)
        {
            if(this.ID == person.ID)
                return true;
            return false;
        }
    }
}
