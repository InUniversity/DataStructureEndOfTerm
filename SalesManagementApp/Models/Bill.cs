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
        private StringCustom sSaleID;
        private StringCustom sCustomerID;
        private LinkedLst<Pair<StringCustom, int>> lProducts;
        private Date dPurchaseDate;
        private int iPrice;

        public StringCustom ID 
        { 
            get { return sID; }
            set { sID = value; }
        }

        public StringCustom SaleID
        {
            get { return sSaleID; }
            set { sSaleID = value; }
        }

        public StringCustom CustomerID
        {
            get { return sCustomerID; }
            set { sCustomerID = value; }
        }

        public LinkedLst<Pair<StringCustom, int>> Products
        {
            get { return lProducts; }
            set { lProducts = value; }
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

        public Bill(StringCustom id, LinkedLst<Pair<StringCustom, int>> products,
            StringCustom saleID, StringCustom customerID, Date purchaseDate)
        {
            this.sID = id;
            this.lProducts = products;
            this.sSaleID = saleID;
            this.sCustomerID = customerID;
            this.dPurchaseDate = purchaseDate;
            this.iPrice = GetTotalPrice();
        }

        public Bill()
        {
            dPurchaseDate = new Date();
            lProducts = new LinkedLst<Pair<StringCustom, int>>();
        }

        public void Input()
        {
            StringCustom tempID;
            int tempNumber, numberOfProducts;
            lProducts = new LinkedLst<Pair<StringCustom, int>>();

            //  auto fill
            sID = GetRandomID();
            
            while (BillData.billHash.GetValue(sID) != null)
            {
                Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                Console.Write("Re-enter bill id: ");
                sID = Console.ReadLine();
            }

            // get current account
            sSaleID = AccountData.currentAccount.SaleID;

            Console.Write("Enter customer id: ");
            sCustomerID = Console.ReadLine();

            // enter product list
            Console.Write("Enter the number of products: ");
            numberOfProducts = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfProducts; i++)
            {
                // enter product id
                Console.Write("Enter product id: ");
                tempID = Console.ReadLine();
                while (ProductData.productList.FindByID(tempID) == null)
                {
                    Console.WriteLine(Constant.NOT_FOUND_MESSAGE);
                    Console.Write("Re-enter product id: ");
                    tempID = Console.ReadLine();
                }

                // enter quantity
                Console.Write("Enter the quantity: ");
                tempNumber = Convert.ToInt32(Console.ReadLine());
                while (ProductData.productList.FindByID(tempID).NumberOfProduct < tempNumber)
                {
                    Console.WriteLine("-> Not enough quantity!!!");
                    Console.WriteLine("-> Current quantity is {0}", ProductData.productList.FindByID(tempID).NumberOfProduct);
                    Console.Write("Re-enter the quantity: ");
                    tempNumber = Convert.ToInt32(Console.ReadLine());
                }
                lProducts.AddLast(new Pair<StringCustom, int>(tempID, tempNumber));
            }
            dPurchaseDate = Date.GetCurrentDate();
            iPrice = GetTotalPrice();
        }

        public void Print()
        {
            Console.WriteLine("Bill ID: " + sID);
            Console.WriteLine("Employee ID: " + SaleID);
            Console.WriteLine("Customer ID: " + CustomerID);
            Console.WriteLine("Product list:");
            Console.WriteLine("{");
            if (lProducts.IsEmpty())
                Console.WriteLine(Constant.EMPTY_MESSAGE);
            PrintProductList();
            Console.WriteLine("}");
            Console.WriteLine("Purchased date: " + dPurchaseDate.GetDateTime());
            Console.WriteLine("Total cost: " + iPrice);
        }

        public void PrintProductList()
        {
            Node<Pair<StringCustom, int>>? head = lProducts.FirstItem;
            Pair<StringCustom, int> item = null;
            while (head != null)
            {
                item = head.item;
                Console.WriteLine("Product ID: {0} => Quantity: {1}", item.key, item.value);
                head = head.next;
            }
        }

        public int GetTotalPrice()
        {
            int price = 0, quantity;
            Node<Pair<StringCustom, int>>? head = lProducts.FirstItem;
            Product product = null;
            while (head != null)
            {
                product = ProductData.productList.FindByID(head.item.key);
                quantity = head.item.value;
                price += (product.Price * quantity);
                head = head.next;
            }
            return price;
        }

        public StringCustom GetRandomID()
        {
            Random ran = new Random();
            StringCustom billID;
            int num = 0;
            do
            {
                num = ran.Next(1000, 10000);
                billID = "BIL" + num.ToString();
            } while (BillData.billHash.GetValue(billID) != null);
            return billID;
        }
    }
}