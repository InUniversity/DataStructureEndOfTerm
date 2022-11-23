using System;
using System.Reflection;
using SalesManagementApp.DataStructure.Base;
using SalesManagementApp.Models;

namespace SalesManagementApp.DataStructure
{
    public class AccountList : LinkedLst<ManagerAccount>, ILinkedLst<ManagerAccount>
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
                Node<ManagerAccount>? head = nFirstItem;
                ManagerAccount account = null;
                while (head != null)
                {
                    account = head.item;
                    sw.WriteLine("{0};{1};{2}",
                        account.Username, // 0
                        account.Password, // 1
                        account.ManagerID); // 2
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
                ManagerAccount account = new ManagerAccount();
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

        private ManagerAccount GetManagerAccountFromFile(StringCustom data)
        {
            LinkedLst<StringCustom> temp = data.Split(';');

            ManagerAccount account = new ManagerAccount();
            account.Username = temp.GetItem(0);
            account.Password = temp.GetItem(1);
            account.ManagerID = temp.GetItem(2).ToInt();
            return account;
        }

        public void AddNoDuplicate(ManagerAccount account)
        {
            if (FindById(account.ManagerID) != null)
            {
                Console.WriteLine(Constant.DUPLICATED_MESSAGE);
                return;
            }
            AddLast(account);
        }

        public bool Exits(ManagerAccount account)
        {
            Node<ManagerAccount>? head = nFirstItem;
            ManagerAccount managerAccount = null;
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

        public ManagerAccount FindById(int id)
        {
            Node<ManagerAccount>? head = nFirstItem;
            ManagerAccount account = null;
            while (head != null)
            {
                account = head.item;
                if (id == account.ManagerID)
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
            Node<ManagerAccount>? head = nFirstItem;
            ManagerAccount account = null;
            while (head != null)
            {
                account = head.item;
                Console.WriteLine("|{0, 15}|{1, 20}|{2, 10}",
                account.Username, // 0
                account.Password, // 1
                account.ManagerID); // 2
                head = head.next;
            }
        }

        public void AddNode(int index, ManagerAccount item)
        {
            if (item == null) return;

            Node<ManagerAccount> newNode = new Node<ManagerAccount>(item);
            Node<ManagerAccount>? curNode = GetNode(index);
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

        public void Remove(ManagerAccount item)
        {
            Node<ManagerAccount>? del = GetNode(item);
            if (del == null) return;
            RemoveCurrentNode(del);
        }

        public void Remove(int index)
        {
            Node<ManagerAccount>? del = GetNode(index);
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
                Node<ManagerAccount>? head = nLastItem;
                head.previous.next = null;
            }
            iSize--;
        }

        public int IndexOf(ManagerAccount item)
        {
            Node<ManagerAccount>? head = nFirstItem;
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

        public void AddRange(LinkedLst<ManagerAccount> sourceList)
        {
            Node<ManagerAccount>? head = sourceList.FirstItem;
            while (head != null)
            {
                AddLast(head.item);
                head = head.next;
            }
        }
    }
}