﻿using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;
using SalesManagementApp.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace SalesManagementApp.Activities
{
    public static class InventoryManangementActivity
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
            int choose = 17;
            while (true)
            {
                Console.Clear();
                Printer.PrintGroupInformation(70);
                Console.Write("=========================MENU==========================\n");
                Console.Write("| 1. Print product in stock                           |\n");
                Console.Write("| 2. Add products to stock                            |\n");
                Console.Write("| 3. Insert the product in any position               |\n");
                Console.Write("| 4. Search product by ID                             |\n");
                Console.Write("| 5. Search product by Name                           |\n");
                Console.Write("| 6. Sort By NumberOfProduct                          |\n");
                Console.Write("| 7. Print expired products                           |\n");
                Console.Write("| 8. Total products in stock                          |\n");
                Console.Write("| 9. Find product quantity                            |\n");
                Console.Write("|10. List of products with quantity more than 100     |\n");
                Console.Write("|11. Products with the most quantity                  |\n");
                Console.Write("|12. Products with the least quantity                 |\n");
                Console.Write("|13. Check the quantity of any product                |\n");
                Console.Write("|14. Export file                                      |\n");
                Console.Write("|15. Back to Main activity                            |\n");
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
                        Console.WriteLine("---------------------------------------------------Result-----------------------------------------");
                        productList.Print();
                        break;
                    case 2:
                        tempProduct = new Product();
                        tempProduct.Input();
                        if (productList.ItemAlreadyExists(tempProduct) == true)
                        {
                            productList.Print();
                        }
                        else
                        {
                            productList.AddLast(tempProduct);
                            Console.WriteLine("---------------------------------------------------Result-----------------------------------------");
                            productList.Print();
                        }
                        break;
                    case 3:
                        tempProduct = new Product();
                        Console.WriteLine("Location Add Products");
                        index = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Product Information");
                        tempProduct.Input();
                        productList.AddItem(index, tempProduct);
                        Console.WriteLine("---------------------------------------------------Result-----------------------------------------");
                        productList.Print();
                        break;
                    case 4:
                        tempProduct = new Product();
                        Console.WriteLine("Enter product ID");
                        tempProduct.ID = Console.ReadLine();
                        tempProduct = productList.SearchItemByID(tempProduct);
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        if (tempProduct == null)
                            Console.WriteLine(Constant.NOT_FOUND_PRODUCT_MESSAGE);
                        else
                        {
                            tempProduct.Print();
                        }
                        break;
                    case 5:
                        tempProduct = new Product();
                        Console.WriteLine("Enter product name ");
                        tempProduct.Name = Console.ReadLine();
                        StringCustom name = new StringCustom(tempProduct.Name);
                        tempList = productList.SearchItemByName(name);
                        Console.WriteLine("---------------------------------------------------Result-----------------------------------------");
                        if (tempList == null)
                            Console.WriteLine(Constant.NOT_FOUND_PRODUCT_MESSAGE);
                        else
                        {
                            tempList.Print();
                        }
                        break;
                    case 6:
                        productList.SortByNumberOfProduct();
                        productList.Print();
                        break;
                    case 7:
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
                    case 8:
                        sum = productList.TotalGoods();
                        Console.WriteLine(sum);
                        break;
                    case 9:
                        tempProduct = new Product();
                        Console.WriteLine("Enter product ID : ");
                        tempProduct.ID = Console.ReadLine();
                        int tam = productList.CheckNumberProduct(tempProduct);
                        Console.WriteLine(tam);
                        break;
                    case 10:
                        tempList = new ProductList(100); ;
                        tempList = productList.ProductQuantityMoreThan100();
                        if (tempList == null)
                            Console.WriteLine(Constant.NOT_FOUND_PRODUCT_MESSAGE);
                        else
                        {
                            tempList.Print();
                        }
                        break;
                    case 11:
                        tempList = new ProductList(100); ;
                        tempList = productList.MaximumNumberOfProducts();
                        if (tempList == null)
                            Console.WriteLine(Constant.NOT_FOUND_PRODUCT_MESSAGE);
                        else
                        {
                            tempList.Print();
                        }
                        break;
                    case 12:
                        tempList = new ProductList(100); ;
                        tempList = productList.MinimumNumberOfProducts();
                        if (tempList == null)
                            Console.WriteLine(Constant.NOT_FOUND_PRODUCT_MESSAGE);
                        else
                        {
                            tempList.Print();
                        }
                        break;
                    case 13:
                        tempProduct = new Product();
                        Console.WriteLine("Enter product name ");
                        tempProduct.Name = Console.ReadLine();
                        StringCustom name1 = new StringCustom(tempProduct.Name);
                        tempProduct = productList.QuantityOfAProduct(name1);
                        Console.WriteLine("---------------------------------------------------Result-----------------------------------------");
                        if (tempProduct == null)
                            Console.WriteLine(Constant.NOT_FOUND_PRODUCT_MESSAGE);
                        else
                        {
                            Console.WriteLine(tempProduct.NumberOfProduct);
                        }
                        break;
                    case 14:
                        Console.WriteLine("Enter file name: ");
                        tempName = Console.ReadLine();
                        if (!productList.WriteFile(tempName))
                            Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                        else
                        {
                            Console.WriteLine(Constant.SUCCESS_MESSAGE);
                            productList.Print();
                        }
                        break;
                    case 15:
                        return Constant.MAIN_ACTIVITY;
                    default:
                        return Constant.EXIT_APPLICATION;
                }
                Printer.Pause();
            }
        }
    }
}
