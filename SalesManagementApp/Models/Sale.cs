using SalesManagementApp.Activities;
using SalesManagementApp.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.Models
{
    public class Sale : Person
    {
        protected int iSalary;
        protected int iOrderNumber;
        protected int iNoOfWork;
        protected List<Customer> lCustomer;
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
        public int NoOfWork
        {
            set { this.iNoOfWork = value; }
            get { return this.iNoOfWork; }
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
            this.lCustomer = new List<Customer>();
            this.lOrdersSold = new LinkedLst<StringCustom>();
        }
        public Sale(int id, StringCustom name, StringCustom sex, Date birthday, StringCustom address, StringCustom phoneno, int salary, int orderNumber, int noOfWork, List<Customer> lcustomer, LinkedLst<StringCustom> lorderssold) :base(id,name,sex,birthday,address, phoneno)
        {
            this.iSalary = salary;
            this.iOrderNumber = orderNumber;
            this.iNoOfWork = noOfWork;
            this.lCustomer = lcustomer;
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
            Console.WriteLine("Totals No Of Work: "); this.iNoOfWork = Convert.ToInt32(Console.ReadLine());
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Salary: " + this.iSalary);
            Console.WriteLine("Totals Order Number: "+this.iOrderNumber);
            Console.WriteLine("Totals No Of Work: " +this.iNoOfWork);
        }

        public void PrintListCustomer()
        {
            Console.WriteLine("The List Customer Of Sale" + this.ID +": ") ;
            foreach(Customer x in this.LCustomer)
            {
                x.Print();
            }
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
