using System;
using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Database
{
	public class AccountData
	{
        private static ManagerAccountHash accountHash = Init();

        public static CustomerList GetInstance()
        {
            return accountHash;
        }

        private static CustomerList Init()
        {
            accountHash = new ManagerAccountHash(1111);
            accountHash.AddFromFile("CustomerData.txt");
            return accountHash;
        }

        public static void SaveFile()
        {
            accountHash.WriteFile("CustomerData.txt");
        }
    }
}

