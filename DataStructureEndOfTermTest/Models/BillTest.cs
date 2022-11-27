using SalesManagementApp.DataStructure;
using SalesManagementApp.DataStructure.Base;
using SalesManagementApp.Models;

namespace DataStructureEndOfTermTest.Models;

public class BillTest
{
    [Test]
    public void InputTest()
    {
        LinkedLst<Pair<StringCustom, int>> _list = 
            new LinkedLst<Pair<StringCustom, int>>();
        Bill bill = new Bill("BIL0001", _list, "SAL0002", "CUS0001", new Date(3,5,2020));

        Assert.IsTrue(bill.ID.IsEquals("BIL0001"));
        Assert.AreEqual(bill.GetTotalPrice(), bill.Price);
    }
}