﻿using SalesManagementApp.Activities;
using SalesManagementApp.Database;
using SalesManagementApp.Models;

namespace SalesManagementApp
{
    class HomeController
    {
        static void Main(string[] args)
        {
            // -1 = exit application
            // 0 = SignUpActivity
            // 1 = SignInActivity
            // 2 = MainAcitivty
            // 3 = ProductManangementActivity
            // 4 = EmployeeManagementActivity
            // 5 = CustomerManagementActivity
            int activityOrder = Constant.MAIN_ACTIVITY;
            while (true)
            {
                switch (activityOrder)
                {
                    case Constant.SIGNUP_ACTIVITY:
                        activityOrder = SignUpActivity.RunActivity();
                        break;
                    case Constant.SIGNIN_ACTIVITY:
                        activityOrder = SignInActivity.RunActivity();
                        break;
                    case Constant.MAIN_ACTIVITY:
                        activityOrder = MainActivity.RunActivity();
                        break;
                    case Constant.INVENTORY_MANANGEMENT_ACTIVITY:
                        activityOrder = InventoryManangementActivity.RunActivity();
                        break;
                    case Constant.EMPLOYEE_MANAGEMENT_ACTIVITY:
                        activityOrder = SalesManagementActivity.RunActivity();
                        break;
                    case Constant.CUSTOMER_MANAGEMENT_ACTIVITY:
                        activityOrder = CustomerManagementActivity.RunActivity();
                        break;
                    case Constant.SALES_ACTIVITY:
                        activityOrder = SalesActivity.RunActivity();
                        break;
                    default:
                        Console.WriteLine(Constant.QUIT_APP_MESSAGE);

                        // save file after run program
                        CustomerData.SaveFile();
                        AccountData.SaveFile();
                        BillData.SaveFile();
                        Console.ReadKey();
                        return;
                }
            }
        }

    }
}