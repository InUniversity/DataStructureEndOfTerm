using System;
using SalesManagementApp.DataStructure;

namespace DataStructureEndOfTermTest.DataStructure
{
	public class LinkLstTest
	{
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            LinkedLst<int> _list = new LinkedLst<int>();
            _list.AddLast(10);
            _list.AddLast(11);
            _list.AddLast(12);
            _list.AddLast(13);
            Assert.AreEqual(4, _list.Size);
        }
    }
}

