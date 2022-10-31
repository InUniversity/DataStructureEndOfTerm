using System;
namespace SalesManagementApp.Models
{
    public class Manager
    {
        

        private int iID;
        private string sName;
        private int iSalary;

        public int ID
        {
            get { return this.iID; }
            set { this.iID = value; }
        }
        public string Name
        {
            get { return this.sName; }
            set { this.sName = value; }
        }
        public int Salary
        {
            get { return this.iSalary; }
            set { this.iSalary = value; }
        }

        public Manager()
        {

        }
        public Manager(int id, string name, int salary)
        {
            this.iID = id;
            this.sName = name;
            this.iSalary = salary;
        }
        public Manager(Manager manager1, Manager manager2, Manager manager3, Manager manager4, Manager manager5, Manager manager6, Manager manager7, Manager manager8, Manager manager9, Manager manager10, int iID, string sName, int iSalary, int iD, string name, int salary)
        {
            Manager1 = manager1;
            Manager2 = manager2;
            Manager3 = manager3;
            Manager4 = manager4;
            Manager5 = manager5;
            Manager6 = manager6;
            Manager7 = manager7;
            Manager8 = manager8;
            Manager9 = manager9;
            Manager10 = manager10;
        }

        ~Manager() { }

        public void Input()
        {
            Console.WriteLine("Insert the manager's information: ");
            Console.WriteLine("Manager's ID     : "); this.iID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Manager's Name   : "); this.sName = Console.ReadLine();
            Console.WriteLine("Manager's Salary : "); this.iSalary = Convert.ToInt32(Console.ReadLine());
        }
        public void Print()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Manager's Information: ");
            Console.WriteLine("........................................");
            Console.WriteLine("Manager's ID     : " + this.iID); 
            Console.WriteLine("Manager's Name   : " + this.sName); 
            Console.WriteLine("Manager's Salary : " + this.iSalary);
            Console.WriteLine("----------------------------------------");
        }
    }
}

