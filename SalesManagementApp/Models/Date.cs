﻿using System;
namespace SalesManagementApp.Models
{
    public class Date
    {

        private int iDay;
        private int iMonth;
        private int iYear;
        //
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

        public Date(int iDay, int iMonth, int iYear)
        {
            Day = iDay;
            Month = iMonth;
            Year = iYear;
        }

        // methods
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
            if (a.Year >= b.Year)
            {
                if(a.Year==b.Year)
                {
                    if (a.Month >= b.Month)
                    {
                        if (a.Month == b.Month)
                        {
                            if (a.Day >= b.Day)
                            {
                                return true;
                            }
                            else return false;
                        }
                        else return true;
                    }
                    else return false;
                    
                }
                else return true;
            }
            return false;
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
            if (a.Year <= b.Year)
            {
                if (a.Year == b.Year)
                {
                    if (a.Month <= b.Month)
                    {
                        if (a.Month == b.Month)
                        {
                            if (a.Day <= b.Day)
                            {
                                return true;
                            }
                            else return false;
                        }
                        else return true;
                    }
                    else return false;

                }
                else return true;
            }
            else return false;
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

    }
}

