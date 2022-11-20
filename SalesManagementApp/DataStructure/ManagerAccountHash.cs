using System;
using System.Reflection;
using SalesManagementApp.DataStructure.Base;
using SalesManagementApp.Models;

namespace SalesManagementApp.DataStructure
{
    public class ManagerAccountHash : HashTable<StringCustom, ManagerAccount>
    {

        public ManagerAccountHash(int BUCKET) : base(BUCKET)
        {
        }

        public bool WriteFile(string fileName)
        {
            StringCustom path = Directory.GetCurrentDirectory();
            path += "/../../../Database/" + fileName;
            try
            {
                StreamWriter sw = new StreamWriter(path);
                Node<Pair<StringCustom, ManagerAccount>>? head;
                ManagerAccount account;
                for (int i = 0; i < BUCKET; i++)
                {
                    head = table[i].FirstItem;
                    while (head != null)
                    {
                        account = head.item.value2;
                        sw.WriteLine("{0};{1};{2}",
                        account.Username, // 0
                        account.Password, // 1
                        account.ManagerID); // 2
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

        public bool AddFromFile(string fileName)
        {
            StringCustom path = Directory.GetCurrentDirectory();
            path += "/../../../Database/" + fileName;
            try
            {
                ManagerAccount customer = new ManagerAccount();
                // read the whole file
                string[] lines = File.ReadAllLines(path);

                foreach (string str in lines)
                {
                    customer = GetManagerAccountFromFile(new StringCustom(str));
                    AddAccount(customer);
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

        public void AddAccount(ManagerAccount user)
        {
            if (!ManagerAccount.CheckValidAccount(user))
            {
                return;
            }
            Insert(user.Username, user);
        }

        public override void Remove(StringCustom key)
        {
            int index = HashFunction(key);
            if (table[index].IsEmpty())
                return;

            Pair<StringCustom, ManagerAccount> delItem = null;
            Node<Pair<StringCustom, ManagerAccount>>? head = table[index].FirstItem;
            while (head != null)
            {
                if (key.IsEqual(head.item.value1))
                {
                    delItem = head.item;
                    break;
                }
                head = head.next;
            }
            if (delItem == null) return;

            Node<Pair<StringCustom, ManagerAccount>>? delNode = table[index].GetNode(delItem);
            table[index].RemoveNodeInList(delNode);
        }

        public override ManagerAccount GetValue(StringCustom key)
        {
            int index = HashFunction(key);
            if (table[index].IsEmpty())
                return null;

            Node<Pair<StringCustom, ManagerAccount>>? head = table[index].FirstItem;
            while (head != null)
            {
                if (StringCustom.Equals(key, head.item.value1))
                    return head.item.value2;
                head = head.next;
            }
            return null;
        }

        public override int HashFunction(StringCustom key)
        {
            int temp = 0;
            for (int i = 0; i < key.Size; i++)
                temp += (int) key.CharAt(i);
            return temp % BUCKET;
        }
    }
}

