using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesManagementApp;
using SalesManagementApp.Database;
using SalesManagementApp.Utilities;

namespace SalesManagementApp.Activities
{
    public static class MainActivity
    {
        public static int RunActivity()
        {
            int choose = -100;
            while (true)
            {
                Console.Clear();
                Printer.PrintGroupInformation(80);
                Console.Write("=========================MENU=========================\n");
                Console.Write("|1. Move to sales activity                           |\n");
                Console.Write("|2. Move to inventory management                     |\n");
                Console.Write("|3. Move to customer management                      |\n");
                Console.Write("|4. Move to employee management                      |\n");
                Console.Write("|5. Quit app                                         |\n");
                Console.Write("=========================MENU=========================\n");
                Console.Write("Choose: ");

                try { choose = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception e) { Console.WriteLine(e.Message); }

                switch (choose)
                {
                    case 1: return Constant.SALES_ACTIVITY;
                    case 2: return Constant.INVENTORY_MANANGEMENT_ACTIVITY;
                    case 3: return Constant.CUSTOMER_MANAGEMENT_ACTIVITY;
                    case 4: return Constant.EMPLOYEE_MANAGEMENT_ACTIVITY;
                    case 5: return Constant.EXIT_APPLICATION;
                    default: 
                        Console.WriteLine(Constant.NOT_VALID_MESSAGE); 
                        break;
                }
            }
        }
    }
}