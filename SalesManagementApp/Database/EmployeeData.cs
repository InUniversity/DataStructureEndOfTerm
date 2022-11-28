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
            LinkedLst<StringCustom> tempList = new LinkedLst<StringCustom>();
            tempList.AddLast("BIL0001");
            tempList.AddLast("BIL0002");
            tempList.AddLast("BIL0003");
            tempList.AddLast("BIL0004");
            tempList.AddLast("BIL0005");
            list_.AddLast(new Sale("SALE001", "Vo Thi Van Anh", "Nu",new Date(13,6,1997), "Dong Nai", "0999809872", 10000 , tempList));
            list_.AddLast(new Sale("SALE002", "Le Huu Tan", "Nam",new Date(25,05,1993), "Dong Thap", "0998727258", 10000, new LinkedLst<StringCustom>()));
            list_.AddLast(new Sale("SALE003", "Nguyen Thanh Vinh","Nam", new Date (16,01,1991), "Tp.Da Nang", "0773566113", 10000, new LinkedLst<StringCustom>()));
            list_.AddLast(new Sale("SALE004", "Ha Giang", "Nu", new Date(03,11,1991), "Tp. HCM", "0875694123", 10000, new LinkedLst<StringCustom>()));
            list_.AddLast(new Sale("SALE005", "Vo Vu Truong Giang", "Nam", new Date(24, 04, 1993), "Quang Nam", "0909547623",10000, new LinkedLst<StringCustom>()));
            list_.AddLast(new Sale("SALE006", "Le Thi My Giang", "Nu", new Date(06, 12, 1998), "Dong Thap", "0765443211", 10000, new LinkedLst<StringCustom>()));
            list_.AddLast(new Sale("SALE007", "Duong Quang Vinh", "Nam", new Date(25, 5, 1993), "Dong Thap", "0987654531", 10000, new LinkedLst<StringCustom>()));
            list_.AddLast(new Sale("SALE008", "Do Thi Ngoc Le", "Nu", new Date(9,9,1998), "Hai Phong", "0325454987", 10000, new LinkedLst<StringCustom>()));
            list_.AddLast(new Sale("SALE009", "Le Tan", "Nam", new Date(4, 1, 2003), "Tra Vinh", "0678945132", 10000, new LinkedLst<StringCustom>()));
            list_.AddLast(new Sale("SALE010", "Nguyen Quang Sang", "Nam",new Date(8,1,1998), "Kien Giang", "0931487565", 10000, new LinkedLst<StringCustom>()));
             
            return list_;
       }

       
    }
}
