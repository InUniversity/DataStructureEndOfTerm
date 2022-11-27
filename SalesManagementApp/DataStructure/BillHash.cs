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
                    IssueAnBill(bill);
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
            LinkedLst<StringCustom> tempList, product;
            Node<StringCustom>? head;
            Pair<StringCustom, int> item;
            Bill bill = new Bill();

            bill.ID = temp.GetItem(0);
            bill.SaleID = temp.GetItem(1);
            bill.CustomerID = temp.GetItem(2);

            // read product list
            tempList = data.Split(',');
            head = tempList.FirstItem;
            while (head != null)
            {
                product = data.Split('=');
                item = new Pair<StringCustom, int>(product.GetItem(0), product.GetItem(1).ToInt());
                bill.Products.AddLast(item);
                head = head.next;
            }

            bill.PurchaseDate = (Date)temp.GetItem(4);
            bill.Price = temp.GetItem(5).ToInt();
            return bill;
        }

        public Bill GetTheBiggestBillOfTheMonth(int month, int year)
        {
            return null;
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
            customer.PurchasedOrders.AddLast(bill.ID);
        }

        public void Print()
        {
            for (int i = 0; i < BUCKET; i++)
            {
                Node<Pair<StringCustom, Bill>>? head = table[i].FirstItem;
                Bill bill;
                while (head != null)
                {
                    bill = head.item.value;
                    bill.Print();
                    head = head.next;
                }
            }
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
                if (key == head.item.key)
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