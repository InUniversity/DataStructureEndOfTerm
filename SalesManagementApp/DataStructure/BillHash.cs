using System;
using SalesManagementApp.Database;
using System.Security.Cryptography;
using SalesManagementApp.DataStructure.Base;
using SalesManagementApp.Models;
using System.Reflection;

namespace SalesManagementApp.DataStructure
{
    public class BillHash : HashTable<StringCustom, Bill>
    {
        public BillHash(int BUCKET) : base(BUCKET)
        {
        }

        public void InsertNoDuplicate(Bill Bill)
        {
            if (GetValue(Bill.ID) != null)
            {
                Console.WriteLine(Constant.DUPLICATED_MESSAGE);
                return;
            }
            Insert(Bill.ID, Bill);
        }

        public bool WriteFile(StringCustom fileName)
        {
            StringCustom path = Directory.GetCurrentDirectory();
            path += "/../../../Database/" + fileName;
            try
            {
                StreamWriter sw = new StreamWriter(path);
                LinkedLst<Pair<StringCustom, int>> purchasedOrders;
                Node<Pair<StringCustom, int>>? headPurchasedOrders;
                Node<Pair<StringCustom, Bill>>? head = null;
                Pair<StringCustom, Bill> temp = null;
                Bill bill = null;
                for (int i = 0; i < BUCKET; i++)
                {
                    head = table[i].FirstItem;
                    while (head != null)
                    {
                        bill = head.item.value;
                        sw.Write("{0};{1};{2};",
                            bill.ID, // 0
                            bill.SaleID, // 1
                            bill.CustomerID); // 2

                        purchasedOrders = bill.Products;
                        headPurchasedOrders = purchasedOrders.FirstItem;
                        while (headPurchasedOrders.next != null)
                        {
                            sw.Write("{0}={1},", 
                                headPurchasedOrders.item.key, headPurchasedOrders.item.value);    
                            headPurchasedOrders = headPurchasedOrders.next;
                        }
                        if (headPurchasedOrders != null)
                            sw.Write("{0}={1}", 
                                headPurchasedOrders.item.key, headPurchasedOrders.item.value);
                        
                        sw.Write(";{0};{1}",
                            bill.PurchaseDate.GetDateTime(),
                            bill.Price);
                        sw.WriteLine();
                        
                        head = head.next;
                    }
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public bool AddFromFile(StringCustom fileName)
        {
            StringCustom path = Directory.GetCurrentDirectory();
            path += "/../../../Database/" + fileName;
            try
            {
                Bill bill = new Bill();
                // read the whole file
                string[] lines = File.ReadAllLines(path);

                foreach (string str in lines)
                {
                    bill = GetBillFromFile(new StringCustom(str));
                    InsertNoDuplicate(bill);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        private Bill GetBillFromFile(StringCustom data)
        {
            LinkedLst<StringCustom> temp = data.Split(';');
            LinkedLst<StringCustom> tempProductList, tempProduct;
            Node<StringCustom>? head;
            Pair<StringCustom, int> item;
            StringCustom tempStr;
            Bill bill = new Bill();

            bill.ID = temp.GetItem(0);
            bill.SaleID = temp.GetItem(1);
            bill.CustomerID = temp.GetItem(2);

            // read product list
            tempStr = temp.GetItem(3);
            tempProductList = tempStr.Split(',');
            head = tempProductList.FirstItem;
            while (head != null)
            {
                tempProduct = head.item.Split('=');
                item = new Pair<StringCustom, int>(tempProduct.GetItem(0), tempProduct.GetItem(1).ToInt());
                bill.Products.AddLast(item);
                head = head.next;
            }

            bill.PurchaseDate = (Date)temp.GetItem(4);
            bill.Price = temp.GetItem(5).ToInt();
            return bill;
        }
        
        
        public Pair<Product, int> FindBestSellingProducts(int months, int years)
        {
            ProductList _productList = ProductData.productList;
            LinkedLst<Pair<Product, int>> saleList = new LinkedLst<Pair<Product, int>>();
            Node<Pair<Product, int>>? headSaleList;
            Product bestSellingProducts;
            int theMostSoldQuantity;
            // instance
            for (int i = 0; i < _productList.Size; i++)
                saleList.AddLast(new Pair<Product, int>(_productList.Get(i), 0));

            // get quantity
            Node<Pair<StringCustom, Bill>>? head = null;
            for (int i = 0; i < BUCKET; i++)
            {
                head = table[i].FirstItem;
                while (head != null)
                {
                    if (head.item.value.PurchaseDate.Month == months && head.item.value.PurchaseDate.Year == years)
                    {
                        Node<Pair<StringCustom, int>>? headProductList = head.item.value.Products.FirstItem;
                        while (headProductList != null)
                        {

                            headSaleList = saleList.FirstItem;
                            while (headSaleList != null)
                            {
                                if (headSaleList.item.key.ID.IsEquals(headProductList.item.key))
                                {
                                    headSaleList.item.value += headProductList.item.value;
                                    break;
                                }
                                headSaleList = headSaleList.next;
                            }
                            
                            headProductList = headProductList.next;
                        }
                    }
                    head = head.next;
                }
            }
            
            // find max
            bestSellingProducts = null;
            headSaleList = saleList.FirstItem;
            theMostSoldQuantity = 0;
            while (headSaleList != null)
            {
                if (headSaleList.item.value > theMostSoldQuantity)
                {
                    theMostSoldQuantity = headSaleList.item.value;
                    bestSellingProducts = headSaleList.item.key;
                }
                headSaleList = headSaleList.next;
            }

            return new Pair<Product, int>(bestSellingProducts, theMostSoldQuantity);
        }

        public Product FindProductThatSellsTheLeast(int months, int years)
        {
            ProductList _productList = ProductData.productList;
            LinkedLst<Pair<Product, int>> saleList = new LinkedLst<Pair<Product, int>>();
            Node<Pair<Product, int>>? headSaleList;
            int minimumQuantitySold;
            Product salesTheLeast;
            // instance
            for (int i = 0; i < _productList.Size; i++)
                saleList.AddLast(new Pair<Product, int>(_productList.Get(i), 0));

            // get quantity
            Node<Pair<StringCustom, Bill>>? head = null;
            for (int i = 0; i < BUCKET; i++)
            {
                head = table[i].FirstItem;
                while (head != null)
                {
                    if (head.item.value.PurchaseDate.Month == months && head.item.value.PurchaseDate.Year == years)
                    {
                        Node<Pair<StringCustom, int>>? headProductList = head.item.value.Products.FirstItem;
                        while (headProductList != null)
                        {

                            headSaleList = saleList.FirstItem;
                            while (headSaleList != null)
                            {
                                if (headSaleList.item.key.ID.IsEquals(headProductList.item.key))
                                {
                                    headSaleList.item.value += headProductList.item.value;
                                    break;
                                }
                                headSaleList = headSaleList.next;
                            }
                            
                            headProductList = headProductList.next;
                        }
                    }
                    head = head.next;
                }
            }
            
            // find min
            salesTheLeast = null;
            headSaleList = saleList.FirstItem;
            minimumQuantitySold = Int32.MaxValue;
            while (headSaleList != null)
            {
                if (headSaleList.item.value < minimumQuantitySold)
                {
                    minimumQuantitySold = headSaleList.item.value;
                    salesTheLeast = headSaleList.item.key;
                }
                headSaleList = headSaleList.next;
            }
            return salesTheLeast;
        }

        public Bill GetTheBiggestBillOfTheMonth(int months, int years)
        {
            Date currentDate;
            Bill biggestBill = null, currentBill;
            Node<Pair<StringCustom, Bill>>? head;
            int maxPrice = -1, currentPrice;
            for (int i = 0; i < BUCKET; i++)
            {
                head = table[i].FirstItem;
                while (head != null)
                {
                    currentBill = head.item.value;
                    currentDate = currentBill.PurchaseDate;
                    currentPrice = currentBill.Price;
                    if (currentDate.Month == months && currentDate.Year == years
                        && currentPrice > maxPrice)
                    {
                        biggestBill = currentBill;
                        maxPrice = currentPrice;
                    }
                    head = head.next;
                }
            }
            return biggestBill;
        }

        public void IssueAnBill(Bill bill)
        {
            Node<Pair<StringCustom, int>>? head;
            StringCustom tempID;
            int quantity;
            ProductList productList = ProductData.productList;
            
            BillData.billHash.Insert(bill.ID, bill);

            // get product from inventory
            head = bill.Products.FirstItem;
            while (head != null)
            {
                tempID = head.item.key;
                quantity = head.item.value;
                productList.FindByID(tempID).NumberOfProduct -= quantity;
                head = head.next;
            }

            // get customer with id
            Customer customer = CustomerData.customerHash.GetValue(bill.CustomerID);
            if (customer == null)
            {
                Console.WriteLine("Enter new customer (re-enter id again):");
                customer = new Customer();
                customer.Input();
                bill.CustomerID = customer.ID;
            }
            customer.PurchasedOrders.AddLast(bill.ID);
        }

        public void Print()
        {
            Console.WriteLine("Number of bills: " + iSize);
            Console.WriteLine("----------------------BILL LIST----------------------");
            Console.WriteLine("----------------------------------------------");
            for (int i = 0; i < BUCKET; i++)
            {
                Node<Pair<StringCustom, Bill>>? head = table[i].FirstItem;
                Bill bill;
                while (head != null)
                {
                    bill = head.item.value;
                    bill.Print();
                    head = head.next;
                    Console.WriteLine("----------------------------------------------");
                }
            }
            Console.WriteLine("----------------------BILL LIST----------------------");
        }

        public override void Remove(StringCustom key)
        {
            int index = HashFunction(key);
            if (table[index].IsEmpty())
                return;

            Pair<StringCustom, Bill> delItem = null;
            Node<Pair<StringCustom, Bill>>? head = table[index].FirstItem;
            while (head != null)
            {
                if (key == head.item.key)
                {
                    delItem = head.item;
                    break;
                }
                head = head.next;
            }
            if (delItem == null) return;

            Node<Pair<StringCustom, Bill>>? delNode = table[index].GetNode(delItem);
            table[index].RemoveCurrentNode(delNode);
            iSize--;
        }

        public override Bill GetValue(StringCustom key)
        {
            int index = HashFunction(key);
            if (table[index].IsEmpty())
                return null;

            Node<Pair<StringCustom, Bill>>? head = table[index].FirstItem;
            while (head != null)
            {
                if (key.IsEquals(head.item.key))
                    return head.item.value;
                head = head.next;
            }
            return null;
        }

        public override int HashFunction(StringCustom key)
        {
            int temp = 0;
            for (int i = 0; i < key.Size; i++)
                temp += key.CharAt(i);
            return temp % BUCKET;
        }
    }
}