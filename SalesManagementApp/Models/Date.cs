﻿using System;
using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Models
{
    public class Date
    {

        private int iDay;
        private int iMonth;
        private int iYear;
        private int iHour;
        private int iMinute;
        private int iSecond;

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

        public int Hour
        {
            get { return iHour; }
            set { iHour = value; }
        }

        public int Minute
        {
            get { return iMinute; }
            set { iMinute = value; }
        }

        public int Second
        {
            get { return iSecond; }
            set{ iSecond = value;}
        }

        public Date()
        {

        }

        public Date(int iDay, int iMonth, int iYear, int iHour, int iMinute, int iSecond)
        {
            this.Day = iDay;
            this.Month = iMonth;
            this.Year = iYear;
            this.Hour = iHour;
            this.Minute = iMinute;
            this.Second = iSecond;
        }

        public Date(int iDay, int iMonth, int iYear)
        {
            this.Day = iDay;
            this.Month = iMonth;
            this.Year = iYear;
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
            Console.Write("Hour: ");
            Hour = Convert.ToInt32(Console.ReadLine());
            Console.Write("Minute: ");
            Minute = Convert.ToInt32(Console.ReadLine());
            Console.Write("Second: ");
            Second = Convert.ToInt32(Console.ReadLine());
        }

        public static implicit operator string(Date date)
        {
            int day = date.Day, month = date.Month, year = date.Year;
            int hour = date.Hour, minute = date.Minute, second = date.Second;
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
            result += year;
            result +=" ";
            if (hour < 10)
                result += ("0" + hour);
            else
                result += hour;
            result += ":";
            if (minute < 10)
                result += ("0" + minute);
            else
                result += minute;
            result += ":";
            if (second < 10)
                result += ("0" + second);
            else
                result += second;
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
            if(a.Year < b.Year)
                return false;
            if (a.Month > b.Month)
                return true;
            if (a.Month < b.Month)
                return false;
            if (a.Day > b.Day)
                return true;
            if (a.Day < b.Day)
                return false;
            if (a.Hour > b.Hour)
                return true;
            if (a.Hour < b.Hour)
                return false;
            if (a.Minute > b.Minute)
                return true;
            if (a.Minute < b.Minute)
                return false;
            if (a.Second > b.Second)
                return true;
            if (a.Second < b.Second)
                return false;
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
            if (a.Year > b.Year)
                return false;
            if (a.Month < b.Month)
                return true;
            if (a.Month > b.Month)
                return false;
            if (a.Day < b.Day)
                return true;
            if (a.Day > b.Day)
                return false;
            if (a.Hour < b.Hour)
                return true;
            if (a.Hour > b.Hour)
                return false;
            if (a.Minute < b.Minute)
                return true;
            if (a.Minute > b.Minute)
                return false;
            if (a.Second < b.Second)
                return true;
            if (a.Second > b.Second)
                return false;
            return false;
        }

        public static bool operator <=(Date a, Date b)
        {
            return !(a > b);
        }

        public static bool operator ==(Date a, Date b)
        {
            if ((a.Year == b.Year) && (a.Month == b.Month) && (a.Day == b.Day) && (a.Hour == b.Hour) && (a.Minute == b.Minute) && (a.Second == b.Second))
                return true;
            return false;
        }

        public static bool operator !=(Date a, Date b)
        {
            if ((a.Year != b.Year) || (a.Month != b.Month) || (a.Day != b.Day) || (a.Hour != b.Hour) || (a.Minute != b.Minute) || (a.Second != b.Second))
                return true;
            return false;
        }

        public override string ToString()
        {
            return this;
        }

        public static Date GetCurrentDate()
        {
            
            DateTime dateTime = DateTime.UtcNow.Date;
            DateTime dateTimeOfDay = DateTime.Now;
            return new Date(
                dateTime.Day, 
                dateTime.Month,
                dateTime.Year,
                dateTimeOfDay.Hour,
                dateTimeOfDay.Minute,
                dateTimeOfDay.Second);
        }

        public void Print()
        {
            Console.WriteLine("Day:"+this.Day);
            Console.WriteLine("Month:" + this.Month);
            Console.WriteLine("Year:" + this.Year);
            Console.WriteLine("Hour:" + this.Hour);
            Console.WriteLine("Minute:" + this.Minute);
            Console.WriteLine("Second:" + this.Second);
        }

    }
}

