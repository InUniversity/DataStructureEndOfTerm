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
        public Sale(string id, StringCustom name, StringCustom sex, Date birthday, StringCustom address, StringCustom phoneno, int salary,
            int orderNumber, int noOfWork, List<Customer> lcustomer, LinkedLst<StringCustom> lorderssold) :base(id,name,sex,birthday,address, phoneno)
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
            foreach (Customer customer in this.lCustomer)
            {
                customer.Print();
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
       
        //Sắp xếp danh sách khách hàng theo id
        public static void QuickSortCustomerMạin(List<Customer> lCustomer)
        {
            int left = 0, right = lCustomer.Count;
            QuickSort(lCustomer, left, right);
            foreach (Customer x in lCustomer)
                x.Print();

        }
        public static void QuickSort(List<Customer> customers, int left, int right)
        {
            int pivot = Patation(customers, left, right);
            if(pivot>1)
            {
                QuickSort(customers, left, pivot - 1);
            }    
            if(pivot +1 <right)
            {
                QuickSort(customers, pivot +1, right);
            }    
        }
        public static int Patation(List<Customer> customers, int left, int right)
        {
            int pivot = left;
            while(true)
            {
                int k;
                do
                {
                    k = customers[left].ID.CompareTo(customers[pivot].ID);
                    if (k < 0) left++;
                } while (k < 0);
                do
                {
                    k = customers[right].ID.CompareTo(customers[pivot].ID);
                    if (k> 0) right++;
                } while (k > 0);
                do
                {
                    k = customers[left].ID.CompareTo(customers[right].ID);
                    if (k < 0)
                    {
                        int h = customers[left].ID.CompareTo(customers[left].ID);
                        if (h == 0) return right;

                        Customer a = customers[left];
                        customers[left] = customers[right];
                        customers[right] = a;
                    }
                    else
                    {
                        return right;
                    }
                        
                } while (k < 0);
            }    
        }
    }
}
