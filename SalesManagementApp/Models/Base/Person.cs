using System;
using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Models
{
    public abstract class Person
    {

        // fields
        protected int iID;
        protected StringCustom sName;
        protected StringCustom sSex;
        protected Date dBirthday;
        protected StringCustom sAddress;
        protected StringCustom iPhoneNumber;

        // constructor
        public Person()
        {
            dBirthday = new Date(-1, -1, -1);
        }

        public Person(int iID,StringCustom sName, StringCustom sSex,
            Date dBirthday, StringCustom sAddress, StringCustom iPhoneNumber)
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

        public StringCustom Name
        {
            get { return sName; }
            set { sName = value; }
        }

        public StringCustom Sex
        {
            get { return sSex; }
            set { sSex = value; }
        }

        public Date Birthday
        {
            get { return dBirthday; }
            set { dBirthday = value; }
        }

        public StringCustom Address
        {
            get { return sAddress; }
            set { sAddress = value; }
        }

        public StringCustom PhoneNumber
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
            Console.WriteLine("Enter birthday:");
            Console.WriteLine("{");
            dBirthday.Input();
            Console.WriteLine("}");
            Console.Write("Address: ");
            sAddress = Console.ReadLine();
            Console.Write("Phone number: ");
            iPhoneNumber = Console.ReadLine();
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

