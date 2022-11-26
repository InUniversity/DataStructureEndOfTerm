using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.DataStructure.Base
{
    public class StackCustom<T>
    {
        public StackNode<T> TopItem { get; set; }

        public int Size { get; set; }

        //contructor
        public StackCustom()
        {
            //this.list_ = new T[capacity];
            
        }

        // method
        public bool IsEmpty()
        {
            return this.TopItem == null;
        }

        public void Push(T item)
        {
            
        }

        public void Pop()
        {

        }

        public T Peek()
        {

        }


    }
}
