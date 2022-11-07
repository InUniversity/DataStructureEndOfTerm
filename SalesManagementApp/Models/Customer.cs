using System;
namespace SalesManagementApp.Models
{
    public class Customer : Person
    {

        // fields
        private int iNumberOfProductsPurchased;
        private int iPoint;
        private string sTypeOfMember;
        private Date dLastPurchaseDate;

        // constructor
        public Customer() : base()
        {
            dLastPurchaseDate = new Date(-1, -1, -1);
        }

        public Customer(int iID, string sName, string sSex,
            Date dBirthday, string sAddress, int iPhoneNumber,
            int iNumberOfProductsPurchased, int iPoint, string sTypeOfMember,
            Date dLastPurchaseDate) : base(iID, sName, sSex, dBirthday,
                sAddress, iPhoneNumber)
        {
            this.iNumberOfProductsPurchased = iNumberOfProductsPurchased;
            this.iPoint = iPoint;
            this.sTypeOfMember = sTypeOfMember;
            this.dLastPurchaseDate = dLastPurchaseDate;
        }

        // properties
        public int NumberOfProductsPurchased
        {
            get { return iNumberOfProductsPurchased; }
            set { iNumberOfProductsPurchased = value; }
        }

        public int Point
        {
            get { return iPoint; }
            set { iPoint = value; }
        }

        public string TypeOfMember
        {
            get { return sTypeOfMember; }
            set { sTypeOfMember = value; }
        }

        public Date LastPurchaseDate
        {
            get { return dLastPurchaseDate; }
            set { dLastPurchaseDate = value; }
        }

        // methods
        public override void Input()
        {
            base.Input();
            Console.Write("Number of product purchased: ");
            iNumberOfProductsPurchased = Convert.ToInt32(Console.ReadLine());
            Console.Write("Point: ");
            iPoint = Convert.ToInt32(Console.ReadLine());
            Console.Write("Type of member: ");
            sTypeOfMember = Console.ReadLine();
            Console.WriteLine("Enter last purchase date:");
            Console.WriteLine("{");
            dLastPurchaseDate.Input();
            Console.WriteLine("}");
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Number of product purchased: " + iNumberOfProductsPurchased);            
            Console.WriteLine("Point: " + iPhoneNumber);
            Console.WriteLine("Type of member: " + sTypeOfMember);
            Console.WriteLine("Enter last purchase date:" + dLastPurchaseDate);
        }

        public override bool IsEquals(Person person)
        {
            return base.iID == person.ID;
        }
    }
}

