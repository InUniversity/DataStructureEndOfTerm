using System;
namespace SalesManagementApp.Models
{
    public class Date
    {
        
        private int iDay;
        private int iMonth;
        private int iYear;

        public int IDay
        {
            get { return iDay; }
            set { iDay = value; }
        }

        public int IMonth
        {
            get { return iMonth; }
            set { iMonth = value; }
        }

        public int IYear
        {
            get { return iYear; }
            set{iYear = value;}
        }

        public Date(int iDay, int iMonth, int iYear)
        {
            IDay = iDay;
            IMonth = iMonth;
            IYear = iYear;
        }

        // methods
        public void Input()
        {
            Console.WriteLine("Enter Date:");
            Console.Write("Day: ");
            iDay = Convert.ToInt32(Console.ReadLine());
            Console.Write("Month: ");
            iMonth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Year: ");
            iYear = Convert.ToInt32(Console.ReadLine());
        }

        public static implicit operator string(Date date)
        {
            return date.iDay + "-" + date.iMonth + "-" + date.iYear;
        }
    }
}

