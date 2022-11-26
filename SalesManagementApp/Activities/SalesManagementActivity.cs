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
                        employeeList.Print();
                        Console.WriteLine(".........................................");
                        break;
                    case 2:
                        Console.WriteLine("............Add a employee to the last position...........");
                        Console.WriteLine("Insert the information of employee");
                        temp = new Employee();
                        temp.Input();
                        Console.WriteLine("..........................................................");
                        employeeList.AddLast(temp);
                        Console.WriteLine("Complete...");
                        Console.WriteLine("..........................................................");
                        break;
                    case 3:
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
                    case 4:
                        Console.WriteLine("..Print a list of employees who have worked for 30 days..");
                        tempList = new EmployeeList(employeeList.Capacity);
                        tempList = employeeList.Full30days();
                        tempList.Print();
                        Console.WriteLine(".........................................................");
                        break;
                    case 5:
                        Console.WriteLine("..Print the list of employees with the highest sales..");
                        tempList = employeeList.MaxNumberOfSales();
                        tempList.Print();
                        Console.WriteLine(".......................................................");
                        break;
                    case 6:
                        Console.WriteLine(".......Print the list of employees of the month........");
                        tempList = new EmployeeList(employeeList.Capacity);
                        tempList = employeeList.EmployeeOfMonth();
                        tempList.Print();
                        Console.WriteLine(".......................................................");
                        break;
                    case 7:
                         Console.WriteLine(".....Print a list of employees with insufficient sales......");
                        tempList = new EmployeeList(employeeList.Capacity);
                        tempList = employeeList.NotReachingSales();
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