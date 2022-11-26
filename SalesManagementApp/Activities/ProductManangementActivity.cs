using SalesManagementApp.Database;
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
            int choose = 18;
            while (true)
            {
                Console.Clear();

                Printer.PrintGroupInformation(70);
                Console.Write("=========================MENU==========================\n");
                Console.Write("|0. Print product in stock                            |\n");
                Console.Write("|1. Add products to the top of stock                  |\n");
                Console.Write("|2. Add products to the end of the stock              |\n");
                Console.Write("|3. Insert the product in any position                |\n");
                Console.Write("|4. Delete product by index                           |\n");
                Console.Write("|5. Delete product by ID                              |\n");
                Console.Write("|6. Search product by ID                              |\n");
                Console.Write("|7. Search product by Name                            |\n");
                Console.Write("|8. Sort By NumberOfProduct                           |\n");
                Console.Write("|9. Expired Products                                  |\n");
                Console.Write("|10. Total products in stock                          |\n");
                Console.Write("|11. Find product quantity by ID                      |\n");
                Console.Write("|12. List of products with quantity more than 100     |\n");
                Console.Write("|13. Products with the most quantity                  |\n");
                Console.Write("|14. Products with the least quantity                 |\n");
                Console.Write("|15. Check the quantity of any product                |\n");
                Console.Write("|16. Expired product                                  |\n");
                Console.Write("|17. Export file                                      |\n");
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
                    case 0:
                        Console.WriteLine("---------------------------------------------------Result-----------------------------------------");
                        productList.Print();
                        break;
                    case 1:
                        tempProduct = new Product();
                        tempProduct.Input();
                        if (productList.Duplicate(tempProduct) == false)
                        {
                            Console.WriteLine("ID already exists");
                        }
                        else
                        {
                            productList.AddFirst(tempProduct);
                            Console.WriteLine("---------------------------------------------------Result-----------------------------------------");
                            productList.Print();
                        }
                        break;
                    case 2:
                        tempProduct = new Product();
                        tempProduct.Input();
                        if (productList.Duplicate(tempProduct) == false)
                        {
                            Console.WriteLine("ID already exists");
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
                        Console.WriteLine("Enter the product location to delete.");
                        index = Convert.ToInt32(Console.ReadLine());
                        if (index >= productList.Size)
                        {
                            Console.WriteLine("Element not in stock.");
                            break;
                        }
                        productList.RemoveItem(index);
                        Console.WriteLine("---------------------------------------------------Result-----------------------------------------");
                        productList.Print();
                        break;
                    case 5:
                        tempProduct = new Product();
                        Console.WriteLine("Enter the product ID to delete.");
                        tempProduct.ID = Console.ReadLine();
                        productList.RemoveItemByID(tempProduct);
                        Console.WriteLine("---------------------------------------------------Result-----------------------------------------");
                        productList.Print();
                        break;
                    case 6:
                        tempProduct = new Product();
                        Console.WriteLine("Enter product ID");
                        tempProduct.ID = Console.ReadLine();
                        tempProduct =productList.SearchItemByID(tempProduct);
                        Console.WriteLine("---------------------------------------------Result---------------------------------");
                        if (tempProduct == null)
                            Console.WriteLine(Constant.NOT_FOUND_PRODUCT_MESSAGE);
                        else
                        {
                            tempProduct.Print();
                        }
                        break;
                    case 7:
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
                        tempProduct = new Product();
                        tempList = new ProductList(100);
                        Console.WriteLine("Enter product ID : ");
                        tempProduct.ID = Console.ReadLine();
                        int tam = productList.CheckNumberProduct(tempProduct);
                        Console.WriteLine(tam);
                        break;
                    case 12:
                        tempList = new ProductList(100); ;
                        tempList = productList.ProductQuantityMoreThan100();
                        if (tempList == null)
                            Console.WriteLine(Constant.NOT_FOUND_PRODUCT_MESSAGE);
                        else
                        {
                            tempList.Print();
                        }
                        break;
                    case 13:
                        tempList = new ProductList(100); ;
                        tempList = productList.MaximumNumberOfProducts();
                        if (tempList == null)
                            Console.WriteLine(Constant.NOT_FOUND_PRODUCT_MESSAGE);
                        else
                        {
                            tempList.Print();
                        }
                        break;
                    case 14:
                        tempList = new ProductList(100); ;
                        tempList = productList.MinimumNumberOfProducts();
                        if (tempList == null)
                            Console.WriteLine(Constant.NOT_FOUND_PRODUCT_MESSAGE);
                        else
                        {
                            tempList.Print();
                        }
                        break;
                    case 15:
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
                    case 16:
                        Date dayStart = new Date();
                        Date dayEnd = new Date();
                        tempList = new ProductList(100);
                        Console.WriteLine("DayStart: ");
                        dayStart.Input();
                        Console.WriteLine("nhapEnd: ");
                        dayEnd.Input();
                        tempList = productList.FindByDate(dayStart, dayEnd);
                        if (tempList == null)
                            Console.WriteLine(Constant.NOT_FOUND_PRODUCT_MESSAGE);
                        else
                        {
                            tempList.Print();
                        }
                        break;
                    case 17:
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
                    case 18:
                        return Constant.MAIN_ACTIVITY;
                    default:
                        return Constant.EXIT_APPLICATION;
                }
                Console.WriteLine("Enter To Continue");
                Console.ReadKey();
            }
        }
    }
}
