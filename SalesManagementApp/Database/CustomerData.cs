using System;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;

namespace SalesManagementApp.Database
{
    public static class CustomerData
    {
        private static CustomerList customerList = Init();

        public static CustomerList GetInstance()
        {
            return customerList;
        }

        private static CustomerList Init()
        {
            customerList = new CustomerList();
            customerList.AddFromFile("CustomerData.txt");
            return customerList;
        }

        public static void SaveFile()
        {
            customerList.WriteFile("CustomerData.txt");
        }
    }
}