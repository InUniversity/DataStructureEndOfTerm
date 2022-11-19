using System;
namespace SalesManagementApp.DataStructure.Base
{
    public class Pair<T, V>
    {
        public T value1;
        public V value2;

        public Pair(T value1, V value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }
    }
}

