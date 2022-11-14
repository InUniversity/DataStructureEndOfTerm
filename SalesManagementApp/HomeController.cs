using SalesManagementApp.Activities;

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
            try
            {
                int activityOrder;
                activityOrder = SignInActivity.RunActivity();
                while (true)
                {
                    switch (activityOrder)
                    {
                        case 0:
                            activityOrder = SignUpActivity.RunActivity();
                            break;
                        case 1:
                            activityOrder = SignInActivity.RunActivity();
                            break;
                        case 2:
                            activityOrder = MainActivity.RunActivity();
                            break;
                        case 3:
                            activityOrder = ProductManangementActivity.RunActivity();
                            break;
                        case 4:
                            activityOrder = EmployeeManagementActivity.RunActivity();
                            break;
                        case 5:
                            activityOrder = CustomerManagementActivity.RunActivity();
                            break;
                        default:
                            Console.WriteLine("Quit Application!!!");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}