using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;
using SalesManagementApp.Utilities;
namespace SalesManagementApp.Activities
{
    public static class SaleProductActivity
    {

        public static int RunActivity()
        {
            BillHash billHash = BillData.billHash;
            Bill bill = new Bill();
            StringCustom tempID;
            int choose = 18, tempMonth, tempYear;
            while (true)
            {
                Console.Clear();
                Printer.PrintGroupInformation(70);
                Console.Write("==========================MENU===========================\n");
                Console.Write("| 1. Issue an bill                                      |\n");
                Console.Write("| 2. Print bill                                         |\n");
                Console.Write("| 3. Print the bill with the largest value in the month |\n");
                Console.Write("| 4. Find bill by id                                    |\n");
                Console.Write("| 5. Remove bill by id                                  |\n");
                Console.Write("| 6. Back to Main activity                              |\n");
                Console.Write("|any key. Quit app                                      |\n");
                Console.Write("==========================MENU===========================\n");
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
                        Console.WriteLine("Enter bill:");
                        bill.Input();
                        billHash.IssueAnBill(bill);
                        bill.Print();
                        break;
                    case 2:
                        billHash.Print();
                        break;
                    case 3:
                        Console.Write("Enter month: ");
                        tempMonth = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter year: ");
                        tempYear = Convert.ToInt32(Console.ReadLine());
                        bill = billHash.GetTheBiggestBillOfTheMonth(tempMonth, tempYear);
                        bill.Print();
                        break;
                    case 4:
                        Console.Write("Enter id:");
                        tempID = Console.ReadLine();
                        bill = billHash.GetValue(tempID);
                        if (bill == null)
                        {
                            Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                            break;
                        }
                        bill.Print();
                        break;
                    case 5:
                        Console.Write("Enter id:");
                        tempID = Console.ReadLine();
                        if (billHash.GetValue(tempID) == null)
                        {
                            Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                            break;
                        }
                        billHash.Remove(tempID);
                        break;
                    case 6:
                        return Constant.MAIN_ACTIVITY;
                    default:
                        return Constant.EXIT_APPLICATION;
                }
                Console.WriteLine("Enter To Continue");
                Console.ReadKey();
            }
            return 0;
        }

    }
}
