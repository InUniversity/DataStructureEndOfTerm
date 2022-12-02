using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Principal;
using System.Xml.Linq;
using SalesManagementApp.Database;
using SalesManagementApp.DataStructure.Base;
using SalesManagementApp.Models;

namespace SalesManagementApp.DataStructure
{
    public class CustomerHash : HashTable<StringCustom, Customer>
    {

        private const int QUANTITY_OF_PRODUCTS_REQUIRED = 30;

        public CustomerHash(int BUCKET) : base(BUCKET)
        {
        }

        public void InsertNoDuplicate(Customer customer)
        {
            if (GetValue(customer.ID) != null)
            {
                Console.WriteLine(Constant.DUPLICATED_MESSAGE);
                return;
            }
            Insert(customer.ID, customer);
        }

        public bool WriteFile(StringCustom fileName)
        {
            StringCustom path = Directory.GetCurrentDirectory();
            path += "/../../../Database/" + fileName;
            try
            {
                StreamWriter sw = new StreamWriter(path);
                LinkedLst<StringCustom> purchasedOrders;
                Node<StringCustom>? headPurchasedOrders;
                Node<Pair<StringCustom, Customer>>? head = null;
                Pair<StringCustom, Customer> temp = null;
                Customer customer = null;
                for (int i = 0; i < BUCKET; i++)
                {
                    head = table[i].FirstItem;
                    while (head != null)
                    {
                        customer = head.item.value;
                        sw.Write("{0};{1};{2};{3};{4};{5};{6};{7};",
                        customer.ID, // 0
                        customer.Name, // 1
                        customer.Gender, // 2
                        customer.Birthday, // 3
                        customer.Address, // 4
                        customer.PhoneNumber, // 5
                        customer.Point, // 6
                        customer.TypeOfMember); // 7

                        purchasedOrders = customer.PurchasedOrders;
                        if (purchasedOrders.IsEmpty())
                            sw.Write(Constant.EMPTY_VALUE);
                        else
                        {
                            headPurchasedOrders = purchasedOrders.FirstItem;
                            while (headPurchasedOrders.next != null)
                            {
                                sw.Write("{0},", headPurchasedOrders.item);    
                                headPurchasedOrders = headPurchasedOrders.next;
                            }
                            if (headPurchasedOrders != null)
                                sw.Write("{0}", headPurchasedOrders.item);
                        }

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
                Customer customer = new Customer();
                // read the whole file
                string[] lines = File.ReadAllLines(path);

                foreach (string str in lines)
                {
                    customer = GetCustomerFromFile(new StringCustom(str));
                    InsertNoDuplicate(customer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        private Customer GetCustomerFromFile(StringCustom data)
        {
            StringCustom tempStr;
            LinkedLst<StringCustom> tempBills = new LinkedLst<StringCustom>();
            Node<StringCustom>? head;
            LinkedLst<StringCustom> temp = data.Split(';');

            Customer customer = new Customer();
            customer.ID = temp.GetItem(0);
            customer.Name = temp.GetItem(1);
            customer.Gender = temp.GetItem(2);
            customer.Birthday = (Date) temp.GetItem(3);
            customer.Address = temp.GetItem(4);
            customer.PhoneNumber = temp.GetItem(5);
            customer.Point = temp.GetItem(6).ToInt();
            customer.TypeOfMember = temp.GetItem(7);

            tempStr = temp.GetItem(8);
            if (tempStr != Constant.EMPTY_VALUE)
            {
                tempBills = tempStr.Split(',');
                head = tempBills.FirstItem;
                while (head != null)
                {
                    customer.PurchasedOrders.AddLast(head.item);
                    head = head.next;
                }
            }
            return customer;
        }

        public void SortByGender()
        {
            LinkedLst<Customer> orderedList = new LinkedLst<Customer>();

            Node<Pair<StringCustom, Customer>>? head;
            Customer account;
            for (int i = 0; i < BUCKET; i++)
            {
                head = table[i].FirstItem;
                while (head != null)
                {
                    account = head.item.value;
                    AddByGender(orderedList, account);
                    head = head.next;
                }
            }
            PrintLinkedLst(orderedList);
        }
        
        private void AddByGender(LinkedLst<Customer> orderedList, Customer item)
        {
            if (orderedList.IsEmpty())
                orderedList.AddLast(item);
            else
            {
                Node<Customer>? head = orderedList.FirstItem;
                while (head != null && item.Gender.CompareTo(head.item.Gender) > 0)
                    head = head.next;

                // prepend the current node
                orderedList.PrependTheCurrentNode(head, item);
            }
        }

        private void PrintLinkedLst(LinkedLst<Customer> customers)
        {
            Console.WriteLine("|{0, 8}|{1, 25}|{2, 7}|{3, 10}|{4, 20}|{5, 12}|{6, 6}|{7, 14}|",
                "ID", // 0
                "Name", // 1
                "Gender", // 2
                "Birthday", // 3
                "Address", // 4
                "Phone number", // 5
                "Point", // 6
                "Type of member"); // 7

            Node<Customer>? head = customers.FirstItem;
            Customer customer = null;
            while (head != null)
            {
                customer = head.item;
                Console.WriteLine("|{0, 8}|{1, 25}|{2, 7}|{3, 10}|{4, 20}|{5, 12}|{6, 6}|{7, 14}|",
                    customer.ID, // 0
                    customer.Name, // 1
                    customer.Gender, // 2
                    customer.Birthday, // 3
                    customer.Address, // 4
                    customer.PhoneNumber, // 5
                    customer.Point, // 6
                    customer.TypeOfMember); // 7
                head = head.next;
            }
        }

        public Customer FindCustomerWithLargestOrderPriceOfMonths(int months, int years)
        {
            Customer currentCustomer, maxCustomer = null;
            Node<Pair<StringCustom, Customer>>? head = null;
            int maxPrice = 0, currentPrice = 0;

            for (int i = 0; i < BUCKET; i++)
            {
                head = table[i].FirstItem;
                while (head != null)
                {
                    currentCustomer = head.item.value;
                    currentPrice = currentCustomer.FindTotalOrderValueForMonth(months, years);
                    if (currentPrice > maxPrice)
                    {
                        maxPrice = currentPrice;
                        maxCustomer = currentCustomer;
                    }
                    head = head.next;
                }
            }
            return maxCustomer;
        }

        public CustomerHash FindByName(StringCustom name)
        {
            CustomerHash result = new CustomerHash(BUCKET);
            Node<Pair<StringCustom, Customer>>? head = null;
            Customer customer = null;
            for (int i = 0; i < BUCKET; i++)
            {
                head = table[i].FirstItem;
                while (head != null)
                {
                    customer = head.item.value;
                    if (name.IsEquals(customer.Name))
                        result.Insert(customer.ID, customer);
                    head = head.next;
                }
            }
            return result;
        }

        public CustomerHash FindByMemberType(StringCustom memberType)
        {
            CustomerHash result = new CustomerHash(BUCKET);
            Node<Pair<StringCustom, Customer>>? head = null;
            Customer? customer = null;
            for (int i = 0; i < BUCKET; i++)
            {
                head = table[i].FirstItem;
                while (head != null)
                {
                    customer = head.item.value;
                    if (memberType.IsEquals(customer.TypeOfMember))
                        result.Insert(customer.ID, customer);
                    head = head.next;
                }
            }
            return result;
        }

        public CustomerHash FindByGenderAndMemberType(StringCustom sex, StringCustom memberType)
        {
            CustomerHash result = new CustomerHash(BUCKET);
            Node<Pair<StringCustom, Customer>>? head = null;
            Customer? customer = null;
            for (int i = 0; i < BUCKET; i++)
            {
                head = table[i].FirstItem;
                while (head != null)
                {
                    customer = head.item.value;
                    if (sex.IsEquals(customer.Gender) && memberType.IsEquals(customer.TypeOfMember))
                        result.Insert(customer.ID, customer);
                    head = head.next;
                }
            }
            return result;
        }

        public void Print()
        {
            Console.WriteLine("|{0, 8}|{1, 25}|{2, 7}|{3, 10}|{4, 20}|{5, 12}|{6, 6}|{7, 14}|",
                "ID", // 0
                "Name", // 1
                "Gender", // 2
                "Birthday", // 3
                "Address", // 4
                "Phone number", // 5
                "Point", // 6
                "Type of member"); // 7

            Node<Pair<StringCustom, Customer>>? head = null;
            Customer customer = null;
            for (int i = 0; i < BUCKET; i++)
            {
                head = table[i].FirstItem;
                while (head != null)
                {
                    customer = head.item.value;
                    Console.WriteLine("|{0, 8}|{1, 25}|{2, 7}|{3, 10}|{4, 20}|{5, 12}|{6, 6}|{7, 14}|",
                    customer.ID, // 0
                    customer.Name, // 1
                    customer.Gender, // 2
                    customer.Birthday, // 3
                    customer.Address, // 4
                    customer.PhoneNumber.ToString(), // 5
                    customer.Point, // 6
                    customer.TypeOfMember); // 7
                    head = head.next;
                }
            }
        }

        public override void Remove(StringCustom key)
        {
            int index = HashFunction(key);
            if (table[index].IsEmpty())
                return;

            Pair<StringCustom, Customer> delItem = null;
            Node<Pair<StringCustom, Customer>>? head = table[index].FirstItem;
            while (head != null)
            {
                if (key.IsEquals(head.item.key))
                {
                    delItem = head.item;
                    break;
                }
                head = head.next;
            }
            if (delItem == null) return;

            Node<Pair<StringCustom, Customer>>? delNode = table[index].GetNode(delItem);
            table[index].RemoveCurrentNode(delNode);
            iSize--;
        }

        public override Customer GetValue(StringCustom key)
        {
            int index = HashFunction(key);
            if (table[index].IsEmpty())
                return null;

            Node<Pair<StringCustom, Customer>>? head = table[index].FirstItem;
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