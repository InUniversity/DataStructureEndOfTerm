using System;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;

namespace SalesManagementApp.Database
{
    public static class ProductData
    {
        public static ProductList productList = Init();

        private static ProductList Init()
        {
            ProductList list_ = new ProductList(100);
            list_.AddFromFile("ProductData.txt");
            return list_;
        }

        public static void SaveFile()
        {
            productList.WriteFile("ProductData.txt");
        }
    }
}

