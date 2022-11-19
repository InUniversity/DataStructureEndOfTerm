using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;
using SalesManagementApp.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace SalesManagementApp.Activities
{
    public static class ProductManangementActivity
    {
        public static int RunActivity()
        {
            ProductList productList = ProductData.productList;
            ProductList tempList = new ProductList(100);
            Product tempProduct;
            Date today;
            StringCustom tempName;
            int index;
            int sum;
            int choose = 11;
            while (true)
            {
                Console.Clear();

                Printer.PrintGroupInformation(70);
                Console.Write("=========================MENU==========================\n");
                Console.Write("|0. Check product in stock                            |\n");
                Console.Write("|1. Add products to the top of the list               |\n");
                Console.Write("|2. Add products to the end of the list               |\n");
                Console.Write("|3. Insert the product in any position                |\n");
                Console.Write("|4. Delete product by index                           |\n");
                Console.Write("|5. Delete product by ID                              |\n");
                Console.Write("|6. Search product by ID                              |\n");
                Console.Write("|7. Search product by Name                            |\n");
                Console.Write("|8. Sort By NumberOfProduct                           |\n");
                Console.Write("|9. Check Expired Products                            |\n");
                Console.Write("|10. Total products in stock                          |\n");
                Console.Write("|11. Back to Main activity                            |\n");
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
                    case 0:
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        productList.Print();
                        break;
                    case 1:
                        tempProduct = new Product();
                        tempProduct.Input();
                        productList.AddFirst(tempProduct);
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        productList.Print();
                        break;
                    case 2:
                        tempProduct = new Product();
                        tempProduct.Input();
                        productList.AddLast(tempProduct);
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        productList.Print();
                        break;
                    case 3:
                        tempProduct = new Product();
                        Console.WriteLine("Location Add Products");
                        index = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Product Information");
                        tempProduct.Input();
                        productList.AddItem(index, tempProduct);
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        productList.Print();
                        break;
                    case 4:
                        Console.WriteLine("Enter the product location to delete.");
                        index = Convert.ToInt32(Console.ReadLine());
                        if (index >= productList.Size)
                        {
                            Console.WriteLine("Element not in stock.");
                            break;
                        }
                        productList.RemoveItem(index);
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        productList.Print();
                        break;
                    case 5:
                        tempProduct = new Product();
                        Console.WriteLine("Enter the product ID to delete.");
                        tempProduct.ID = Convert.ToInt32(Console.ReadLine());
                        productList.RemoveItemByID(tempProduct);
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        productList.Print();
                        break;
                    case 6:
                        tempProduct = new Product();
                        Console.WriteLine("Enter product ID");
                        tempProduct.ID = Convert.ToInt32(Console.ReadLine());
                        tempList = productList.SearchItemByID(tempProduct);
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        if (tempList == null)
                            Console.WriteLine(Constant.NOT_FOUND_PRODUCT_MESSAGE);
                        else
                        {
                            tempList.Print();
                        }
                        break;
                    case 7:
                        tempProduct = new Product();
                        Console.WriteLine("Enter product name ");
                        tempProduct.Name = Console.ReadLine();
                        StringCustom name = new StringCustom(tempProduct.Name);
                        tempList = productList.SearchItemByName(name);
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        if (tempList == null)
                            Console.WriteLine(Constant.NOT_FOUND_PRODUCT_MESSAGE);
                        else
                        {
                            tempList.Print();
                        }
                        break;
                    case 8:
                        productList.SortByNumberOfProduct();
                        productList.Print();
                        break;
                    case 9:
                        today = new Date();
                        Console.WriteLine("Enter the current date");
                        today.Input();
                        tempList = productList.FindExpiredProducts(today);
                        if (tempList.IsEmpty())
                            Console.WriteLine(Constant.NOT_OUT_OF_TIME_PRODUCT_MESSAGE);
                        else
                        {
                            tempList.Print();
                        }
                        break;
                    case 10:
                        sum = productList.TotalGoods();
                        Console.WriteLine(sum);
                        break;
                    case 11:
                        return 2;
                    default:
                        return -1;
                }
                Console.WriteLine("Enter To Continue");
                Console.ReadKey();
            }
        }
    }
}

