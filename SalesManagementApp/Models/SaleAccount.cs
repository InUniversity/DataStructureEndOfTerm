using System;
using System.Xml.Linq;
using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Models
{
    public class SaleAccount
    {

        private StringCustom sUsername;
        private StringCustom sPassword;
        private StringCustom sSaleID;

        private const int ID_WITH_MIN_VALUE = 123456;

        public SaleAccount()
        {
            sUsername = "unknow";
            sPassword = "unknow";
            sSaleID = "unknow";
        }

        public SaleAccount(StringCustom username, StringCustom password, StringCustom saleID)
        {
            sUsername = username;
            sPassword = password;
            sSaleID = saleID;
        }

        public StringCustom Username
        {
            get { return this.sUsername; }
            set { this.sUsername = value; }
        }

        public StringCustom Password
        {
            get { return this.sPassword; }
            set { this.sPassword = value; }
        }

        public StringCustom SaleID
        {
            get { return this.sSaleID; }
            set { this.sSaleID = value; }
        }

        public bool IsEquals(SaleAccount item)
        {
            return sSaleID == item.SaleID;
        }

        public void Print()
        {
            Console.WriteLine("Name: {0}", sUsername);
            Console.WriteLine("Password: {0}", sPassword);
            Console.WriteLine("ID: {0}", sSaleID);
        }

        public static bool CheckValidAccount(SaleAccount saleAccount)
        {
            return IsValidUsername(saleAccount.Username) &&
                IsValidPassword(saleAccount.Password) &&
                IsValidID(saleAccount.SaleID);
        }

        public static bool IsValidUsername(StringCustom username)
        {
            return username != null;
        }

        // to do
        public static bool IsValidPassword(StringCustom password)
        {
            return password != null;
        }

        // check duplicate
        public static bool IsValidID(StringCustom id)
        {
            return id != null && AccountData.accountList.FindById(id) == null;
        }

        // to do
        public void InputPassword()
        {
            char c;
            do
            {
                c = Console.ReadKey(true).KeyChar;
                if (c == 13) break;
                if (c == 8)
                {
                    Console.WriteLine("\b \b");
                    //  sPassword.
                }
                else
                {
                    Console.Write("*");
                    sPassword += c;
                }
            } while (c != 13);
        }
    }
}