using System;
using System.Collections;
using System.Collections.Generic;
using SalesManagementApp.Database;
using SalesManagementApp.DataStructure.Base;
using SalesManagementApp.Models;

namespace SalesManagementApp.DataStructure
{
    public class CustomerList : LinkedLst<Customer>, ILinkedLst<Customer>
    {

        public CustomerList() : base()
        {
        }

        public void AddLastNoDuplicate(Customer customer)
        {
            if (FindByID(customer.ID) != null)
            {
                Console.WriteLine(Constant.DUPLICATED_MESSAGE);
                return;
            }
            AddLast(customer);
        }

        public bool WriteFile(StringCustom fileName)
        {
            StringCustom path = Directory.GetCurrentDirectory();
            path += "/../../../Database/" + fileName;
            try
            {
                StreamWriter sw = new StreamWriter(path);
                Node<Customer> head = nFirstItem;
                Customer customer;
                while (head != null)
                {
                    customer = head.item;
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
                    AddLastNoDuplicate(customer);
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

        public void SortByLastPurchaseDate()
        {
            base.Sort((customer1, customer2) => {
                if (customer1.LastPurchaseDate > customer2.LastPurchaseDate)
                    return 1;
                else
                    return -1;
            });
        }

        public CustomerList FindByDateOfPurchase(Date start, Date end)
        {
            CustomerList customerList = new CustomerList();
            Customer customer;
            Node<Customer>? head = this.nFirstItem;
            while (head != null)
            {
                customer = head.item;
                if (customer.LastPurchaseDate >= start && customer.LastPurchaseDate <= end)
                    customerList.AddLast(customer);
                head = head.next;
            }
            return customerList;
        }

        public Customer FindByID(int id)
        {
            Customer customer;
            Node<Customer>? head = this.nFirstItem;
            while (head != null)
            {
                customer = head.item;
                if (customer.ID == id)
                    return customer;
                head = head.next;
            }
            return null;
        }

        public CustomerList FindByName(StringCustom name)
        {
            CustomerList customerList = new CustomerList();
            Customer customer;
            Node<Customer>? head = this.nFirstItem;
            while (head != null)
            {
                customer = head.item;
                if (customer.Name.Contain(name))
                    customerList.AddLast(customer);
                head = head.next;
            }
            return customerList;
        }

        public void AddNode(int index, Customer item)
        {
            if (item == null) return;

            Node<Customer> newNode = new Node<Customer>(item);
            Node<Customer>? curNode = GetNode(index);
            if (curNode == null) return;

            if (item.IsEquals(nFirstItem.item))
                AddFirst(item);
            else if (item.IsEquals(nLastItem.item))
                AddLast(item);
            else
            {
                newNode.previous = curNode;
                newNode.next = curNode.next;
                newNode.previous.next = newNode;
                newNode.next.previous = newNode;
            }
            iSize++;
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
            Customer temp;
            Node<Customer>? head = nFirstItem;
            while (head != null)
            {
                temp = head.item;
                Console.WriteLine("|{0, 8}|{1, 25}|{2, 4}|{3, 10}|{4, 20}|{5, 12}|{6, 19}|{7, 6}|{8, 14}|{9, 18}|",
                temp.ID, // 0
                temp.Name, // 1
                temp.Sex, // 2
                temp.Birthday, // 3
                temp.Address, // 4
                temp.PhoneNumber.ToString(), // 5
                temp.NumberOfProductsPurchased, //6
                temp.Point, // 7
                temp.TypeOfMember, // 8
                temp.LastPurchaseDate); // 9

                head = head.next;
            }
        }

        public int IndexOf(Customer item)
        {
            Node<Customer>? head = nFirstItem;
            for (int i = 0; i < iSize; i++)
            {
                if (item.IsEquals(head.item))
                    return i;
                head = head.next;
            }
            return -1;
        }

        public void Remove(int index)
        {
            Node<Customer>? del = GetNode(index);
            if (del == null) return;
            RemoveNodeInList(del);
        }

        public void Remove(Customer item)
        {
            Node<Customer>? del = GetNode(item);
            if (del == null) return;
            RemoveNodeInList(del);
        }

        public void RemoveLast()
        {
            if (IsEmpty()) return;

            if (iSize == 1)
                FirstItem = null;
            else
            {
                Node<Customer>? head = nLastItem;
                head.previous.next = null;
            }
            iSize--;
        }

        public void AddRange(LinkedLst<Customer> sourceList)
        {
            Node<Customer>? head = sourceList.FirstItem;
            while (head != null)
            {
                base.AddLast(head.item);
                head = head.next;
            }
        }
    }
}