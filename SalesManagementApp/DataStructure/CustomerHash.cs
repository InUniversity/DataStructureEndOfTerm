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
    public class CustomerHash : HashTable<int, Customer>
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
                Node<Pair<int, Customer>>? head = null;
                Pair<int, Customer> temp = null;
                Customer customer = null;
                for (int i = 0; i < BUCKET; i++)
                {
                    head = table[i].FirstItem;
                    while (head != null)
                    {
                        customer = head.item.value;
                        sw.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}",
                        customer.ID, // 0
                        customer.Name, // 1
                        customer.Sex, // 2
                        customer.Birthday, // 3
                        customer.Address, // 4
                        customer.PhoneNumber, // 5
                        customer.NumberOfProductsPurchased, //6
                        customer.Point, // 7
                        customer.TypeOfMember, // 8
                        customer.LastPurchaseDate); // 9
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
            LinkedLst<StringCustom> temp = data.Split(';');

            Customer customer = new Customer();
            customer.ID = temp.GetItem(0).ToInt();
            customer.Name = temp.GetItem(1);
            customer.Sex = temp.GetItem(2);
            customer.Birthday = (Date) temp.GetItem(3);
            customer.Address = temp.GetItem(4);
            customer.PhoneNumber = temp.GetItem(5);
            customer.NumberOfProductsPurchased = temp.GetItem(6).ToInt();
            customer.Point = temp.GetItem(7).ToInt();
            customer.TypeOfMember = temp.GetItem(8);
            customer.LastPurchaseDate = (Date) temp.GetItem(9);
            return customer;
        }

        public LinkedLst<Customer> GetOrderedList(Func<Customer, Customer, int> compare)
        {
            LinkedLst<Customer> orderedList = new LinkedLst<Customer>();

            Node<Pair<int, Customer>>? head;
            Customer account;
            for (int i = 0; i < BUCKET; i++)
            {
                head = table[i].FirstItem;
                while (head != null)
                {
                    account = head.item.value;
                    AddOrdered(orderedList, account, compare);
                    head = head.next;
                }
            }
            return orderedList;
        }

        // ascending
        private void AddOrdered(LinkedLst<Customer> orderedList, Customer item, Func<Customer, Customer, int> compare)
        {
            if (orderedList.IsEmpty())
                orderedList.AddLast(item);
            else
            {
                Node<Customer>? head = orderedList.FirstItem;
                while (head != null && compare(item, head.item) > 0)
                    head = head.next;

                // prepend the current node
                orderedList.PrependTheCurrentNode(head, item);
            }
        }

        public void SortByLastPurchaseDate()
        {
            Func<Customer, Customer, int> compare = (item1, item2) =>
            {
                if (item1.LastPurchaseDate < item2.LastPurchaseDate)
                    return 1;
                else
                    return -1;
            };
            PrintLinkedLst(GetOrderedList(compare));
        }

        public void SortByGender()
        {
            Func<Customer, Customer, int> compare = (item1, item2) =>
            {
                if (item1.Sex.Size < item2.Sex.Size)
                    return 1;
                else
                    return -1;
            };
            PrintLinkedLst(GetOrderedList(compare));
        }

        private void PrintLinkedLst(LinkedLst<Customer> customers)
        {
            Console.WriteLine("|{0, -8}|{1, -25}|{2, -4}|{3, -10}|{4, -20}|{5, -12}|{6, -19}|{7, -6}|{8, -14}|{9, -18}|",
                "ID",
                "Name",
                "Sex",
                "Birthday",
                "Address",
                "Phone number",
                "Number of purchased",
                "Point",
                "Type of member",
                "Last purchase date");

            Node<Customer>? head = customers.FirstItem;
            Customer customer = null;
            while (head != null)
            {
                customer = head.item;
                Console.WriteLine("|{0, 8}|{1, 25}|{2, 4}|{3, 10}|{4, 20}|{5, 12}|{6, 19}|{7, 6}|{8, 14}|{9, 18}|",
                    customer.ID, // 0
                    customer.Name, // 1
                    customer.Sex, // 2
                    customer.Birthday, // 3
                    customer.Address, // 4
                    customer.PhoneNumber.ToString(), // 5
                    customer.NumberOfProductsPurchased, //6
                    customer.Point, // 7
                    customer.TypeOfMember, // 8
                    customer.LastPurchaseDate); // 9
                head = head.next;
            }
        }

        public CustomerHash FindByValue(Func<Customer, bool> compare)
        {
            CustomerHash result = new CustomerHash(BUCKET);
            Node<Pair<int, Customer>>? head = null;
            Pair<int, Customer> temp = null;
            for (int i = 0; i < BUCKET; i++)
            {
                head = table[i].FirstItem;
                while (head != null)
                {
                    temp = head.item;
                    if (compare(temp.value))
                        result.Insert(temp.key, temp.value);
                    head = head.next;
                }
            }
            return result;
        }

        public CustomerHash FindByDateOfPurchase(Date start, Date end)
        {
            Func<Customer, bool> condition = (customer) =>
                customer.LastPurchaseDate >= start && customer.LastPurchaseDate <= end;
            return FindByValue(condition);
        }

        public CustomerHash FindByName(StringCustom name)
        {
            Func<Customer, bool> condition = (customer) =>
                name.Contain(customer.Name);
            return FindByValue(condition);
        }

        public CustomerHash FindCustomersWhoBuyMultipleProducts()
        {
            Func<Customer, bool> condition = (customer) =>
                customer.NumberOfProductsPurchased >= QUANTITY_OF_PRODUCTS_REQUIRED;
            return FindByValue(condition);
        }

        public CustomerHash FindByMemberType(StringCustom memberType)
        {
            Func<Customer, bool> condition = (customer) =>
                memberType.IsEquals(customer.TypeOfMember);
            return FindByValue(condition);
        }

        public CustomerHash FindBySexAndMemberType(StringCustom sex, StringCustom memberType)
        {
            Func<Customer, bool> condition = (customer) =>
                sex.IsEquals(customer.Sex) && memberType.IsEquals(customer.TypeOfMember);
            return FindByValue(condition);
        }

        public void Print()
        {
            Console.WriteLine("|{0, -8}|{1, -25}|{2, -4}|{3, -10}|{4, -20}|{5, -12}|{6, -19}|{7, -6}|{8, -14}|{9, -18}|",
                "ID",
                "Name",
                "Sex",
                "Birthday",
                "Address",
                "Phone number",
                "Number of purchased",
                "Point",
                "Type of member",
                "Last purchase date");

            Node<Pair<int, Customer>>? head = null;
            Customer customer = null;
            for (int i = 0; i < BUCKET; i++)
            {
                head = table[i].FirstItem;
                while (head != null)
                {
                    customer = head.item.value;
                    Console.WriteLine("|{0, 8}|{1, 25}|{2, 4}|{3, 10}|{4, 20}|{5, 12}|{6, 19}|{7, 6}|{8, 14}|{9, 18}|",
                        customer.ID, // 0
                        customer.Name, // 1
                        customer.Sex, // 2
                        customer.Birthday, // 3
                        customer.Address, // 4
                        customer.PhoneNumber.ToString(), // 5
                        customer.NumberOfProductsPurchased, //6
                        customer.Point, // 7
                        customer.TypeOfMember, // 8
                        customer.LastPurchaseDate); // 9
                    head = head.next;
                }
            }
        }

        public override void Remove(int key)
        {
            int index = HashFunction(key);
            if (table[index].IsEmpty())
                return;

            Pair<int, Customer> delItem = null;
            Node<Pair<int, Customer>>? head = table[index].FirstItem;
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

            Node<Pair<int, Customer>>? delNode = table[index].GetNode(delItem);
            table[index].RemoveCurrentNode(delNode);
            iSize--;
        }

        public override Customer GetValue(int key)
        {
            int index = HashFunction(key);
            if (table[index].IsEmpty())
                return null;

            Node<Pair<int, Customer>>? head = table[index].FirstItem;
            while (head != null)
            {
                if (key == head.item.key)
                    return head.item.value;
                head = head.next;
            }
            return null;
        }

        public override int HashFunction(int key)
        {
            return key % BUCKET;
        }
    }
}