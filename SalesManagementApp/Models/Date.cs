using System;
using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Models
{
    public class Date
    {

        private int iDay;
        private int iMonth;
        private int iYear;

        public int Day
        {
            get { return iDay; }
            set { iDay = value; }
        }

        public int Month
        {
            get { return iMonth; }
            set { iMonth = value; }
        }

        public int Year
        {
            get { return iYear; }
            set { iYear = value; }
        }

        public Date()
        {

        }

        public Date(int iDay, int iMonth, int iYear)
        {
            Day = iDay;
            Month = iMonth;
            Year = iYear;
        }

        public void Input()
        {
            Console.WriteLine("Enter Date:");
            Console.Write("Day: ");
            Day = Convert.ToInt32(Console.ReadLine());
            Console.Write("Month: ");
            Month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Year: ");
            Year = Convert.ToInt32(Console.ReadLine());
        }

        public static implicit operator string(Date date)
        {
            int day = date.Day, month = date.Month, year = date.Year;
            string result = "";
            if (day < 10)
                result += ("0" + day);
            else
                result += day;
            result += "-";

            if (month < 10)
                result += ("0" + month);
            else
                result += month;
            result += "-";

            // fix "yyyy = 0230"
            result += year;
            return result;
        }

        public static explicit operator Date(StringCustom date)
        {
            int day = (((date.CharAt(0)) - '0') * 10) + ((date.CharAt(1)) - '0');
            int month = (date.CharAt(3) - '0') * 10 + (date.CharAt(4) - '0');
            int year = (((date.CharAt(6) - '0') * 10 + (date.CharAt(7) - '0')) * 10 + 
                (date.CharAt(8) - '0')) * 10 + (date.CharAt(9) - '0');
            return new Date(day, month, year);
        }

        public static bool operator >(Date a, Date b)
        {
            if (a.Year > b.Year)
                return true;
            else if (a.Year == b.Year)
            {
                if (a.Month > b.Month)
                    return true;
                else if (b.Month == a.Month)
                {
                    if (a.Day > b.Day)
                        return true;
                }
            }
            return false;
        }

        public static bool operator >=(Date a, Date b)
        {
            return !(a < b);
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
                }
            }
            return false;
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

        public override string ToString()
        {
            return this;
        }
    }
}

