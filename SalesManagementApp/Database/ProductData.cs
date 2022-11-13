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
            list_.AddLast(new Product(123, "BanhQuy", 31, new Date(10, 10, 2022), new Date(1, 1, 2023)));
            list_.AddLast(new Product(123, "Banh Chuoi", 90, new Date(9, 9, 2022), new Date(2, 2, 2023)));
            list_.AddLast(new Product(123, "Banh Bao", 35, new Date(8, 8, 2022), new Date(4, 4, 2023)));
            list_.AddLast(new Product(123, "Ca Hop", 312, new Date(7, 7, 2022), new Date(5, 5, 2023)));
            list_.AddLast(new Product(123, "Hop Vit", 77, new Date(6, 6, 2022), new Date(6, 6, 2023)));
            list_.AddLast(new Product(123, "Hot Ga", 88, new Date(5, 5, 2022), new Date(7, 7, 2023)));
            list_.AddLast(new Product(124, "Sua Chua", 99, new Date(4, 4, 2022), new Date(8, 8, 2023)));
            list_.AddLast(new Product(124, "Tra Sua", 99, new Date(3, 3, 2022), new Date(9, 9, 2027)));
            return list_;
        }
    }
}

