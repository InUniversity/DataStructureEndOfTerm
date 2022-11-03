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
            int choose = 1, key, x = 0, y = 0;
            do
            {
                over = false;
                Console.Clear();
                Console.Write("=========================MENU=========================\n");
                Console.Write("|1. Move to product management                       |\n");
                Console.Write("|2. Move to customer management                      |\n");
                Console.Write("|3. Move to employee management                      |\n");
                Console.Write("|4. Quit app                                         |\n");
                Console.Write("=========================MENU=========================\n");
                Console.Write("Choose: ");
                x = Console.CursorLeft;
                y = Console.CursorTop;
                do
                {
                    pressEnter = false;
                    Console.SetCursorPosition(x, y);
                    Console.Write(choose);
                    key = (int)Console.ReadKey().Key;
                    switch (key)
                    {
                        case Constant.UP_ARROW:
                            choose--;
                            if (choose < 0)
                                choose = 4;
                            break;
                        case Constant.DOWN_ARROW:
                            choose++;
                            if (choose > 4)
                                choose = 0;
                            break;
                        case Constant.ENTER_KEY:
                            pressEnter = true;
                            break;
                    }
                } while (!pressEnter);

                switch(choose)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        over = true;
                        break;
                }
            } while (!over);
            return -1;
        }
    }
}
