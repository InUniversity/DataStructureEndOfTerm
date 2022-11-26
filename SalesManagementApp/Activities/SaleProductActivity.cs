using SalesManagementApp.Models;
using SalesManagementApp.Utilities;
namespace SalesManagementApp.Activities
{
    public static class SaleProductActivity
    {

        public static int RunActivity()
        {

            int choose = 18;
            while (true)
            {
                Console.Clear();

                Printer.PrintGroupInformation(70);
                Console.Write("=========================MENU==========================\n");
                Console.Write("|1. Print Bill                                        |\n");

                Console.Write("|18. Back to Main activity                            |\n");
                Console.Write("|any key. Quit app                                    |\n");
                Console.Write("=========================MENU==========================\n");
                Console.Write("Choose: ");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine();
                switch (choose)
                {
                    case 1:
                        Bill a = new Bill();
                        a.Input();
                        a.Print();
                        break;
                    case 18:
                        return Constant.MAIN_ACTIVITY;
                    default:
                        return Constant.EXIT_APPLICATION;
                }
                Console.WriteLine("Enter To Continue");
                Console.ReadKey();
            }
            return 0;
        }

    }
}
