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
        
        public static bool operator >(Date a, Date b)
        {
            if (a.Year > b.Year)
                return true;
            else if(a.Year == b.Year)
            {
                if (a.Month > b.Month)
                    return true;
                else if(b.Month == a.Month)
                {
                    if (a.Day > b.Day)
                        return true;
                    else return false;
                }
                else return false;
            }   
            else return false;
        }
        
        public static bool operator >=(Date a, Date b)
        {
            return !(a < b);
        }

        public static implicit operator string(Date date)
        {
            return date.iDay + "-" + date.iMonth + "-" + date.iYear;
        }

        public static bool operator <(Date a, Date b)
        {
            if (a.Year < b.Year)
                return true;
            else if (a.Year == b.Year)
            {
                if (a.Month < b.Month)
                    return true;
                else if (b.Month == a.Month)
                {
                    if (a.Day < b.Day)
                        return true;
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        
        public static bool operator <=(Date a, Date b)
        {
            return !(a > b);
        }

        public static bool operator ==(Date a, Date b)
        {
            if ((a.Year == b.Year) && (a.Month == b.Month) && (a.Day == b.Day))
                return true;
            return false;
        }

        public static bool operator !=(Date a, Date b)
        {
            if ((a.Year != b.Year) || (a.Month != b.Month) || (a.Day != b.Day))
                return true;
            return false;
        }
        
        public override string ToSring()
        {
            return this;
        }
    }
}

