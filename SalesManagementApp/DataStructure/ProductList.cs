using System;
using SalesManagementApp.Models;

namespace SalesManagementApp.DataStructure
{
    public class ProductList : ArrayList<Product>
    {
        public ProductList(int size) : base(size)
        {
        }

        public override Product Get(int index)
        {
            return base.list_[index];
        }

        public override void AddItem(int index, Product value)
        {
            base.list_[index] = value;
        }

        public override void AddLast(Product item)
        {
            throw new NotImplementedException();
        }

        public override void AddRange(ArrayList<Product> sourceList)
        {
            throw new NotImplementedException();
        }

        public override void RemoveItem(int index)
        {
            throw new NotImplementedException();
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }

        public override int SearchItem(Product item)
        {
            throw new NotImplementedException();
        }
    }
}

