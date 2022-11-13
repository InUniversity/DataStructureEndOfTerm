using System;
using System.Collections;
using System.Collections.Generic;
using SalesManagementApp.Models;

namespace SalesManagementApp.DataStructure
{
    public class CustomerList : LinkedLst<Customer>
    {

        public CustomerList() : base()
        {
        }

        public bool WriteFile(StringCustom fileName)
        {
            StringCustom path = @fileName;
            StreamWriter sw = new StreamWriter(fileName);
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
            sw.Flush();
            sw.Close();
            return true;
        }

        public bool AddFromFile(StringCustom fileName)
        {
            StringCustom path = fileName;
            if (!File.Exists(path)) return false;

            CustomerList customerList = new CustomerList();
            Customer customer = new Customer();
            string[] lines = File.ReadAllLines(path);
            foreach (string str in lines)
            {
                customer = GetCustomerFromFile(str);
                customerList.AddLast(customer);
            }
            return true;
        }

        private Customer GetCustomerFromFile(StringCustom data)
        {
            Customer customer = new Customer();
            StringCustom[] temp = data.Split(';');
            customer.ID = temp[0].ToInt();
            customer.Name = temp[1];
            customer.Sex = temp[2];
            customer.Birthday = (Date) temp[3];
            customer.Address = temp[4];
            customer.PhoneNumber = temp[5];
            customer.NumberOfProductsPurchased = temp[6].ToInt();
            customer.Point = temp[7].ToInt();
            customer.TypeOfMember = temp[8];
            customer.LastPurchaseDate = (Date) temp[9];
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

        public override void AddNode(int index, Customer item)
        {
            if (item == null || IsFull()) return;

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

        public override void Print()
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

        public override Node<Customer>? SearchNode(Customer item)
        {
            Node<Customer>? head = nFirstItem;
            Customer customer;
            while (head != null)
            {
                customer = head.item;
                if (item.IsEquals(customer))
                    return head;
                head = head.next;
            }
            return null;
        }

        public override int IndexOf(Customer item)
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

        public override bool IsFull()
        {
            Node<Customer>? newNode = new Node<Customer>(new Customer());
            return newNode == null;
        }

        public override void Remove(int index)
        {
            Node<Customer>? del = GetNode(index);
            if (del == null)
                return;
            RemoveNode(del);
        }

        public override void Remove(Customer item)
        {
            Node<Customer>? del = SearchNode(item);
            if (del == null)
                return;
            RemoveNode(del);
        }

        public override void RemoveLast()
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

        public override void AddRange(LinkedLst<Customer> sourceList)
        {
            Node<Customer>? head = sourceList.FirstItem;
            while (head != null)
            {
                base.AddLast(head.item);
                head = head.next;
            }
        }

        public override Node<Customer>? GetNode(int index)
        {
            Node<Customer>? head = nFirstItem;
            for (int i = 0; i < index; i++)
                head = head.next;
            return head;
        }
    }
}