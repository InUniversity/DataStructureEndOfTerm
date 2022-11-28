using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

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
                Console.WriteLine("|  4. Delete a employee                                                        |");
                Console.WriteLine("|  5. Print the list of employees with the highest num sales                   |");
                Console.WriteLine("|  6. Print the list of employees with the highest sales                       |");
                Console.WriteLine("|  7. Sort sales employee by birthday                                          |");
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
                        employeeList.Print();
                        Console.WriteLine(".........................................");
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
                        Console.WriteLine("Insert the information of employees");
                        tempList = new SaleList(employeeList.Capacity);
                        tempList.Input();
                        Console.WriteLine("..........................................................");
                        employeeList.AddRange(tempList);
                        Console.WriteLine("Complete...");
                        Console.WriteLine("..........................................................");
                        break;
                    case 4:
                        Console.WriteLine("...........................Delete a employee...........................");
                        Console.WriteLine("Input id: "); StringCustom id = Console.ReadLine();
                        employeeList.DeleteSale(id);
                        Console.WriteLine(".......................................................................");
                        break;
                    case 5:
                        Console.WriteLine("..............Print the list of employees with the highest num sales.............");
                        Console.WriteLine("Insert time: ");
                        Console.Write("Month: "); Time.Month = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Year : "); Time.Year = Convert.ToInt32(Console.ReadLine());
                        employeeList.BestNoSaler(Time.Month, Time.Year);
                        Console.WriteLine(".................................................................................");
                        break;
                    case 6:
                        Console.WriteLine("................Print the list of employees with the highest sales...............");
                        Console.WriteLine("Insert time: ");
                        Console.Write("Month: "); Time.Month = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Year : "); Time.Year = Convert.ToInt32(Console.ReadLine());
                        employeeList.BestPriceSaler(Time.Month, Time.Year);
                        Console.WriteLine(".................................................................................");
                        break;
                    case 7:
                        Console.WriteLine(".........................Sort sales employee by birthday.........................");
                        SaleList.SortByBirthDay(employeeList);
                        employeeList.Print();
                        Console.WriteLine(".................................................................................");
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