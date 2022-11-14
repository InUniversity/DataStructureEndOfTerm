using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;
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
            ProductList temp = new ProductList(100);
            Product tempProduct; 
            int index;
            ProductList tempList = new ProductList(100);
            Date today;
            int sum;
            char choose;
            while (true)
            {
                Console.Write("=========================MENU=========================\n");
                Console.Write("|0. Check product in stock                           |\n");
                Console.Write("|1. Enter a product                                  |\n");
                Console.Write("|2. Delete product by index                          |\n");
                Console.Write("|3. Add products to any position                     |\n");
                Console.Write("|4. Search product by ID                             |\n");
                Console.Write("|5. Search product by Name                           |\n");
                Console.Write("|6. Sort By NumberOfProduct                          |\n");
                Console.Write("|7. Check Expired Products                           |\n");
                Console.Write("|8. Total products in stock                          |\n");
                Console.Write("|9. Back                                             |\n");
                Console.Write("|any key. Quit app                                   |\n");
                Console.Write("=========================MENU=========================\n");
                Console.Write("Choose: ");
                choose = Convert.ToChar(Console.ReadLine());
                switch (choose)
                {
                    case '0':
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        productList.Print();
                        break;
                    case '1':
                        tempProduct =new Product();
                        tempProduct.Input();
                        productList.AddLast(tempProduct);
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        productList.Print();
                        break;
                    case '2':
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
                    case '3':
                        tempProduct = new Product();
                        Console.WriteLine("Location Add Products");
                        index = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Product Information");
                        tempProduct.Input();
                        productList.AddItem(index, tempProduct);
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        productList.Print();
                        break;
                    case '4':
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
                    case '5':
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
                    case '6':
                        productList.SortByNumberOfProduct();
                        productList.Print();
                        break;
                    case '7':
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
                    case '8':
                        sum = productList.TotalGoods();
                        Console.WriteLine(sum);
                        break;
                    case '9':
                        return 2;
                    default:
                        Console.WriteLine(Constant.QUIT_APP_MESSAGE);
                        return -1;
                }
                Console.WriteLine("Enter To Continue");
                Console.ReadKey();
            }
        }
    }
}

