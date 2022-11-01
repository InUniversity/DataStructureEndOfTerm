using System;
using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;

namespace SalesManagementApp.Database
{
    public static class ManagerData
    {

        public static ManagerList managerList = Init();

        private static ManagerList Init()
        {
            ManagerList list_ = new ManagerList(100);
            list_.AddLast(new Manager(123456, "Le Hoang Long", 10000));
            list_.AddLast(new Manager(123457, "Le Hoang Lan", 15000));
            list_.AddLast(new Manager(123458, "Hoan Thi Hue", 30000));
            list_.AddLast(new Manager(123459, "Le Van An", 50000));
            list_.AddLast(new Manager(123410, "Nguyen Duy Nhat", 9000));
            list_.AddLast(new Manager(123411, "Ly Minh Hai", 1000000));
            list_.AddLast(new Manager(123412, "Le Phuong Bao", 5000));
            list_.AddLast(new Manager(123413, "Le Minh", 10500));
            list_.AddLast(new Manager(123414, "Thu Ha", 19000));
            list_.AddLast(new Manager(123415, "Tuan Tu", 10200));
            return list_;
        }
    }
}

