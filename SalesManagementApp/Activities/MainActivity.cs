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
             * 1. tìm kiếm sản phẩm theo tên sau đó sắp xếp theo giá
             * 2. in ra tất cả sản phẩm
             * 3. loại bỏ các sản phẩm hết hạn
             */
            bool over, pressEnter;
            int choose = 1, key, x = 0, y = 0;
            do
            {
                over = false;
                Console.Clear();
                Console.Write("=========================MENU=========================\n");
                Console.Write("|1. Search product and ascending order of price      |\n");
                Console.Write("|2. Print the whole product                          |\n");
                Console.Write("|3. Delete expired products                          |\n");
                Console.Write("|3. Delete expired products                          |\n");
                Console.Write("|4. Quit app                                         |\n");
                Console.Write("=========================MENU=========================\n");
                Console.WriteLine("Choose: ");
                y = Console.CursorLeft;
                x = Console.CursorTop;
                do
                {
                    pressEnter = false;
                    Console.SetCursorPosition(x, y);
                    Console.Write(choose);
                    key = (int)Console.ReadKey().Key;
                    switch (key)
                    {
                        case Constant.ARROW_UP:
                            choose--;
                            if (choose < 0)
                                choose = 4;
                            break;
                        case Constant.ARROW_DOWN:
                            choose++;
                            if (choose > 4)
                                choose = 0;
                            break;
                        case Constant.BTN_ENTER:
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
