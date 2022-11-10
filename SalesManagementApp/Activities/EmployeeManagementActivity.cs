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
            /*
            * Cho người dùng lựa chọn:
            * 1.
            * 2.
            * 3.
            */
            bool over, pressEnter;
            int choose = 1, key, x = 0, y = 0;
            do
            {
                over = false;
                Console.Clear();
                Console.Write("=========================MENU=========================\n");
                Console.Write("|1. Move to product management                       |\n");
                Console.Write("|2. Move to customer management                      |\n");
                Console.Write("|3. Move to employee management                      |\n");
                Console.Write("|4. Quit app                                         |\n");
                Console.Write("=========================MENU=========================\n");
                Console.Write("Choose: ");
                x = Console.CursorLeft;
                y = Console.CursorTop;
                do
                {
                    pressEnter = false;
                    Console.SetCursorPosition(x, y);
                    Console.Write(choose);
                    key = (int)Console.ReadKey().Key;
                    switch (key)
                    {
                        case Constant.UP_ARROW:
                            choose--;
                            if (choose < 0)
                                choose = 4;
                            break;
                        case Constant.DOWN_ARROW:
                            choose++;
                            if (choose > 4)
                                choose = 0;
                            break;
                        case Constant.ENTER_KEY:
                            pressEnter = true;
                            break;
                    }
                } while (!pressEnter);

                switch (choose)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        {
                            EmployeeList employeeList = EmployeeData.employeeList;
                            int Chose3;
                            Console.WriteLine("======================================MENU======================================");
                            Console.WriteLine("....................................EMPLOYEE....................................");
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
                            Console.WriteLine("======================================MENU======================================");
                            Console.Write("Choose: "); Chose3 = Convert.ToInt32(Console.ReadLine());
                            switch (Chose3)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("...........Print employee list...........");
                                        employeeList.Print();
                                        Console.WriteLine(".........................................");
                                        break; }
                                case 2:
                                    {
                                        int index;
                                        Console.WriteLine("...........Print employee with index...........");
                                        Console.Write("Insert index: "); index = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("...............................................");
                                        Console.WriteLine("The information of employee at " + index + ":");
                                        employeeList.Get(index);
                                        Console.WriteLine("...............................................");
                                        break; }
                                case 3:
                                    {
                                        Employee temp = new Employee();
                                        Console.WriteLine("...........Print index of employee...........");
                                        Console.WriteLine("Insert id of employee: "); temp.ID = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine(".............................................");
                                        Console.WriteLine("The The information of employee with id is: " + temp.ID + ": ");
                                        employeeList.IndexOf(temp);

                                        break; }
                                case 4:
                                    {
                                        Employee temp = new Employee();
                                        int index;
                                        Console.WriteLine("............Add a employee to any position...........");
                                        Console.WriteLine("Insert the information of employee");
                                        temp.Input();
                                        Console.WriteLine("Insert the index:");
                                        index = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine(".....................................................");
                                        employeeList.AddItem(index,temp);
                                        Console.WriteLine("Complete...");
                                        Console.WriteLine(".....................................................");
                                        break; }
                                case 5:
                                    {
                                        Employee temp = new Employee();
                                        Console.WriteLine("............Add a employee to the last position...........");
                                        Console.WriteLine("Insert the information of employee");
                                        temp.Input();
                                        Console.WriteLine("..........................................................");
                                        employeeList.AddLast(temp);
                                        Console.WriteLine("Complete...");
                                        Console.WriteLine(".........................................................."); 
                                        break; }
                                case 6:
                                    {
                                        EmployeeList temp = new EmployeeList(employeeList.Capacity);
                                        Console.WriteLine("..................Add to a employee list.................");
                                        Console.WriteLine("Insert the information of employees");
                                        temp.Input();
                                        Console.WriteLine("..........................................................");
                                        employeeList.AddRange(temp);
                                        Console.WriteLine("Complete...");
                                        Console.WriteLine(".........................................................."); 
                                        break; }
                                case 7:
                                    {
                                        int index;
                                        Console.WriteLine("...........Delete employee with index...........");
                                        Console.Write("Insert index: "); index = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("...............................................");
                                        employeeList.RemoveItem(index);
                                        Console.WriteLine("Complete...");
                                        Console.WriteLine("..............................................."); 
                                        break; }
                                case 8:
                                    {
                                        Console.WriteLine("..Print a list of employees who have worked for 30 days..");
                                        EmployeeList temp = employeeList.Full30days();
                                        temp.Print();
                                        Console.WriteLine(".........................................................");
                                        break; }
                                case 9:
                                    {
                                        Console.WriteLine("..Print the list of employees with the highest sales..");
                                        EmployeeList temp = employeeList.MaxNumberOfSales();
                                        temp.Print();
                                        Console.WriteLine("......................................................."); 
                                        break; }
                                case 10:
                                    {
                                        Console.WriteLine(".......Print the list of employees of the month........");
                                        EmployeeList temp = employeeList.EmployeeOfMonth();
                                        temp.Print();
                                        Console.WriteLine(".......................................................");
                                        break; }
                                case 11:
                                    
                                    {
                                        Console.WriteLine(".....Print a list of employees with insufficient sales......");
                                        EmployeeList temp = employeeList.NotReachingSales();
                                        temp.Print();
                                        Console.WriteLine("............................................................");
                                        break; }
                                case 12:
                                    {
                                       
                                        Console.WriteLine("..Print a list of employees who are absent beyond the specified date..");
                                        EmployeeList temp = employeeList.AbsenceBeyondTheNorm();
                                        temp.Print();
                                        Console.WriteLine("......................................................................");
                                        break; }
                                default:
                                    Console.WriteLine("Cancel!");
                                    break;
                            }    
                            break;
                        }
                    default:
                        over = true;
                        break;
                }
            } while (!over);
            return -1;
        }
    }
    
}

