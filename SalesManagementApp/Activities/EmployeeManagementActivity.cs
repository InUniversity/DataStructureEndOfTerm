﻿using SalesManagementApp.Database;
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
            EmployeeList employeeList = EmployeeData.employeeList;
            Employee temp = new Employee();
            EmployeeList tempList = new EmployeeList(employeeList.Capacity);
            int index;
            int choose = -100;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======================================MENU======================================");
                Console.WriteLine("|...................................EMPLOYEE...................................|");
                Console.WriteLine("|  1. Print employee list                                                      |");
                Console.WriteLine("|  2. Print employee with index                                                |");
                Console.WriteLine("|  3. Print index of employee                                                  |");
                Console.WriteLine("|  4. Add a employee to any position                                           |");
                Console.WriteLine("|  5. Add a employee to the last position                                      |");
                Console.WriteLine("|  6. Add to a employee list                                                   |");
                Console.WriteLine("|  7. Delete employee with index                                               |");
                Console.WriteLine("|  8. Print a list of employees who have worked for 30 days                    |");
                Console.WriteLine("|  9. Print the list of employees with the highest sales                       |");
                Console.WriteLine("| 10. Print the list of employees of the month                                 |");
                Console.WriteLine("| 11. Print a list of employees with insufficient sales                        |");
                Console.WriteLine("| 12. Print a list of employees who are absent beyond the specified date       |");
                Console.WriteLine("| 13. Back                                                                     |");
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
                        Console.WriteLine("...........Print employee with index...........");
                        Console.Write("Insert index: "); index = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("...............................................");
                        Console.WriteLine("The information of employee at " + index + ":");
                        employeeList.Get(index).Print();
                        Console.WriteLine("...............................................");
                        break;
                    case 3:
                        Console.WriteLine("...........Print index of employee...........");
                        Console.WriteLine("Insert id of employee: "); 
                        temp.ID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(".............................................");
                        Console.WriteLine("The The information of employee with id is: " + temp.ID + ": ");
                        Console.WriteLine(employeeList.IndexOf(temp)); 
                        break;
                    case 4:
                        Console.WriteLine("............Add a employee to any position...........");
                        Console.WriteLine("Insert the information of employee");
                        temp = new Employee();
                        temp.Input();
                        Console.WriteLine("Insert the index:");
                        index = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(".....................................................");
                        employeeList.AddItem(index, temp);
                        Console.WriteLine("Complete...");
                        Console.WriteLine(".....................................................");
                        break;
                    case 5:
                        Console.WriteLine("............Add a employee to the last position...........");
                        Console.WriteLine("Insert the information of employee");
                        temp = new Employee();
                        temp.Input();
                        Console.WriteLine("..........................................................");
                        employeeList.AddLast(temp);
                        Console.WriteLine("Complete...");
                        Console.WriteLine("..........................................................");
                        break;
                    case 6:
                        tempList = new EmployeeList(employeeList.Capacity);
                        Console.WriteLine("..................Add to a employee list.................");
                        Console.WriteLine("Insert the information of employees");
                        tempList = new EmployeeList(employeeList.Capacity);
                        tempList.Input();
                        Console.WriteLine("..........................................................");
                        employeeList.AddRange(tempList);
                        Console.WriteLine("Complete...");
                        Console.WriteLine("..........................................................");
                        break;
                    case 7:
                        Console.WriteLine("...........Delete employee with index...........");
                        Console.Write("Insert index: "); index = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("...............................................");
                        employeeList.RemoveItem(index);
                        Console.WriteLine("Complete...");
                        Console.WriteLine("...............................................");
                        break;
                    case 8:
                        Console.WriteLine("..Print a list of employees who have worked for 30 days..");
                        tempList = new EmployeeList(employeeList.Capacity);
                        tempList = employeeList.Full30days();
                        tempList.Print();
                        Console.WriteLine(".........................................................");
                        break;
                    case 9:
                        Console.WriteLine("..Print the list of employees with the highest sales..");
                        tempList = employeeList.MaxNumberOfSales();
                        tempList.Print();
                        Console.WriteLine(".......................................................");
                        break;
                    case 10:
                        Console.WriteLine(".......Print the list of employees of the month........");
                        tempList = new EmployeeList(employeeList.Capacity);
                        tempList = employeeList.EmployeeOfMonth();
                        tempList.Print();
                        Console.WriteLine(".......................................................");
                        break;
                    case 11:
                         Console.WriteLine(".....Print a list of employees with insufficient sales......");
                        tempList = new EmployeeList(employeeList.Capacity);
                        tempList = employeeList.NotReachingSales();
                         tempList.Print();
                         Console.WriteLine("............................................................");
                         break;
                    case 12:
                        Console.WriteLine("..Print a list of employees who are absent beyond the specified date..");
                        tempList = new EmployeeList(employeeList.Capacity);
                        tempList = employeeList.AbsenceBeyondTheNorm();
                        tempList.Print();
                        Console.WriteLine("......................................................................");
                        break;
                    case 13:
                        return 2;
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