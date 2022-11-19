using System;
using System.Xml.Linq;
using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Models
{
    public class ManagerAccount
    {

        private StringCustom sUsername;
        private StringCustom sPassword;
        private int iManagerID;

        public ManagerAccount()
        {
            sUsername = "unknow";
            sPassword = null;
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

        public void Print()
        {
            Console.WriteLine("Name: {0}", sUsername);
            Console.WriteLine("Password: {0}", sPassword);
            Console.WriteLine("ID: {0}", iManagerID);
        }

        public static bool Exits(ManagerAccount managerAccount)
        {
            return true;
        }

        public static bool CheckValidAccount(ManagerAccount managerAccount)
        {
            return IsValidUsername(managerAccount.Username) &&
                IsValidPassword(managerAccount.Password) &&
                IsValidID(managerAccount.ManagerID);
        }

        /// To Do
        public static bool IsValidUsername(StringCustom name)
        {
            return name != null;
        }

        public static bool IsValidPassword(StringCustom password)
        {
            return false;
        }

        public static bool IsValidID(int id)
        {
            // khong co trong hash map
            return true;
        }

        public void InputPassword()
        {
            throw new NotImplementedException();
        }
    }
}

