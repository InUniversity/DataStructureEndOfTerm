using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Models
{
    public class Product
    {
        private StringCustom sID;
        private StringCustom sName;
        private int iNumberOfProduct;
        private Date dDayStartedUsing;
        private Date dDateExpires;
        private int iPrice;

        public StringCustom ID
        {
            get { return sID; }
            set { sID = value; }
        }

        public StringCustom Name
        {
            get { return sName; }
            set { sName = value; }
        }

        public int NumberOfProduct
        {
            get { return iNumberOfProduct; }
            set { iNumberOfProduct = value; }
        }

        public Date DayStartedUsing
        {
            get { return dDayStartedUsing; }
            set { dDayStartedUsing = value; }
        }

        public Date DateExpires
        {
            get { return dDateExpires; }
            set { dDateExpires = value; }
        }

        public int Price
        {
            get { return iPrice; }
            set { iPrice = value; }
        }

        public Product()
        {
            dDayStartedUsing = new Date();
            dDateExpires = new Date();
        }

        public Product(StringCustom iID, StringCustom sName, int iNumberOfProduct, Date dDayStartedUsing, Date dDateExpires,int iPrice)
        {

            this.sID = iID;
            this.sName = sName;
            this.iNumberOfProduct = iNumberOfProduct;
            this.DayStartedUsing = dDayStartedUsing;
            this.DateExpires = dDateExpires;
            this.iPrice=iPrice;
        }

        public bool IsEqual(Product item)
        {
            if (this.sID.ToInt() == item.ID.ToInt()) return true;
            else return false;
        }

        public void Input()
        {
            Console.WriteLine("ID:");
            this.sID = Console.ReadLine();
            Console.WriteLine("Name:");
            this.sName = (Console.ReadLine());
            Console.WriteLine("iNumberOfProduct:");
            this.iNumberOfProduct = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("dDayStartedUsing:");
            this.dDayStartedUsing.Input();
            Console.WriteLine("dDateExpires:");
            this.dDateExpires.Input();
            Console.WriteLine("Enter price:");
            this.iPrice = Convert.ToInt32(Console.ReadLine());
        }

        public void Print()
        {
            Console.WriteLine(this.sID);
            Console.WriteLine(this.sName);
            Console.WriteLine(this.iNumberOfProduct);
            Console.WriteLine(this.dDayStartedUsing);
            Console.WriteLine(this.dDateExpires);
            Console.WriteLine(this.iPrice);
        }
    }
}
