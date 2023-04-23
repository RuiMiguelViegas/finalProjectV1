using Xamarin.Forms;
using finalProjectV1;
using LocalRestaurants;
using Xamarin.Essentials;

namespace finalProjectV1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //ClearUserData();
            // Check if the user is logged in
            bool isLoggedIn = Preferences.Get("isLoggedIn", false);

            if (isLoggedIn)
            {
                string userId = Preferences.Get("userId", string.Empty);
                string email = Preferences.Get("email", string.Empty);
                string displayName = Preferences.Get("displayName", string.Empty);

                User loggedInUser = new User
                {
                    UserId = userId,
                    Email = email,
                    DisplayName = displayName
                };

                MainPage = new NavigationPage(new MainPage(loggedInUser));
            }
            else
            {
                // Navigate to the sign-up page if the user is not logged in
                MainPage = new NavigationPage(new LoginPage());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

}

