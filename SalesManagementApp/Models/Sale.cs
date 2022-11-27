using SalesManagementApp.Activities;
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
        protected int iSalary;
        protected int iOrderNumber;
        protected LinkedLst<StringCustom> lOrdersSold;
  
        //properties
        public int Salary
        {
            set { this.iSalary = value; }
            get { return this.iSalary; }
        }
        public int Ordernumber
        {
            set { this.iSalary = value; }
            get { return this.iOrderNumber; }
        }
        public List<Customer> LCustomer
        {
            set { this.LCustomer = value;  }
            get { return this.LCustomer; }
        }
        public LinkedLst<StringCustom> LOrdersSold
        {
            set { this.lOrdersSold = value; }
            get { return this.lOrdersSold; }
        }

        //constructor
        public Sale():base()
        {
            this.lOrdersSold = new LinkedLst<StringCustom>();
        }
        public Sale(string id, StringCustom name, StringCustom sex, Date birthday, StringCustom address, StringCustom phoneno, int salary,
            int orderNumber, LinkedLst<StringCustom> lorderssold) :base(id,name,sex,birthday,address, phoneno)
        {
            this.iSalary = salary;
            this.iOrderNumber = orderNumber;
            this.lOrdersSold = lorderssold;
        }

        //destruction
        ~Sale() { }

        //method
        public override void Input()
        {
            base.Input();
            Console.WriteLine("Salary: "); this.iSalary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Totals Order Number: "); this.iOrderNumber = Convert.ToInt32(Console.ReadLine());
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Salary: " + this.iSalary);
            Console.WriteLine("Totals Order Number: " + this.iOrderNumber);
        }

     
        
        public LinkedLst<StringCustom> ListProduct()
        {
            return this.lOrdersSold;
        }

        public override bool IsEquals(Person person)
        {
            if(this.ID == person.ID)
                return true;
            return false;
        }
       
        
    }
}
