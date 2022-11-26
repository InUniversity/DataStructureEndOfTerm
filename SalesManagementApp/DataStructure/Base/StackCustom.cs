using Microsoft.VisualBasic.FileIO;
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
        public StackCustom() {}

        // method
        public bool IsEmpty()
        {
            return this.TopItem == null;
        }

        public void Push(T item)
        {
            StackNode<T> temp = new StackNode<T>(item);
            temp.next = this.TopItem;
            this.TopItem = temp;
        }

        public void Pop()
        {
            this.TopItem = this.TopItem.next;
        }

        public T Top()
        {
            return this.TopItem.value;
        }


    }
}
