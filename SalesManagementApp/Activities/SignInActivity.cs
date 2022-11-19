using System;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;

namespace SalesManagementApp.Activities
{
    public static class SignInActivity
    {

        public static int RunActivity()
        {
            ManagerAccount manager = new ManagerAccount();
            int key = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter choose: ");
                Console.WriteLine("0. Sign in");
                Console.WriteLine("1. Move to Sign up");
                Console.WriteLine("2. Quit app");

                try
                {
                    key = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                if (key == 1)
                    return 0;
                else if (key == 2)
                    return -1;

                Console.WriteLine("===========SIGN IN===========\n");
                Console.WriteLine("|Username:");
                manager.Username = Console.ReadLine();
                Console.WriteLine("|Password:");
                manager.InputPassword();

                if (ManagerAccount.CheckValidAccount(manager))
                    return 2;
            }
        }
    }
}

