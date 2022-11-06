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

        public Product()
        {

        }

        public Product(int iID, string sname, int iNumberOfProduct, Date dDayStartedUsing, Date dDateExpires)
        {
            this.iID = iID;
            this.sName = sname;
            this.iNumberOfProduct = iNumberOfProduct;

            this.DayStartedUsing.Day = dDayStartedUsing.Day;
            this.DayStartedUsing.Month = dDayStartedUsing.Month;
            this.DayStartedUsing.Year = dDayStartedUsing.Year;

            this.dDateExpires.Day = dDayStartedUsing.Day;
            this.dDateExpires.Month = dDayStartedUsing.Month;
            this.dDateExpires.Year = dDayStartedUsing.Year;
        }

        public bool IsEqual(Product item)
        {
            if (this.iID == item.ID) return true;
            else return false;
        }


        public bool CheckProduct(Product a, Date Today)
        {
            if (a.DateExpires > Today)
                return false;
            else
            {
                
            }
            return true;
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
        }

        public void Print()
        {
            Console.WriteLine("ID:" + this.iID);
            Console.WriteLine("Name:" + this.sName);
            Console.WriteLine("iNumberOfProduct:" + this.iNumberOfProduct);
            Console.WriteLine("dDayStartedUsing:");
            Console.WriteLine(this.dDayStartedUsing.Day);
            Console.WriteLine(this.dDayStartedUsing.Month);
            Console.WriteLine(this.dDayStartedUsing.Year);
            Console.WriteLine("dDateExpires:");
            Console.WriteLine(this.DateExpires.Day);
            Console.WriteLine(this.DateExpires.Month);
            Console.WriteLine(this.DateExpires.Year);
        }

    }
}
