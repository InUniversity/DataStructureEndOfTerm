using System;
using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Models
{
    public class Customer : Person
    {

        // fields
        private int iPoint;
        private StringCustom sTypeOfMember;
        private LinkedLst<StringCustom> lPurchasedOrders;

        // constructor
        public Customer() : base()
        {
            lPurchasedOrders = new LinkedLst<StringCustom>();
        }

        public Customer(StringCustom sID, StringCustom sName, StringCustom sSex,
            Date dBirthday, StringCustom sAddress, StringCustom iPhoneNumber,
            int iPoint, StringCustom sTypeOfMember
            ) : base(sID, sName, sSex, dBirthday, sAddress, iPhoneNumber)
        {
            this.iPoint = iPoint;
            this.sTypeOfMember = sTypeOfMember;
        }

        // properties
        public int Point
        {
            get { return iPoint; }
            set { iPoint = value; }
        }

        public StringCustom TypeOfMember
        {
            get { return sTypeOfMember; }
            set { sTypeOfMember = value; }
        }

        public LinkedLst<StringCustom> PurchasedOrders
        {
            get { return lPurchasedOrders; }
        }

        // methods
        public int FindTotalOrderValueForMonth(int months, int years)
        {
            int sum = 0;
            Node<StringCustom>? head = PurchasedOrders.FirstItem;
            Bill bill;
            while (head != null)
            {
                bill = BillData.billHash.GetValue(head.item);
                if (bill.PurchaseDate.Month == months && bill.PurchaseDate.Year == years)
                    sum += bill.Price;
                head = head.next;
            }
            return sum;
        }
        
        public static bool IsValidID(StringCustom tempID)
        {
            return tempID != null &&
                tempID.CharAt(0) == 'C' &&
                tempID.CharAt(0) == 'U' &&
                tempID.CharAt(0) == 'S';
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Point: ");
            iPoint = Convert.ToInt32(Console.ReadLine());
            Console.Write("Type of member: ");
            sTypeOfMember = Console.ReadLine();
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Point: " + iPhoneNumber);
            Console.WriteLine("Type of member: " + sTypeOfMember);
            Console.WriteLine("Purchased orders:");
            Console.WriteLine("{");
            if (PurchasedOrders.IsEmpty())
                Console.WriteLine(Constant.EMPTY_MESSAGE);
            PrintPurchasedOrders();
            Console.WriteLine("}");
        }

        public void PrintPurchasedOrders()
        {
            Node<StringCustom> head = lPurchasedOrders.FirstItem;
            while (head != null)
            {
                Console.WriteLine("Bill ID: {0}", head.item);
                head = head.next;
            }
        }

        public override bool IsEquals(Person person)
        {
            return base.sID == person.ID;
        }
    }
}

