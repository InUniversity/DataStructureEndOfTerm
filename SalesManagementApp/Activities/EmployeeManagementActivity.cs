﻿using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using SalesManagementApp.Utilities;

namespace SalesManagementApp.Activities
{
    public static class EmployeeManagementActivity
    {
        public static int RunActivity()
        {
            SaleList employeeList = SaleData.saleList;
            Sale temp = new Sale();
            SaleList tempList = new  SaleList(employeeList.Capacity);
            Date Time = new Date();
            string id;
            int index;
            int choose = -100;
            while (true)
            {
                Console.Clear();
                Printer.PrintGroupInformation(80);
                Console.WriteLine("==============================MENU=============================");
                Console.WriteLine("|..........................EMPLOYEE..........................|");
                Console.WriteLine("|  1. Print employee list                                    |");
                Console.WriteLine("|  2. Add a employee to the last position                    |");
                Console.WriteLine("|  3. Add to a employee list                                 |");
                Console.WriteLine("|  4. Print the list of employees with the highest num sales |");
                Console.WriteLine("|  5. Print the list of employees with the highest sales     |");
                Console.WriteLine("|  6. Sort sales employee by birthday                        |");
                Console.WriteLine("|  7. Sale of employee by time                               |");
                Console.WriteLine("|  8. Bill of employee                                       |");
                Console.WriteLine("|  9. Back                                                   |");
                Console.WriteLine("|  10. Quit app                                               |");
                Console.WriteLine("=============================MENU=============================");
                Console.Write("Choose: "); 
                
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                switch (choose)
                {
                    case 1:
                        Console.WriteLine(".........................................Print employee list.........................................");
                        employeeList.Print();
                        Console.WriteLine(".....................................................................................................");
                        break;
                    case 2:
                        Console.WriteLine("............Add a employee to the last position...........");
                        Console.WriteLine("Insert the information of employee");
                        temp = new Sale();
                        temp.Input();
                        Console.WriteLine("..........................................................");
                        employeeList.AddLast(temp);
                        Console.WriteLine("Complete...");
                        Console.WriteLine("..........................................................");
                        break;
                    case 3:
                        tempList = new SaleList(employeeList.Capacity);
                        Console.WriteLine("..................Add to a employee list.................");
                        Console.WriteLine("Insert number of member: ");
                        int no = Convert.ToInt32(Console.ReadLine());
                        for(int i = 0; i<no; i++)
                        {
                            Console.WriteLine("No: " + (i + 1));
                            temp = new Sale();
                            Console.WriteLine("..........................................................");
                            temp.Input();
                            Console.WriteLine("..........................................................");
                            tempList.AddLast(temp);
                        }    
                        employeeList.AddRange(tempList);
                        Console.WriteLine("Complete...");
                        Console.WriteLine("..........................................................");
                        break;
                    case 4:
                        Console.WriteLine("..............Print the list of employees with the highest num sales.............");
                        Console.WriteLine("Insert time: ");
                        Time = new Date();
                        Console.Write("Month: "); Time.Month = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Year : "); Time.Year = Convert.ToInt32(Console.ReadLine());
                        tempList =  employeeList.BestNoSaler(Time.Month, Time.Year);
                        if (tempList == null)
                        {
                            Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                        }
                        else 
                            tempList.Print();
                        Console.WriteLine(".................................................................................");
                        break;
                    case 5:
                        Console.WriteLine("................Print the list of employees with the highest sales...............");
                        Console.WriteLine("Insert time: ");
                        Time = new Date();
                        Console.Write("Month: "); Time.Month = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Year : "); Time.Year = Convert.ToInt32(Console.ReadLine());
                        tempList =  employeeList.BestPriceSaler(Time.Month, Time.Year);
                        if (tempList == null)
                        {
                            Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                        }
                        else
                            tempList.Print();
                        Console.WriteLine(".................................................................................");
                        break;
                    case 6:
                        Console.WriteLine(".........................Sort sales employee by birthday.........................");
                        SaleList.SortByBirthDay(employeeList);
                        employeeList.Print();
                        Console.WriteLine(".................................................................................");
                        break;
                    case 7:
                        Console.WriteLine(".........................................Sale of employee by time.........................................");
                        Console.WriteLine("Insert time: ");
                        Time = new Date();
                        Console.Write("Month: "); Time.Month = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Year : "); Time.Year = Convert.ToInt32(Console.ReadLine());
                        employeeList.NoSaleOfMonth(Time);
                        Console.WriteLine("..........................................................................................................");
                        break;
                    case 8:
                        Console.WriteLine(".........................Bill of employee.........................");
                        Console.WriteLine("Insert id of employee");
                        id = Console.ReadLine();
                        Console.WriteLine("Insert time: ");
                        Time = new Date();
                        Console.Write("Month: "); Time.Month = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Year : "); Time.Year = Convert.ToInt32(Console.ReadLine());
                        employeeList.BillOfSaleByTime(id,Time);
                        Console.WriteLine("..................................................................");
                        break;
                    case 9:
                        return Constant.MAIN_ACTIVITY;
                    case 10: 
                        return Constant.EXIT_APPLICATION;
                    default:
                        break;
                }
                Printer.Pause();
            }
        }
    }
    
}