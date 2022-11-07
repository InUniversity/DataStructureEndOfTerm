using System;
using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;

namespace SalesManagementApp.Activities
{
    public static class CustomerManagementActivity
    {

        public static int RunActivity()
        {
            CustomerList customerList = CustomerData.customerList;
            CustomerList tempList;
            Customer tempCustomer = new Customer();
            string tempName;
            Date start = new Date(-1, -1, -1), end = new Date(-1, -1, -1);
            bool over;
            char choose;
            int tempID;
            do
            {
                over = false;
                Console.Clear();
                Console.Write("===========================MENU===========================\n");
                Console.Write("|1. Add a customer                                       |\n");
                Console.Write("|2. Delete customer with ID                              |\n");
                Console.Write("|3. Display customer list                                |\n");
                Console.Write("|4. Sort by LAST purchased date                          |\n");
                Console.Write("|5. Find by date of purchase                             |\n");
                Console.Write("|6. Find by ID                                           |\n");
                Console.Write("|7. Find by Name                                         |\n");
                Console.Write("|8. Write file                                           |\n");
                Console.Write("|9. Read from file                                       |\n");
                Console.Write("|0. Quit app                                             |\n");
                Console.Write("===========================MENU===========================\n");
                Console.Write("Choose: ");
                choose = (char) Console.ReadKey().Key;
                Console.WriteLine();

                switch (choose)
                {
                    case '1':
                        Console.WriteLine("Enter customer: ");
                        tempCustomer.Input();
                        if (customerList.SearchNode(tempCustomer) != null)
                        {
                            Console.WriteLine(Constant.DUPLICATED_MESSAGE);
                            break;
                        }
                        customerList.AddLast(tempCustomer);
                        customerList.Print();
                        break;
                    case '2':
                        Console.Write("Enter ID: ");
                        tempID = Convert.ToInt32(Console.ReadLine());
                        tempCustomer = customerList.FindByID(tempID);
                        if (tempCustomer == null)
                        {
                            Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                            break;
                        }
                        customerList.Remove(tempCustomer);
                        customerList.Print();
                        break;
                    case '3':
                        if (customerList.IsEmpty())
                        {
                            Console.WriteLine(Constant.EMPTY_MESSAGE);
                            break;
                        }
                        customerList.Print();
                        break;
                    case '4':
                        customerList.SortByLastPurchaseDate();
                        customerList.Print();
                        break;
                    case '5':
                        Console.WriteLine("Enter start date:\n{");
                        start.Input();
                        Console.WriteLine("}");
                        Console.WriteLine("Enter end date:\n{");
                        end.Input();
                        Console.WriteLine("}");
                        tempList = customerList.FindByDateOfPurchase(start, end);
                        tempList.Print();
                        break;
                    case '6':
                        Console.Write("Enter ID: ");
                        tempID = Convert.ToInt32(Console.ReadLine());
                        tempCustomer = customerList.FindByID(tempID);
                        if (tempCustomer == null)
                        {
                            Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                            break;
                        }
                        tempCustomer.Print();
                        break;
                    case '7':
                        Console.Write("Enter name: ");
                        tempName = Console.ReadLine();
                        tempList = customerList.FindByName(tempName);
                        if (tempList.IsEmpty())
                        {
                            Console.WriteLine(Constant.EMPTY_MESSAGE);
                            break;
                        }
                        tempList.Print();
                        break;
                    case '8':
                        Console.WriteLine("Enter file name: ");
                        tempName = Console.ReadLine();
                        if (!customerList.WriteFile(tempName))
                            Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                        else
                        {
                            Console.WriteLine(Constant.SUCCESS_MESSAGE);
                            customerList.Print();
                        }
                        break;
                    case '9':
                        tempName = "customer.txt";
                        Console.WriteLine("File name: " + tempName);
                        if (!customerList.AddFromFile(tempName))
                            Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                        else
                        {
                            Console.WriteLine(Constant.SUCCESS_MESSAGE);
                            customerList.Print();
                        }
                        break;
                    default:
                        over = true;
                        break;
                }
                Console.ReadKey();
            } while (!over);
            return -1;
        }
    }
}