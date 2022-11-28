using System;
using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;
using SalesManagementApp.Utilities;

namespace SalesManagementApp.Activities
{
    public static class SignInActivity
    {
        public static int RunActivity()
        {
            StringCustom tempStr;
            SaleAccount account = new SaleAccount();
            int choose = 0;
            while (true)
            {
                Console.Clear();
                Printer.PrintGroupInformation(80);
                try
                {
                    Console.WriteLine("===========SIGN IN===========");
                    Console.Write("Username: ");
                    account.Username = Console.ReadLine();
                    Console.Write("Password: ");
                    account.Password = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                tempStr = AccountData.accountList.GetID(account); 
                if (tempStr != null)
                {
                    account.SaleID = tempStr;
                    AccountData.currentAccount = account;
                    return Constant.MAIN_ACTIVITY;
                }

                Console.Clear();
                Printer.PrintGroupInformation(80);
                Console.WriteLine("=============MENU=============");
                Console.WriteLine("| Any key. Sign in           |");
                Console.WriteLine("| 1. Move to Sign up         |");
                Console.WriteLine("| 2. Quit app                |");
                Console.WriteLine("=============MENU=============");

                Console.Write("Enter choose: ");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine();

                if (choose == 1)
                    return Constant.SIGNUP_ACTIVITY;
                else if (choose == 2)
                    return Constant.EXIT_APPLICATION;
            }
        }
    }
}

