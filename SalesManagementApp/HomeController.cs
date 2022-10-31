using SalesManagementApp.Activities;

namespace SalesManagementApp
{
    class HomeController
    {
        static void Main(string[] args)
        {
            // -1. exit application - 0. SignUpActivity - 1. SignInActivity - 2. MainAcitivty
            try
            {
                int activityOrder;
                activityOrder = SignInActivity.RunActivity();
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
                    default:
                        Console.WriteLine("Quit Application!!!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}