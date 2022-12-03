using NUnit.Framework;
using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;

namespace DataStructureEndOfTermTest.DataStructure;

public class CustomerHashTest
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void ReadFileTest01()
    {
        CustomerHash customerHash = new CustomerHash(111);
        customerHash = CustomerData.customerHash;
        Assert.AreEqual(8, customerHash.Size);
    }
    
    [Test]
    public void FindByNameTest01()
    {
        CustomerHash temp = new CustomerHash(111);
        temp.Insert("CUS0001", new Customer("CUS0001", "Hoang Long",
            "Nam", new Date(03, 10, 2003), 
            "Ap 14", "09123586", 3000, "Dong"));
        
        temp.InsertNoDuplicate(new Customer("CUS0001", "Hoang Long",
            "Nam", new Date(03, 10, 2003), 
            "Ap 14", "09123586", 3000, "Dong"));

        Assert.AreEqual(1, temp.Size);
        Assert.IsTrue(temp.FindByName("Hoang Long") != null);
    }
    
    [Test]
    public void RemoveTest01()
    {
        CustomerHash customerHash = CustomerData.customerHash;
        customerHash.Insert("CUS0001", 
            new Customer("CUS0001", "Hoang Hoang", "Nam", new Date(1, 1, 2003), 
                "Ap 1", "091239743", 300, "Vang"));
        customerHash.Remove("CUS0001");
        Assert.AreEqual(0, customerHash.Size);
    }
}