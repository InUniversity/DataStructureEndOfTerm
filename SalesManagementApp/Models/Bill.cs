using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;
using SalesManagementApp.DataStructure.Base;
using SalesManagementApp.Models;

namespace SalesManagementApp.Models
{
    public class Bill
    {
        private StringCustom sID;
        private ProductList lProducts;
        private StringCustom sEmployeeID;
        private StringCustom sCustomerID;
        private Date dPurchaseDate;
        private int iPrice;

        public StringCustom ID 
        { 
            get { return sID; }
            set { sID = value; }
        }

        public ProductList Products
        {
            get { return lProducts; }
            set { lProducts = value; }
        }

        public StringCustom EmployeeID
        {
            get { return sEmployeeID; }
            set { sEmployeeID = value; }
        }

        public StringCustom CustomerID
        {
            get { return sCustomerID; }
            set { sCustomerID = value; }
        }

        public Date PurchaseDate
        {
            get { return dPurchaseDate; }
            set { dPurchaseDate = value; }
        }

        public int Price
        {
            get { return iPrice; }
            set { iPrice = value; }
        }

        public Bill(StringCustom id, ProductList products, StringCustom employeeID, StringCustom customerID, Date purchaseDate, int iPrice)
        {
            this.sID = id;
            this.lProducts = products;
            this.sEmployeeID = employeeID;
            this.sCustomerID = customerID;
            this.dPurchaseDate = purchaseDate;
            this.iPrice = iPrice;
        }

        public Bill()
        {
            dPurchaseDate = new Date();
            lProducts = new ProductList(100);
        }

        public void Input()
        {
            ProductList tempproductlist = ProductData.productList;
            Product temp = new Product();
            Product tempID = new Product();
            Console.WriteLine("Enter bill ID");
            this.sID = Console.ReadLine();
            Console.WriteLine("Enter the number of products: ");
            int sl = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < sl; i++)
            {
                Console.WriteLine("Enter product ID: ");
                tempID.ID = Console.ReadLine();
                Console.WriteLine("Number of products with ID "+tempID.ID);
                int sl1 = Convert.ToInt32(Console.ReadLine());

                temp = tempproductlist.SearchItemByID(tempID);

                if (temp != null)
                {
                    int d = temp.NumberOfProduct;
                    if(temp.NumberOfProduct>=sl1)
                    {
                        lProducts.AddLast(tempproductlist.Bill(temp, sl1));
                        temp.NumberOfProduct -= sl1;
                    }    
                    else
                    {
                        Console.WriteLine("The store does not have enough goods for you");
                        Console.WriteLine("There are currently "+d+ " products in stock");
                        Console.WriteLine("Do you want to buy all products ? ");
                        Console.WriteLine("1.I agree ");
                        Console.WriteLine("any key.I don't agree ");
                        int choose;
                        choose = Convert.ToInt32(Console.ReadLine());
                        if(choose==1)
                        {
                            temp.NumberOfProduct -= (d);
                            lProducts.AddLast(tempproductlist.Bill(temp, d));
                        }
                        else
                        {
                            Console.WriteLine("Goodbye!!!");
                        }
                    }    

                }
                else
                {
                    int j = i + 1;
                    Console.WriteLine("product" + j);
                    Console.WriteLine("Out of stock");
                }
            }
            Console.WriteLine("Customer ID : ");
            this.CustomerID = Console.ReadLine();
            Console.WriteLine("Employee ID : ");
            this.EmployeeID = Console.ReadLine();
            this.dPurchaseDate = Date.GetCurrentDate();
            this.Price=  TotalPrice(lProducts);
        }

        public void Print()
        {
            Console.WriteLine("Bill");
            Console.WriteLine("Employee ID: " + this.EmployeeID);
            Console.WriteLine("Customer ID: " + this.CustomerID);
            lProducts.Print();
            Console.WriteLine("Total cost: "+this.Price);
            dPurchaseDate.Print();
        }

        public int TotalPrice(ProductList temp)
        {
            int sum = 0;
            Product product = new Product();
            for(int i=0; i<temp.Size; i++)
            {
                product = temp.Get(i);
                sum = sum + (product.NumberOfProduct*product.Price);
            }
            return sum;
        }
    }
}
