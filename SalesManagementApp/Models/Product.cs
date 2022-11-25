using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Models
{
    public class Product
    {
        private int iID;
        private StringCustom sName;
        private int iNumberOfProduct;
        private Date dDayStartedUsing;
        private Date dDateExpires;
        private int iPrice;

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

        public Product(int iID, StringCustom sName, int iNumberOfProduct, Date dDayStartedUsing, Date dDateExpires,int iPrice)
        {

            this.iID = iID;
            this.sName = sName;
            this.iNumberOfProduct = iNumberOfProduct;
            this.DayStartedUsing = dDayStartedUsing;
            this.DateExpires = dDateExpires;
            this.iPrice=iPrice;
        }

        public bool IsEqual(Product item)
        {
            if (this.iID == item.ID) return true;
            else return false;
        }

        public void Input()
        {
            Console.WriteLine("ID:");
            this.iID = Convert.ToInt32(Console.ReadLine());
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
            Console.WriteLine(this.iID);
            Console.WriteLine(this.sName);
            Console.WriteLine(this.iNumberOfProduct);
            Console.WriteLine(this.dDayStartedUsing);
            Console.WriteLine(this.dDateExpires);
            Console.WriteLine(this.iPrice);
        }
    }
}
