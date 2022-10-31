using System;
namespace SalesManagementApp.Models
{
    public class Manager
    {
        public Manager Manager1 = new Manager(12,"LeTan");





        // fields: (iID: int, sName: string, iNumberOfProduct: int,  dDayStartedUsing: Date, dDateExpires: Date)
        private int iID;
        private string sname;
        private int iNumberOfProduct;
        private Date dDayStartedUsing;
        private Date dDateExpires;

        public int ID
        {
            get { return iID; }
            set { iID = value; }
        }
        public string Sname
        {
            get { return sname; }
            set { sname = value; }
        }
        public int INumberOfProduct
        {
            get { return iNumberOfProduct; }
            set { iNumberOfProduct = value; }
        }
        public Date DDayStartedUsing
        {
            get { return dDayStartedUsing; }
            set { dDayStartedUsing = value; }
        }
        public Date DDateExpires
        {
            get { return dDateExpires; }
            set { dDateExpires = value; }
        }
        public Manager(int iID,string sname, int iNumberOfProduct,Date dDayStartedUsing, Date dDateExpires )
        {
            this.iID = iID;
            this.sname = sname;
            this.iNumberOfProduct = iNumberOfProduct;
            this.DDayStartedUsing.IDay = dDayStartedUsing.IDay;
            this.DDayStartedUsing.IMonth = dDayStartedUsing.IMonth;
            this.DDayStartedUsing.IYear = dDayStartedUsing.IYear;

            this.dDateExpires.IDay= dDayStartedUsing.IDay;
            this.dDateExpires.IMonth = dDayStartedUsing.IMonth;
            this.dDateExpires.IYear = dDayStartedUsing.IYear;
        }
        public Manager(int iID, string sname)
        {
            this.iID = iID;
            this.sname = sname;
            
        }
        public Manager(int iID)
        {
            this.iID = iID;

        }
        public void nhap()
        {
            Console.WriteLine("ID:");
            this.iID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Name:");
            this.sname = (Console.ReadLine());
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
        public void xuat()
        {
            Console.WriteLine("ID:" + this.iID);
            Console.WriteLine("Name:" + this.sname);
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


