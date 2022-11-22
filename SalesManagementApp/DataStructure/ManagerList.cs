using SalesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.DataStructure
{
    public class ManagerList : ArrayList<Manager>
    {

        public ManagerList(int iCapacity) : base(iCapacity) {}

        ~ManagerList() { }

        // methods
        public override void AddItem(int index, Manager item)
        {
            if (base.iSize >= iCapacity) return;
            for(int i = base.iSize; i > index ; i--)
            {
                base.list_[i] = base.list_[i - 1];
            }
            iSize++;
            base.list_[index] = item;
        }

        public override void AddLast(Manager item)
        {
            if (base.iSize >= iCapacity) return;
            base.list_[base.iSize++] = item;
        }

        public override void AddRange(ArrayList<Manager> sourceList)
        {
            for(int i = 0; i < sourceList.Size; i++)
                AddLast(sourceList.Get(i));
        }

        public override Manager Get(int index)
        {
            if (!IsValidIndex(index)) return null;
            else return base.list_[index];
        }

        public override void Print()
        {
            for(int i = 0; i<base.iSize; i++)
            {
                base.list_[i].Print();
            }
        }

        public override void RemoveItem(int index)
        {
            for(int i = index; i< base.iSize; i++)
            {
                base.list_[i] = base.list_[i + 1];
            }
            base.iSize--;
        }

        public override Manager SearchItem(Manager item)
        {
            for(int i = 0; i< base.iSize; i++)
                if (item.IsEqual(base.list_[i]))
                    return base.list_[i];
            return null;
        }

        public Manager SearchItemWithID(int id)
        {
            for (int i = 0; i < base.iSize; i++)
                if (id == base.list_[i].ID)
                    return base.list_[i];
            return null;
        }

        public override int IndexOf(Manager item)
        {
            for(int i = 0; i < base.iSize; i++)
                if (item.IsEqual(base.list_[i]))
                    return i;
            return -1;
        }
    }
}
