﻿using System;
namespace SalesManagementApp.Activities
{
    public static class SignInActivity
    {
        private static string sUsername = "";
        private static string sPassword = "";

        public static int RunActivity()
        {
            // yêu cầu: nhập vào username và password
            // sau đó kiểm tra nếu đúng thì trả về số 1
            // nếu sai trả về số 0


            Console.WriteLine("===========SIGN IN===========\n");
            Console.WriteLine("|Username:                 |");
            Console.WriteLine("|Password:                 |");
            Console.WriteLine("===========SIGN IN===========\n");

            return 0;
        }

        // phần này dùng hash table nên tạm thời chưa làm
        public static bool IsCorrectUser()
        {
            return true;
        }
    }
}
