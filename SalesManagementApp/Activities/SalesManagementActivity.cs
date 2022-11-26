using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace SalesManagementApp.Activities
{
    public static class SalesManagementActivity
    {
        public static int RunActivity()
        {
            SaleList saleList = SaleData.SaleList;
            Sale temp = new Sale();
            SaleList tempList = new  SaleList(saleList.Capacity);
            Date Time = new Date();
            int index;
            int choose = -100;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======================================MENU======================================");
                Console.WriteLine("|...................................EMPLOYEE...................................|");
                Console.WriteLine("|  1. Print employee list                                                      |");
                Console.WriteLine("|  2. Add a employee to the last position                                      |");
                Console.WriteLine("|  3. Add to a employee list                                                   |");
                Console.WriteLine("|  4. Print a list of employees who have worked for 30 days                    |");
                Console.WriteLine("|  5. Print the list of employees with the highest sales                       |");
                Console.WriteLine("|  6. Print the list of employees of the month                                 |");
                Console.WriteLine("|  7. Print a list of employees with insufficient sales                        |");
                Console.WriteLine("|  8. Back                                                                     |");
                Console.WriteLine("|  9. Quit app                                                                 |");
                Console.WriteLine("======================================MENU======================================");
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
                        Console.WriteLine("...........Print employee list...........");
                        saleList.Print();
                        Console.WriteLine(".........................................");
                        break;
                    case 2:
                        Console.WriteLine("............Add a employee to the last position...........");
                        Console.WriteLine("Insert the information of employee");
                        temp = new Sale();
                        temp.Input();
                        Console.WriteLine("..........................................................");
                        saleList.AddLast(temp);
                        Console.WriteLine("Complete...");
                        Console.WriteLine("..........................................................");
                        break;
                    case 3:
                        tempList = new SaleList(saleList.Capacity);
                        Console.WriteLine("..................Add to a employee list.................");
                        Console.WriteLine("Insert the information of employees");
                        tempList = new SaleList(saleList.Capacity);
                        tempList.Input();
                        Console.WriteLine("..........................................................");
                        saleList.AddRange(tempList);
                        Console.WriteLine("Complete...");
                        Console.WriteLine("..........................................................");
                        break;
                    case 4:
                        Console.WriteLine("..Print a list of employees who have worked for 30 days..");
                        tempList = new SaleList(saleList.Capacity);
                        Console.WriteLine("Input time: ");
                        Time.Input();
                        tempList = saleList.Full30days(Time);
                        tempList.Print();
                        Console.WriteLine(".........................................................");
                        break;
                    case 5:
                        Console.WriteLine("..Print the list of employees with the highest sales..");
                        Console.WriteLine("Input time: ");
                        Time.Input();
                        tempList = saleList.MaxNumberOfSales(Time);
                        tempList.Print();
                        Console.WriteLine(".......................................................");
                        break;
                    case 6:
                        Console.WriteLine(".......Print the list of employees of the month........");
                        tempList = new SaleList(saleList.Capacity);
                        Console.WriteLine("Input time: ");
                        Time.Input();
                        tempList = saleList.EmployeeOfMonth(Time);
                        tempList.Print();
                        Console.WriteLine(".......................................................");
                        break;
                    case 7:
                         Console.WriteLine(".....Print a list of employees with insufficient sales......");
                        tempList = new SaleList(saleList.Capacity);
                        Console.WriteLine("Input time: ");
                        Time.Input();
                        tempList = saleList.NotReachingSales(Time);
                        tempList.Print();
                        Console.WriteLine("............................................................");
                        break;
                    
                    case 8:
                        return 2;
                    case 9: 
                        return -1;
                    default:
                        Console.WriteLine("Cancel!");
                        break;
                }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadKey();
            }
        }
    }
    
}