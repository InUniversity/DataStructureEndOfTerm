using SalesManagementApp.DataStructure;
using SalesManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.Database 
{
    public class SaleData
    {
        
        public static SaleList saleList = Init();

        private static SaleList Init()
        {
            SaleList list_ = new SaleList(100);
            list_.AddFromFile("EmployeeData.txt");
            return list_;
        }

        public static void SaveFile()
        {
            saleList.WriteFile("EmployeeData.txt");
        }
    }
}
