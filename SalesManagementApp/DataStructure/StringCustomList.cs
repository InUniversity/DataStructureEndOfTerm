using System;
namespace SalesManagementApp.DataStructure
{
	public class StringCustomList : LinkedLst<StringCustom>
	{

		public StringCustomList() : base()
		{
		}

        public override void AddNode(int index, StringCustom item)
        {
            throw new NotImplementedException();
        }

        public override void AddRange(LinkedLst<StringCustom> sourceList)
        {
            throw new NotImplementedException();
        }

        public override Node<StringCustom>? GetNode(int index)
        {
            throw new NotImplementedException();
        }

        public override int IndexOf(StringCustom item)
        {
            throw new NotImplementedException();
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }

        public override void Remove(StringCustom item)
        {
            throw new NotImplementedException();
        }

        public override void Remove(int index)
        {
            throw new NotImplementedException();
        }

        public override void RemoveLast()
        {
            throw new NotImplementedException();
        }

        public override Node<StringCustom>? SearchNode(StringCustom item)
        {
            throw new NotImplementedException();
        }
    }
}