using System;
using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Database
{
	public class AccountData
	{
        public static AccountList accountList = Init();

        private static AccountList Init()
        {
            accountList = new AccountList();
            accountList.AddFromFile("AccountData.txt");
            return accountList;
        }

        public static void SaveFile()
        {
            accountList.WriteFile("AccountData.txt");
        }
    }
}

