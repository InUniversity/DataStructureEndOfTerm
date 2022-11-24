using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;

namespace SalesManagementApp.Models
{
    public class Bill
    {

        private ProductList lProducts;
        private Employee eSalesman;
        private Customer cBuyer;
        private Date dPurchaseDate;

        public ProductList Products
        {
            get { return lProducts; }
            set { lProducts = value; }
        }

        public Employee Salesman
        {
            get { return eSalesman; }
            set { eSalesman = value; }
        }

        public Customer Buyer
        {
            get { return cBuyer; }
            set { cBuyer = value; }
        }

        public Date PurchaseDate
        {
            get { return dPurchaseDate; }
            set { dPurchaseDate = value; }
        }

        public Bill(ProductList products, Employee salesman, Customer buyer, Date purchaseDate)
        {

            this.lProducts = products;
            this.eSalesman = salesman;
            this.cBuyer = buyer;
            this.dPurchaseDate = purchaseDate;
        }

        public void Input(ProductList tempproductlist)
        {
            Console.WriteLine("Enter the number of products: ");
            int sl = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < sl; i++)
            {
                Product lh = new Product();
                lh.Input();
                Console.WriteLine("Enter product ID: ");
                lh.ID = Convert.ToInt32(Console.ReadLine());
                if (tempproductlist.SearchItemByID(lh)!=null)
                {
                    lProducts.AddLast(lh);
                    tempproductlist.RemoveItemByID(lh);
                }
                else
                {
                    Console.WriteLine("Out of stock");
                }                      
            }
            Console.WriteLine("seller information");
            this.eSalesman.Input();
            Console.WriteLine("Buyer information");
            this.cBuyer.Input();
            Console.WriteLine("purchaseDate:");
            this.dPurchaseDate.Input();
        }

        public void Print()
        {
            Console.WriteLine("bill");
            lProducts.Print();
            //this.salesman = 
            Console.WriteLine("Seller information" + this.eSalesman);
            Console.WriteLine("Buyer information"+this.cBuyer);
            this.dPurchaseDate = Date.GetCurrentDate();
        }

        public int TotalPrice()
        {
            return 0;
        }
    }
}
