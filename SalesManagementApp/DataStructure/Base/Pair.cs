using System;
namespace SalesManagementApp.DataStructure.Base
{
    public class Pair<T, V>
    {
        public T key { get; set; }
        public V value { get; set; }

        public Pair(T key, V value)
        {
            this.key = key;
            this.value = value;
        }
    }
}

