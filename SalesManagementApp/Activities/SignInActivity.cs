using System;
using SalesManagementApp.DataStructure;

namespace SalesManagementApp.Activities
{
    public static class SignInActivity
    {
        private static StringCustom sUsername = "";
        private static StringCustom sPassword = "";

        public static int RunActivity()
        {
            // yêu cầu: nhập vào username và password
            // sau đó kiểm tra nếu đúng thì trả về số 1
            // nếu sai trả về số 0

            Console.Clear();
            Console.WriteLine("===========SIGN IN===========\n");
            Console.WriteLine("|Username:                  |");
            Console.WriteLine("|Password:                  |");
            Console.WriteLine("===========SIGN IN===========\n");

            return 2;
        }

        // phần này dùng hash table nên tạm thời chưa làm
        public static bool IsCorrectUser()
        {
            return true;
        }
    }
}

