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
            int choose = -100;
            while (true)
            {
                Console.Clear();
                Console.Write("=========================MENU=========================\n");
                Console.Write("|1. Move to product management                       |\n");
                Console.Write("|2. Move to customer management                      |\n");
                Console.Write("|3. Move to employee management                      |\n");
                Console.Write("|4. show profile                                     |\n");
                Console.Write("|5. Quit app                                         |\n");
                Console.Write("=========================MENU=========================\n");
                Console.Write("Choose: "); 
                
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                switch (choose)
                {
                    case 1:
                        return 3;
                    case 2:
                        return 5;
                    case 3:
                        return 4;
                    case 4:
                        return -1;
                    default:
                        Console.WriteLine(Constant.NOT_VALID_MESSAGE);
                        break;
                }
            }
        }
    }
}
