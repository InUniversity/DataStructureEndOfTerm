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
            list_.AddLast( new Product(123, "Banh Quy", 30, new Date(10, 10, 2022), new Date(1, 1, 2023)) );
            return list_;
        }
    }
}

