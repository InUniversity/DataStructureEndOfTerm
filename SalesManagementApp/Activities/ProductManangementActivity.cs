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
            Product temp1 = new Product();
            Product product = new Product();
            while (true)
            {
                Console.Write("=========================MENU=========================\n");
                Console.Write("|0. Check product in stock                      |\n");
                Console.Write("|1. Enter a product                      |\n");
                Console.Write("|2. Delete product by index                    |\n");
                Console.Write("|3. Add products to any position |\n");
                Console.Write("|4. Search product by ID |\n");
                Console.Write("|5. Search product by Name |\n");
                Console.Write("|6. Sort By NumberOfProduct |\n");
                Console.Write("|7. Check Expired Products |\n");
                Console.Write("|8. Total products in stock |\n");
                Console.Write("|9. Quit app                                         |\n");
                Console.Write("=========================MENU=========================\n");
                Console.Write("Choose: ");
                int choose;
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 0:
                        Console.WriteLine("----------Result----------");
                        productList.Print();
                        break;
                    case 1:
                        product.Input();
                        productList.AddLast(product);
                        Console.WriteLine("----------Result----------");
                        productList.Print();

                        break;
                    case 2:
                        Console.WriteLine("Enter the product location to delete.");
                        int index = Convert.ToInt32(Console.ReadLine());
                        if (index >= productList.Size)
                        {
                            Console.WriteLine("Element not in stock.");
                            break;
                        }
                        productList.RemoveItem(index);
                        Console.WriteLine("----------Result----------");
                        productList.Print();
                        break;

                    case 3:
                        Console.WriteLine("Location Add Products");
                        int index2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Product Information");
                        product.Input();
                        productList.AddItem(index2, product);
                        Console.WriteLine("----------Result----------");
                        productList.Print();
                        break;
                    case 4:
                        ProductList temp3 = new ProductList(100);
                        Console.WriteLine("Enter product ID");
                        temp1.ID = Convert.ToInt32(Console.ReadLine());
                        temp3 = productList.SearchItemByID(temp1);
                        Console.WriteLine("----------Result----------");
                        if (temp3 == null)
                            Console.WriteLine("No products found");
                        else
                        {
                            Console.WriteLine("Product found");
                            temp3.Print();
                        }
                        break;
                    case 5:
                        ProductList temp4 = new ProductList(100);
                        Console.WriteLine("Enter product name ");
                        temp1.Name = Console.ReadLine();
                        temp4 = productList.SearchItemByName(temp1);
                        Console.WriteLine("----------Result----------");
                        if (temp4 == null)
                            Console.WriteLine("No products found");
                        else
                        {
                            Console.WriteLine("Product found");
                            temp4.Print();
                        }
                        break;
                    case 6:

                        ProductList temp5 = productList.SortByNumber();
                        temp5.Print();
                        break;

                    case 7:
                        Date Today;
                        Today = new Date();
                        Console.WriteLine("Enter the current date");
                        Today.Input();
                        productList.CheckListProduct(Today);
                        if (productList.CheckListProduct(Today) == null)
                            Console.WriteLine("No products are out of date.");
                        else
                        {
                            Console.WriteLine("Expired product list:");
                            ProductList temp6 = productList.CheckListProduct(Today);
                            temp6.Print();
                        }

                        break;
                    case 8:
                        int sum = productList.TotalGoods();
                        Console.WriteLine(sum);
                        break;
                    default:

                        break;
                }
                if (choose == 9)
                {
                    Console.WriteLine("Quit app, Goodbye");
                    return 0;
                }
                if (choose > 9)
                {
                    Console.WriteLine("Syntax error, Re-Enter");

                }

            }

        }
    }
}

