using SalesManagementApp.DataStructure;
using System;
namespace SalesManagementApp.Models
{
    public class Manager : Person
    {
        // fields
        private int iSalary;
        // properties
        public int Salary
        {
            get { return this.iSalary; }
            set { this.iSalary = value; }
        }

        // constructor
        public Manager()
        {
        }

        public Manager(int salary, int id, StringCustom name, StringCustom sex, Date birthday, StringCustom address, StringCustom nophone) : base(id, name, sex, birthday, address, nophone)
        {
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
            base.Input();
            Console.Write("Salary: ");
            this.iSalary = Convert.ToInt32(Console.ReadLine());
        }
        public void Print()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Manager's Information: ");
            Console.WriteLine("........................................");
            base.Print();
            Console.WriteLine("Salary: " +this.Salary);
            Console.WriteLine("----------------------------------------");
        }

        public override bool IsEquals(Person person)
        {
            if(this.iID == person.ID) return true;
            return false;
        }
    }
}


