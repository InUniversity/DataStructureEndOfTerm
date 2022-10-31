using System;
namespace SalesManagementApp.Models
{
    public class Manager
    {

        // fields
        private int iID;
        private string sName;
        private int iSalary;

        // properties
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

        // constructor
        public Manager()
        {
        }

        public Manager(int id, string name, int salary)
        {
            this.iID = id;
            this.sName = name;
            this.iSalary = salary;
        }

        // destructor
        ~Manager() { }

        // methods
        public bool IsEqual(Manager manager)
        {
            if (this.iID == manager.ID) return true;
            else return false;
        }

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

