using System;
using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Database
{
	public class AccountData
	{
        private static AccountList accountHash = Init();

        public static AccountList GetInstance()
        {
            return accountHash;
        }

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

