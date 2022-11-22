using System;
using System.Xml.Linq;
using SalesManagementApp.Database;
using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Models
{
    public class ManagerAccount
    {

        private StringCustom sUsername;
        private StringCustom sPassword;
        private int iManagerID;

        private const int ID_WITH_MIN_VALUE = 123456;

        public ManagerAccount()
        {
            sUsername = "unknow";
            sPassword = "unknow";
            iManagerID = 0;
        }

        public ManagerAccount(StringCustom username, StringCustom password, int managerID)
        {
            sUsername = username;
            sPassword = password;
            iManagerID = managerID;
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

        public int ManagerID
        {
            get { return this.iManagerID; }
            set { this.iManagerID = value; }
        }

        public static bool AccountDate { get; private set; }

        public Manager GetManager()
        {
            return ManagerData.managerList.SearchItemWithID(iManagerID);
        }

        public void Print()
        {
            Console.WriteLine("Name: {0}", sUsername);
            Console.WriteLine("Password: {0}", sPassword);
            Console.WriteLine("ID: {0}", iManagerID);
        }

        public static bool Exits(ManagerAccount managerAccount)
        {
            ManagerAccount temp = AccountData
                .GetInstance()
                .GetValue(managerAccount.Username);

            return temp != null && managerAccount.Password.IsEqual(temp.Password);
        }

        public static bool CheckValidAccount(ManagerAccount managerAccount)
        {
            return IsValidUsername(managerAccount.Username) &&
                IsValidPassword(managerAccount.Password) &&
                IsValidID(managerAccount.ManagerID);
        }

        public static bool IsValidUsername(StringCustom username)
        {
            return username != null;
        }

        // to do
        public static bool IsValidPassword(StringCustom password)
        {
            return true;
        }

        // check duplicate
        public static bool IsValidID(int id)
        {
            return id >= ID_WITH_MIN_VALUE && AccountData.GetInstance().Search(id) == null;
        }

        // to do
        public void InputPassword()
        {
            sPassword = Console.ReadLine();
        }
    }
}