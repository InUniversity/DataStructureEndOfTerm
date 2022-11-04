using System;
namespace SalesManagementApp.Models
{
    public abstract class Person
    {

        // fields
        protected int iID;
        protected string sName;
        protected string sSex;
        protected Date dBirthday;
        protected string sAddress;
        protected int iPhoneNumber;

        // constructor
        public Person()
        {
        }

        public Person(int iID,string sName, string sSex,
            Date dBirthday, string sAddress, int iPhoneNumber)
        {
            this.iID = iID;
            this.sName = sName;
            this.sSex = sSex;
            this.dBirthday = dBirthday;
            this.sAddress = sAddress;
            this.iPhoneNumber = iPhoneNumber;
        }

        // destructor
        ~Person() { }

        // properties
        public int ID
        {
            get { return iID; }
            set { iID = value; }
        }

        public string Name
        {
            get { return sName; }
            set { sName = value; }
        }

        public string Sex
        {
            get { return sSex; }
            set { sSex = value; }
        }

        public Date Birthday
        {
            get { return dBirthday; }
            set { dBirthday = value; }
        }

        public string Address
        {
            get { return sAddress; }
            set { sAddress = value; }
        }

        public int PhoneNumber
        {
            get { return iPhoneNumber; }
            set { iPhoneNumber = value; }
        }

        // methods
        public virtual void Input()
        {
            Console.Write("ID: ");
            iID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name: ");
            sName = Console.ReadLine();
            Console.Write("Sex: ");
            sSex = Console.ReadLine();
            dBirthday.Input();
            Console.Write("Address: ");
            sAddress = Console.ReadLine();
            Console.Write("Phone number: ");
            iPhoneNumber = Convert.ToInt32(Console.ReadLine());
        }

        public virtual void Print()
        {
            Console.WriteLine("ID: " + iID);
            Console.WriteLine("Name: " + sName);
            Console.WriteLine("Sex: " + sSex);
            Console.WriteLine("Birhday: " + dBirthday);
            Console.WriteLine("Address: " + sAddress);
            Console.WriteLine("Phone number: " + iPhoneNumber);
        }

        public abstract bool IsEquals(Person person);
    }
}

