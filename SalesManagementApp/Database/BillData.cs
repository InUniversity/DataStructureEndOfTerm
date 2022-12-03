using System;
using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Database
{
	public static class BillData
	{

		public static BillHash billHash = Init();

		private static BillHash Init()
		{
			BillHash billHash = new BillHash(1111);
			billHash.AddFromFile("BillData.txt");
			return billHash;
		}

		public static void SaveFile()
		{
			billHash.WriteFile("BillData.txt");
        }
	}
}

