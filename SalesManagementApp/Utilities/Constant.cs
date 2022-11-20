﻿using System;
namespace SalesManagementApp
{
    public static class Constant
    {
        public const int UP_ARROW = 38;
        public const int DOWN_ARROW = 40;
        public const int RIGHT_ARROW = 39;
        public const int LEFT_ARROW = 37;
        public const int ENTER_KEY = 13;
        public const char LINE_SYMBOL = (char)9552;

        public const string EMPTY_MESSAGE = "-> List is Empty!!!";
        public const string NOT_FOUND_MESSAGE = "-> Not found!!!";
        public const string DUPLICATED_MESSAGE = "-> Duplicated!!!";
        public const string SUCCESS_MESSAGE = "-> Success!!!";
        public const string NOT_VALID_MESSAGE = "-> Not valid!!!";

        public const string NOT_FOUND_PRODUCT_MESSAGE = "-> No products found!!!";
        public const string NOT_OUT_OF_TIME_PRODUCT_MESSAGE = "-> No products are out of date!!!";
        public const string QUIT_APP_MESSAGE = "-> Quit app, Goodbye!!!";

        public const int EXIT_APPLICATION = -1;
        public const int SIGNUP_ACTIVITY = 0;
        public const int SIGNIN_ACTIVITY = 1;
        public const int MAIN_ACTIVITY = 2;
        public const int PRODUCT_MANANGEMENT_ACTIVITY = 3;
        public const int EMPLOYEE_MANAGEMENT_ACTIVITY = 4;
        public const int CUSTOMER_MANAGEMENT_ACTIVITY = 5;
    }
}
