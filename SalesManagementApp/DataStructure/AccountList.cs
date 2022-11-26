using System;
using System.Reflection;
using SalesManagementApp.DataStructure.Base;
using SalesManagementApp.Models;

namespace SalesManagementApp.DataStructure
{
    public class AccountList : LinkedLst<SaleAccount>, ILinkedLst<SaleAccount>
    {

        public AccountList() : base()
        {
        }

        public bool WriteFile(string fileName)
        {
            StringCustom path = Directory.GetCurrentDirectory();
            path += "/../../../Database/" + fileName;
            try
            {
                StreamWriter sw = new StreamWriter(path);
                Node<SaleAccount>? head = nFirstItem;
                SaleAccount account = null;
                while (head != null)
                {
                    account = head.item;
                    sw.WriteLine("{0};{1};{2}",
                        account.Username, // 0
                        account.Password, // 1
                        account.SaleID); // 2
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

        public bool AddFromFile(string fileName)
        {
            StringCustom path = Directory.GetCurrentDirectory();
            path += "/../../../Database/" + fileName;
            try
            {
                SaleAccount account = new SaleAccount();
                // read the whole file
                string[] lines = File.ReadAllLines(path);

                foreach (string str in lines)
                {
                    account = GetManagerAccountFromFile(new StringCustom(str));
                    AddNoDuplicate(account);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        private SaleAccount GetManagerAccountFromFile(StringCustom data)
        {
            LinkedLst<StringCustom> temp = data.Split(';');

            SaleAccount account = new SaleAccount();
            account.Username = temp.GetItem(0);
            account.Password = temp.GetItem(1);
            account.SaleID = temp.GetItem(2);
            return account;
        }

        public void AddNoDuplicate(SaleAccount account)
        {
            if (FindById(account.SaleID) != null)
            {
                Console.WriteLine(Constant.DUPLICATED_MESSAGE);
                return;
            }
            AddLast(account);
        }

        public bool Exits(SaleAccount account)
        {
            Node<SaleAccount>? head = nFirstItem;
            SaleAccount managerAccount = null;
            while (head != null)
            {
                managerAccount = head.item;
                if (account.Username.IsEquals(managerAccount.Username) &&
                    account.Password.IsEquals(managerAccount.Password))
                    return true;
                head = head.next;
            }
            return false;
        }

        public SaleAccount FindById(StringCustom id)
        {
            Node<SaleAccount>? head = nFirstItem;
            SaleAccount account = null;
            while (head != null)
            {
                account = head.item;
                if (id == account.SaleID)
                    return account;
                head = head.next;
            }
            return null;
        }

        public void Print()
        {
            Console.WriteLine("|{0, 15}|{1, 20}|{2, 10}",
                "Username",
                "Password",
                "Manager ID");
            Node<SaleAccount>? head = nFirstItem;
            SaleAccount account = null;
            while (head != null)
            {
                account = head.item;
                Console.WriteLine("|{0, 15}|{1, 20}|{2, 10}",
                account.Username, // 0
                account.Password, // 1
                account.SaleID); // 2
                head = head.next;
            }
        }

        public void AddNode(int index, SaleAccount item)
        {
            if (item == null) return;

            Node<SaleAccount> newNode = new Node<SaleAccount>(item);
            Node<SaleAccount>? curNode = GetNode(index);
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

        public void Remove(SaleAccount item)
        {
            Node<SaleAccount>? del = GetNode(item);
            if (del == null) return;
            RemoveCurrentNode(del);
        }

        public void Remove(int index)
        {
            Node<SaleAccount>? del = GetNode(index);
            if (del == null) return;
            RemoveCurrentNode(del);
        }

        public void RemoveLast()
        {
            if (IsEmpty()) return;

            if (iSize == 1)
                FirstItem = null;
            else
            {
                Node<SaleAccount>? head = nLastItem;
                head.previous.next = null;
            }
            iSize--;
        }

        public int IndexOf(SaleAccount item)
        {
            Node<SaleAccount>? head = nFirstItem;
            int i = 0;
            while (head != null && !item.IsEquals(head.item))
            {
                i++;
                head = head.next;
            }
            if (i < iSize)
                return i;
            return -1;
        }

        public void AddRange(LinkedLst<SaleAccount> sourceList)
        {
            Node<SaleAccount>? head = sourceList.FirstItem;
            while (head != null)
            {
                AddLast(head.item);
                head = head.next;
            }
        }
    }
}