using System;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;

namespace SalesManagementApp.Database
{
    public static class CustomerData
    {
        public static CustomerList customerList = Init();

        public static CustomerList Init()
        {
            CustomerList list_ = new CustomerList();
            list_.AddFromFile("CustomerData.txt");
            //list_.AddLast(new Customer(90001, "Hoang Giang",
            //    "Nu", new Date(10, 10, 2003), "ap 1", "099999911",
            //    14, 1333, "Vang", new Date(1, 1, 2022)));

            //list_.AddLast(new Customer(90002, "Le Thi Dieu",
            //    "Nam", new Date(19, 1, 2000), "ap 5", "099999912",
            //    9, 900, "Dong", new Date(1, 1, 2021)));

            //list_.AddLast(new Customer(90003, "Ly Nha",
            //    "Nu", new Date(10, 10, 2003), "ap 10", "099999913",
            //    4, 200, "Sat", new Date(10, 1, 2022)));

            //list_.AddLast(new Customer(90004, "Thien An",
            //    "Nam", new Date(10, 9, 1999), "ap 11", "099999914",
            //    30, 1500, "bach kim", new Date(10, 9, 2022)));

            //list_.AddLast(new Customer(90005, "Thuy Dung",
            //    "Nu", new Date(10, 10, 2003), "ap 10", "099999915",
            //    16, 1231, "Vang", new Date(8, 10, 2022)));

            //list_.AddLast(new Customer(90006, "Duy Khang",
            //    "Nu", new Date(10, 10, 2003), "ap 10", "099999916",
            //    15, 1300, "Vang", new Date(1, 1, 2022)));
            return list_;
        }
    }
}

