using System;
using SalesManagementApp.Database;
using SalesManagementApp.Models;
using SalesManagementApp.Utilities;

namespace SalesManagementApp.Activities
{
    public static class SignUpActivity
    {

        public static int RunActivity()
        {
            SaleAccount saleAccount = new SaleAccount();
            Sale sale = new Sale();
            int choose = 0;
            while (true)
            {
                Console.Clear();
                Printer.PrintGroupInformation(80);
                try
                {
                    saleAccount = new SaleAccount();
                    Console.WriteLine("===========SIGN UP===========");
                    Console.Write("Username: ");
                    saleAccount.Username = Console.ReadLine();
                    Console.Write("Password: ");
                    saleAccount.Password = Console.ReadLine();
                    Console.WriteLine("Enter sale:");
                    sale = new Sale();
                    sale.Input();
                    saleAccount.SaleID = sale.ID;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                if (SaleAccount.CheckValidAccount(saleAccount))
                {
                    AccountData.accountList.AddLast(saleAccount);

                    // add to sales list
                    AccountData.currentAccount = saleAccount;
                    SaleData.saleList.AddLast(sale);
                    return Constant.MAIN_ACTIVITY;
                }
                Printer.Pause();

                while (true)
                {
                    Console.Clear();
                    Printer.PrintGroupInformation(80);
                    Console.WriteLine("=============MENU=============");
                    Console.WriteLine("| Any key. Sign up           |");
                    Console.WriteLine("| 1. Quit app                |");
                    Console.WriteLine("=============MENU=============");
                    Console.Write("Enter choose: ");
                    try { choose = Convert.ToInt32(Console.ReadLine()); }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                    Console.WriteLine();

                    if (choose == 1)
                        return Constant.EXIT_APPLICATION;
                }
            }
        }
    }
}