using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesManagementApp.DataStructure.Base;

namespace SalesManagementApp.DataStructure
{
    public abstract class HashTable<T, V>
    {

        protected LinkedLst<Pair<T, V>>[] table;
        protected int iSize;
        protected int BUCKET;

        public HashTable(int BUCKET)
        {
            this.BUCKET = BUCKET;
            table = new LinkedLst<Pair<T, V>>[BUCKET];
            for (int i = 0; i < BUCKET; i++)
                table[i] = new LinkedLst<Pair<T, V>>();
            iSize = 0;
        }

        public int Size
        {
            get { return this.iSize; }
            set { this.iSize = value; }
        }

        public void Insert(T key, V value)
        {
            int index = HashFunction(key);
            table[index].AddFirst(new Pair<T, V>(key, value));
            iSize++;
        }

        public abstract void Remove(T key);
        public abstract V GetValue(T key);
        public abstract int HashFunction(T key);
    }
}
