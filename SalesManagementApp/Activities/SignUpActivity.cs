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
            ManagerAccount manager = new ManagerAccount();
            int choose = 0;
            while (true)
            {
                Console.Clear();
                Printer.PrintGroupInformation(80);
                try
                {
                    Console.WriteLine("===========SIGN UP===========");
                    Console.Write("Username: ");
                    manager.Username = Console.ReadLine();
                    Console.Write("Password: ");
                    manager.InputPassword();
                    Console.Write("ID: ");
                    manager.ManagerID = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                if (ManagerAccount.CheckValidAccount(manager))
                {
                    AccountData.GetInstance().Insert(manager.Username, manager);

                    AccountData.GetInstance().GetValue(manager.Username).Print();

                    Console.ReadKey();
                    return Constant.MAIN_ACTIVITY;
                }
                Console.WriteLine(Constant.NOT_VALID_MESSAGE);
                Console.ReadKey();

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
                    break;
                }
            }
        }
    }
}