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
            Product tempProduct = new Product();
            int index;
            ProductList tempList = new ProductList(100);
            Date today = new Date();
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
                Console.Write("|9. Back |\n");
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
                        Console.WriteLine("Location Add Products");
                        index = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Product Information");
                        tempProduct.Input();
                        productList.AddItem(index, tempProduct);
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        productList.Print();
                        break;
                    case '4':  
                        Console.WriteLine("Enter product ID");
                        tempProduct.ID = Convert.ToInt32(Console.ReadLine());
                        tempList = productList.SearchItemByID(tempProduct);
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        if (tempList == null)
                            Console.WriteLine("No products found");
                        else
                        {
                            Console.WriteLine("Product found");
                            tempList.Print();
                        }
                        break;
                    case '5':
                        Console.WriteLine("Enter product name ");
                        tempProduct.Name = Console.ReadLine();
                        tempList = productList.SearchItemByName(tempProduct);
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        if (tempList == null)
                            Console.WriteLine("No products found");
                        else
                        {
                            Console.WriteLine("Product found");
                            tempList.Print();
                        }
                        break;
                    case '6':
                        ProductList temp5 = productList.SortByNumber();
                        temp5.Print();
                        break;
                    case '7':
                        Console.WriteLine("Enter the current date");
                        today.Input();
                        tempList = productList.FindExpiredProducts(today);
                        if (tempList.IsEmpty())
                            Console.WriteLine("No products are out of date.");
                        else
                        {
                            Console.WriteLine("Expired product list:");
                            tempList.Print();
                        }
                        break;
                    case '8':
                        sum = productList.TotalGoods();
                        Console.WriteLine(sum);
                        break;
                    case '9':
                        return 2;
                        break;
                    default:
                        Console.WriteLine("Quit app, Goodbye");
                        return -1;
                        break;
                }
            }
        }
    }
}

