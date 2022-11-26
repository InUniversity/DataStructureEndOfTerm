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
    public abstract class StackCustom<T>
    {
        // protected T[] list_;
        protected T data;
        protected StackCustom<T>? Next;
        protected StackCustom<T>? Top;

        // properties
        public T Data
        {
            set { this.Data = value; }
            get { return this.data; }
        }
        public StackCustom<T>? Top_
        {
            get { return this.Top; }
        }
        public StackCustom<T>? Next_
        {
            get { return this.Next; }
        }
        //contructor
        public StackCustom()
        {
            //this.list_ = new T[capacity];
            this.Next = null;
            this.Top = null;
        }

        // method
        public bool IsEmpty()
        {
            return this.Top == null;
        }

        public abstract void PushItem(T item);
        public abstract T PopItem();


    }

}
