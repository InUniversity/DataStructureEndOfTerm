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

        public ManagerList() : base(){ }
        public ManagerList(int count) : base(count){}

        ~ManagerList() { }

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
           if(base.iSize >= iCapacity) return;
            base.list_[base.iSize++] = item;

        }

        public override void AddRange(ArrayList<Manager> sourceList)
        {
            for(int i = 0; i<sourceList.Size; i++)
            {
                if (base.iSize>= Capacity) return;
                else
                {
                    base.list_[base.iSize++] = sourceList.Get(i);
                }
            }
        }

        public override Manager Get(int index)
        {
            return base.list_[index];
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

        public override int SearchItem(Manager item)
        {
            for(int i = 0; i< base.iSize; i++)
            {
                if (base.list_[i] == item)
                    return i;
            }
            return -1;
        }
    }
}
