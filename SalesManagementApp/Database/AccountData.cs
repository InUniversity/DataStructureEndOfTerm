using System;
using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Database
{
	public class AccountData
	{
        private static ManagerAccountHash accountHash = Init();

        public static ManagerAccountHash GetInstance()
        {
            return accountHash;
        }

        private static ManagerAccountHash Init()
        {
            accountHash = new ManagerAccountHash(111);
            accountHash.AddFromFile("AccountData.txt");
            return accountHash;
        }

        public static void SaveFile()
        {
            accountHash.WriteFile("AccountData.txt");
        }
    }
}

