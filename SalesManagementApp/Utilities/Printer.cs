using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.Utilities
{
    static class Printer
    {

        public static void PrintGroupInformation(int space)
        {
            string line = new string((char)Constant.LINE_SYMBOL, 34);
            string angle = new string((char)9, 100);
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            string str = new string(' ', space);
            Console.WriteLine(str + "╔" + line + "╗");
            Console.WriteLine(str + "║            Nhom 5                ║");
            Console.WriteLine(str + "╠" + line + "╣");
            Console.WriteLine(str + "║Le Tan                    21110296║");
            Console.WriteLine(str + "║Tran Van An               21110120║");
            Console.WriteLine(str + "║Nguyen Ha Quynh Giao      21110171║");
            Console.WriteLine(str + "╚" + line + "╝");
            Console.SetCursorPosition(left, top);
        }
    }
}
