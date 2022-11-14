using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesManagementApp;

namespace SalesManagementApp.Activities
{
    public static class MainActivity
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
            char choose;
            while (true)
            {
                Console.Clear();
                Console.Write("=========================MENU=========================\n");
                Console.Write("|1. Move to product management                       |\n");
                Console.Write("|2. Move to customer management                      |\n");
                Console.Write("|3. Move to employee management                      |\n");
                Console.Write("|4. Quit app                                         |\n");
                Console.Write("=========================MENU=========================\n");
                Console.Write("Choose: "); choose = Console.ReadLine()[0];
                switch(choose)
                {
                    case '1':
                        return 3;
                    case '2':
                        return 5;
                    case '3':
                        return 4;
                    default:
                        return -1;
                }
            }
            return -1;
        }
    }
}
