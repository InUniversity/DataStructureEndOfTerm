using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.Models
{
    public class Product
    {

        // fields: (iID: int, sName: string, iNumberOfProduct: int,  dDayStartedUsing: Date, dDateExpires: Date)
        private int iID;
        private string sName;
        private int iNumberOfProduct;
        private Date dDayStartedUsing;
        private Date dDateExpires;

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

        public Product(int iID, string sname, int iNumberOfProduct, Date dDayStartedUsing, Date dDateExpires)
        {
            this.iID = iID;
            this.sName = sname;
            this.iNumberOfProduct = iNumberOfProduct;
            this.DayStartedUsing.IDay = dDayStartedUsing.IDay;
            this.DayStartedUsing.IMonth = dDayStartedUsing.IMonth;
            this.DayStartedUsing.IYear = dDayStartedUsing.IYear;

            this.dDateExpires.IDay = dDayStartedUsing.IDay;
            this.dDateExpires.IMonth = dDayStartedUsing.IMonth;
            this.dDateExpires.IYear = dDayStartedUsing.IYear;
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
            this.dDayStartedUsing.IDay = Convert.ToInt32(Console.ReadLine());
            this.dDayStartedUsing.IMonth = Convert.ToInt32(Console.ReadLine());
            this.dDayStartedUsing.IYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("dDateExpires:");
            this.dDateExpires.IDay = Convert.ToInt32(Console.ReadLine());
            this.dDateExpires.IMonth = Convert.ToInt32(Console.ReadLine());
            this.dDateExpires.IYear = Convert.ToInt32(Console.ReadLine());
        }

        public void Print()
        {
            Console.WriteLine("ID:" + this.iID);
            Console.WriteLine("Name:" + this.sName);
            Console.WriteLine("iNumberOfProduct:" + this.iNumberOfProduct);
            Console.WriteLine("dDayStartedUsing:" + this.dDayStartedUsing.IDay);
            Console.WriteLine("dDayStartedUsing:" + this.dDayStartedUsing.IMonth);
            Console.WriteLine("dDayStartedUsing:" + this.dDayStartedUsing.IYear);

            Console.WriteLine("dDateExpires:");
            Console.WriteLine("dDateExpires:" + this.dDateExpires.IDay);
            Console.WriteLine("dDateExpires:" + this.dDateExpires.IMonth);
            Console.WriteLine("dDateExpires:" + this.dDateExpires.IYear);
        }
    }
}
