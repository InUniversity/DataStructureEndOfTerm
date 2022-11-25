using System;
using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Database
{
	public class AccountData
	{
        public static AccountList accountHash = Init();

        private static AccountList Init()
        {
            accountHash = new AccountList();
            accountHash.AddFromFile("AccountData.txt");
            return accountHash;
        }

        public static void SaveFile()
        {
            accountHash.WriteFile("AccountData.txt");
        }
    }
}

