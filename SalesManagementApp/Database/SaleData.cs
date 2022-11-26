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
        
       public static SaleList employeeList = Init();

       private static SaleList Init()
       {
            SaleList list_ = new SaleList(100);
            //list_.AddLast(new Sale(900001, "Nguyen Thanh An", "Nam", new Date(05,12,2000), "Kien Giang", "0999513678", 15000, 15, 30))  ;
            //list_.AddLast(new Sale(900002, "Vo Van Anh", "Nu",new Date(13,6,1997), "Dong Nai", "0999809872", 25000, 20, 30));
            //list_.AddLast(new Sale(900003, "Le Huu Tan", "Nam",new Date(25,05,1993), "Dong Thap", "0998727258", 9000, 9, 28));
            //list_.AddLast(new Sale(900004, "Nguyen Thanh Vinh","Nam", new Date (16,01,1991), "Tp.Da Nang", "0773566113", 10000, 10, 24));
            //list_.AddLast(new Sale(900005, "Ha Giang", "Nu", new Date(03,11,1991), "Tp. HCM", "0875694123", 27000, 27, 30));
            //list_.AddLast(new Sale(900006, "Vo Vu Truong Giang", "Nam", new Date(24, 04, 1993), "Quang Nam", "0909547623",30000, 30, 29));
            //list_.AddLast(new Sale(900007, "Le Thi My Giang", "Nu", new Date(06, 12, 1998), "Dong Thap", "0765443211", 27000, 27, 30));

             
            return list_;
       }

       
    }
}
