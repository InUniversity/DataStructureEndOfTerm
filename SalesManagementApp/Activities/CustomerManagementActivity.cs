using System;
using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;
using SalesManagementApp.Utilities;

namespace SalesManagementApp.Activities
{
    public static class CustomerManagementActivity
    {

        public static int RunActivity()
        {
            CustomerHash customerHash = CustomerData.customerHash;
            CustomerHash tempHash;
            Customer tempCustomer;
            StringCustom tempStr, tempStr1;
            int months, years;
            int choose = 10;
            while (true)
            {
                Console.Clear();
                Printer.PrintGroupInformation(70);
                Console.Write("===========================MENU===========================\n");
                Console.Write("| 1. Add a customer                                      |\n");
                Console.Write("| 2. Display customer list                               |\n");
                Console.Write("| 3. Find customer with the largest order price of months|\n");
                Console.Write("| 4. Find by ID                                          |\n");
                Console.Write("| 5. Find by Name                                        |\n");
                Console.Write("| 6. Find by member type                                 |\n");
                Console.Write("| 7. Find by gender and member type                      |\n");
                Console.Write("| 8. Write file                                          |\n");
                Console.Write("| 9. Reload customer data                                |\n");
                Console.Write("|10. Group by gender                                     |\n");
                Console.Write("|11. Back to Main activity                               |\n");
                Console.Write("| 0. Quit app                                            |\n");
                Console.Write("===========================MENU===========================\n");
                Console.Write("Choose: ");
                try { choose = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception e) { Console.WriteLine(e.Message); }
                Console.WriteLine();

                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Enter customer: ");
                        tempCustomer = new Customer();
                        tempCustomer.Input();
                        customerHash.InsertNoDuplicate(tempCustomer);
                        customerHash.Print();
                        break;
                    case 2:
                        if (customerHash.IsEmpty())
                        {
                            Console.WriteLine(Constant.EMPTY_MESSAGE);
                            break;
                        }
                        customerHash.Print();
                        break;
                    case 3:
                        Console.Write("Enter months: ");
                        months = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter years: ");
                        years = Convert.ToInt32(Console.ReadLine());
                        tempCustomer = customerHash.FindCustomerWithLargestOrderPriceOfMonths(months, years);
                        if (tempCustomer == null)
                        {
                            Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                            break;
                        }
                        tempCustomer.Print();
                        break;
                    case 4:
                        Console.Write("Enter ID: ");
                        tempStr = Console.ReadLine();
                        tempCustomer = customerHash.GetValue(tempStr);
                        if (tempCustomer == null)
                        {
                            Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                            break;
                        }
                        tempCustomer.Print();
                        break;
                    case 5:
                        Console.Write("Enter name: ");
                        tempStr = Console.ReadLine();
                        tempHash = customerHash.FindByName(tempStr);
                        if (tempHash.IsEmpty())
                        {
                            Console.WriteLine(Constant.EMPTY_MESSAGE);
                            break;
                        }
                        tempHash.Print();
                        break;
                    case 6:
                        Console.Write("Enter member type: ");
                        tempStr = Console.ReadLine();
                        tempHash = customerHash.FindByMemberType(tempStr);
                        if (tempHash.IsEmpty())
                        {
                            Console.WriteLine(Constant.EMPTY_MESSAGE);
                            break;
                        }
                        tempHash.Print();
                        break;
                    case 7:
                        Console.Write("Enter gender: ");
                        tempStr = Console.ReadLine();
                        Console.Write("Enter member type: ");
                        tempStr1 = Console.ReadLine();
                        tempHash = customerHash.FindByGenderAndMemberType(tempStr, tempStr1);
                        if (tempHash.IsEmpty())
                        {
                            Console.WriteLine(Constant.EMPTY_MESSAGE);
                            break;
                        }
                        tempHash.Print();
                        break;
                    case 8:
                        Console.WriteLine("Enter file name: ");
                        tempStr = Console.ReadLine();
                        if (!tempStr.IsEquals("CustomerData.txt") && !customerHash.WriteFile(tempStr))
                            Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                        else
                        {
                            Console.WriteLine(Constant.SUCCESS_MESSAGE);
                            customerHash.Print();
                        }
                        break;
                    case 9:
                        tempStr = "CustomerData.txt";
                        Console.WriteLine("File name: " + tempStr);
                        if (!customerHash.AddFromFile(tempStr))
                            Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                        else
                        {
                            Console.WriteLine(Constant.SUCCESS_MESSAGE);
                            customerHash.Print();
                        }
                        break;
                    case 10:
                        customerHash.SortByGender();
                        break;
                    case 11:
                        return Constant.MAIN_ACTIVITY;
                    case 0:
                        return Constant.EXIT_APPLICATION;
                    default:
                        Console.WriteLine(Constant.NOT_VALID_MESSAGE);
                        break;
                }
                Printer.Pause();
            }
        }
    }
}