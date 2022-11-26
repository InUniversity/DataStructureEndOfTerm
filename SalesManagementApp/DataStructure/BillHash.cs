using System;
using SalesManagementApp.DataStructure.Base;
using SalesManagementApp.Models;

namespace SalesManagementApp.DataStructure
{
    public class BillHash : HashTable<StringCustom, Bill>
    {
        public BillHash(int BUCKET) : base(BUCKET)
        {
        }

        public Bill FindByID(StringCustom id)
        {
            Node<Pair<StringCustom, Bill>>? head = null;
            Bill bill = null;
            for (int i = 0; i < BUCKET; i++)
            {
                head = table[i].FirstItem;
                while (head != null)
                {
                    bill = head.item.value;
                    if (id.IsEquals(bill.ID))
                        return bill;
                    head = head.next;
                }
            }
            return null;
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