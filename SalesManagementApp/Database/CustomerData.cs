﻿using System;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;

namespace SalesManagementApp.Database
{
    public class CustomerData
    {
        public static CustomerHash customerHash = Init();

        private static CustomerHash Init()
        {
            customerHash = new CustomerHash(111);
            customerHash.AddFromFile("CustomerData.txt");
            return customerHash;
        }

        public static void SaveFile()
        {
            customerHash.WriteFile("CustomerData.txt");
        }
    }
}