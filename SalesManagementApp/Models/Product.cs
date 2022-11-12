using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.Models
{
    public class Product
    {
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
            this.DayStartedUsing = dDayStartedUsing;
            this.DateExpires = dDateExpires;
        }

        public Product()
        {
            dDayStartedUsing = new Date();
            dDateExpires = new Date();
        }

        public bool IsEqual(Product item)
        {
            if (this.iID == item.ID) return true;
            else return false;
        }

        public bool EqualNames(Product item)
        {
            if (this.sName == item.sName) return true;
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
        }

        public void Print()
        {
            Console.Write(this.iID); Console.Write("    ");
            Console.Write(this.sName); Console.Write("    ");
            Console.Write(this.iNumberOfProduct); Console.Write("           ");
            string dDayStartedUsing = (string)(this.dDayStartedUsing); Console.Write("    ");
            Console.Write(dDayStartedUsing); Console.Write("    ");
            string dDateExpires = (string)(this.dDateExpires); Console.Write("    ");
            Console.Write(dDateExpires); Console.Write("    ");
            Console.WriteLine();
        }
    }
}
