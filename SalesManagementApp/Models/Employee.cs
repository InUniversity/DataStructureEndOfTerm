using SalesManagementApp.Activities;
using SalesManagementApp.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.Models
{
    public class Employee : Person
    {
        protected int iSalary;
        protected int iOrderNumber;
        protected int iNoOfWork;
  
        // protected List<Customer> lCustomer; 

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

        //constructor
        public Employee():base()
        {

        }
        public Employee(int id, StringCustom name, StringCustom sex, Date birthday, StringCustom address, StringCustom phoneno,int salary, int orderNumber, int noOfWork /*,List<Customer> lcustomer*/) :base(id,name,sex,birthday,address, phoneno)
        {
            this.iSalary = salary;
            this.iOrderNumber = orderNumber;
            this.iNoOfWork = noOfWork;
            //this.lCustomer = lcostomer;
        }

        //destruction
        ~Employee() { }

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

        public override bool IsEquals(Person person)
        {
            if(this.ID == person.ID)
                return true;
            return false;
        }
    }
}
