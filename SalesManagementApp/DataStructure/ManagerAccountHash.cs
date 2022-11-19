using System;
using SalesManagementApp.DataStructure.Base;
using SalesManagementApp.Models;

namespace SalesManagementApp.DataStructure
{
    public class ManagerAccountHash : HashTable<StringCustom, ManagerAccount>
    {

        public ManagerAccountHash(int BUCKET) : base(BUCKET)
        {
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
                if (Equals(key, head.item.value1))
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
            if (index < 0 || index >= Size || table[index].IsEmpty())
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

