using System;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;

namespace SalesManagementApp.Database
{
	public class AccountData
	{
        public static AccountList accountList = Init();
        public static SaleAccount currentAccount = new SaleAccount();

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

