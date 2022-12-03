using System;
using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Models
{
    public abstract class Person
    {

        // fields
        protected StringCustom sID;
        protected StringCustom sName;
        protected StringCustom sGender;
        protected Date dBirthday;
        protected StringCustom sAddress;
        protected StringCustom iPhoneNumber;

        // constructor
        public Person()
        {
            dBirthday = new Date(-1, -1, -1);
        }

        public Person(string sID,StringCustom sName, StringCustom sGender,
            Date dBirthday, StringCustom sAddress, StringCustom iPhoneNumber)
        {
            this.sID = sID;
            this.sName = sName;
            this.sGender = sGender;
            this.dBirthday = dBirthday;
            this.sAddress = sAddress;
            this.iPhoneNumber = iPhoneNumber;
        }

        // destructor
        ~Person() { }

        // properties
        public string ID
        {
            get { return sID; }
            set { sID = value; }
        }

        public StringCustom Name
        {
            get { return sName; }
            set { sName = value; }
        }

        public StringCustom Gender
        {
            get { return sGender; }
            set { sGender = value; }
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
            sID = Console.ReadLine();
            Console.Write("Name: ");
            sName = Console.ReadLine();
            Console.Write("Gender: ");
            sGender = Console.ReadLine();
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
            Console.WriteLine("ID: " + sID);
            Console.WriteLine("Name: " + sName);
            Console.WriteLine("Gender: " + sGender);
            Console.WriteLine("Birhday: " + dBirthday);
            Console.WriteLine("Address: " + sAddress);
            Console.WriteLine("Phone number: " + iPhoneNumber);
        }

        public bool IsEquals(Person person)
        {
            return this.ID == person.ID;
        }
    }
}

