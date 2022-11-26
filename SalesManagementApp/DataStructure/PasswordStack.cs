using SalesManagementApp.DataStructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.DataStructure
{
    public class PasswordStack : StackCustom<string>
    {
        public PasswordStack() : base() { }
        ~PasswordStack() { }

        public PasswordStack NewNode(string item)
        {
            PasswordStack temp = new PasswordStack();
            temp.data = item;
            temp.Next = null;
            return temp;
        }
        public override void PushItem(string item)
        {
            PasswordStack temp = NewNode(item);
            temp.Next = this.Top;
            this.Top = temp;
        }
        public override string PopItem()
        {
            string temp = this.Top_.Data;
            this.Top = this.Top_.Next_;
            return temp;
        }

        
    }
}
