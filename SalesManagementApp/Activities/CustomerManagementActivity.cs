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
            Date date;
            int months, years;
            int choose = 10;
            while (true)
            {
                Console.Clear();
                Printer.PrintGroupInformation(80);
                Console.Write("===========================MENU===========================\n");
                Console.Write("| 1. Add a customer                                      |\n");
                Console.Write("| 2. Delete customer with ID                             |\n");
                Console.Write("| 3. Display customer list                               |\n");
                Console.Write("| 4. Sort by LAST purchased date                         |\n");
                Console.Write("| 5. Find customer with the largest order price of months|\n");
                Console.Write("| 6. Find by ID                                          |\n");
                Console.Write("| 7. Find by Name                                        |\n");
                Console.Write("| 8. Find by member type                                 |\n");
                Console.Write("| 9. Find by sex and member type                         |\n");
                Console.Write("|10. Write file                                          |\n");
                Console.Write("|11. Reload customer data                                |\n");
                Console.Write("|12. Group by gender                                     |\n");
                Console.Write("|13. Back to Main activity                               |\n");
                Console.Write("| 0. Quit app                                            |\n");
                Console.Write("===========================MENU===========================\n");
                Console.Write("Choose: ");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
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
                        Console.Write("Enter ID: ");
                        tempStr = Console.ReadLine();
                        tempCustomer = customerHash.GetValue(tempStr);
                        if (tempCustomer == null)
                        {
                            Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                            break;
                        }
                        customerHash.Remove(tempCustomer.ID);
                        customerHash.Print();
                        break;
                    case 3:
                        if (customerHash.IsEmpty())
                        {
                            Console.WriteLine(Constant.EMPTY_MESSAGE);
                            break;
                        }
                        customerHash.Print();
                        break;
                    case 4:
                        customerHash.SortByLastPurchaseDate();
                        break;
                    case 5:
                        Console.Write("Enter months: ");
                        months = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter years: ");
                        years = Convert.ToInt32(Console.ReadLine());
                        tempCustomer = customerHash.FindCustomerWithLargestOrderPriceOfMonths(months, years);
                        tempCustomer.Print();
                        break;
                    case 6:
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
                    case 7:
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
                    case 8:
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
                    case 9:
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
                    case 10:
                        Console.WriteLine("Enter file name: ");
                        tempStr = Console.ReadLine();
                        if (!customerHash.WriteFile(tempStr))
                            Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                        else
                        {
                            Console.WriteLine(Constant.SUCCESS_MESSAGE);
                            customerHash.Print();
                        }
                        break;
                    case 11:
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
                    case 12:
                        customerHash.SortByGender();
                        break;
                    case 13:
                        return Constant.MAIN_ACTIVITY;
                    case 0:
                        return Constant.EXIT_APPLICATION;
                    default:
                        Console.WriteLine(Constant.NOT_VALID_MESSAGE);
                        break;
                }
                Console.WriteLine("Press to continue...");
                Console.ReadKey();
            }
        }
    }
}