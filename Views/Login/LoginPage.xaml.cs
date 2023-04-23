using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Auth;
using Plugin.FirebaseAuth;
using Xamarin.Essentials;
using Firebase.Database;
using Firebase.Database.Query;
using finalProjectV1;

namespace LocalRestaurants
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Validate email and password
            if (string.IsNullOrWhiteSpace(emailEntry.Text) || string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                await DisplayAlert("Error", "Please enter your email and password.", "OK");
                return;
            }

            try
            {
                var authResult = await CrossFirebaseAuth.Current.Instance.SignInWithEmailAndPasswordAsync(emailEntry.Text, passwordEntry.Text);

                // Fetch user data
                var user = await FetchUserData(authResult.User.Uid);

                if (user != null)
                {
                    // Save the login state and user properties
                    Preferences.Set("isLoggedIn", true);
                    Preferences.Set("userId", user.UserId);
                    Preferences.Set("email", user.Email);
                    Preferences.Set("displayName", user.DisplayName);

                    // Navigate to the main page, passing the fetched user data
                    await Navigation.PushAsync(new MainPage(user));
                }
                else
                {
                    // Handle the case when the user object is null, e.g., display an error message
                    await DisplayAlert("Error", "Failed to fetch user data. Please try again.", "OK");
                }
            }
            catch (Plugin.FirebaseAuth.FirebaseAuthException ex)
            {
                // Display an error message
                await DisplayAlert("Error", $"Authentication failed: {ex.Message}", "OK");
            }
            catch (Exception ex)
            {
                // Display a general error message
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
        private async Task<User> FetchUserData(string userId)
        {
            var firebaseClient = new FirebaseClient("https://finalproject-f2591-default-rtdb.europe-west1.firebasedatabase.app/");
            var user = await firebaseClient
                .Child("users")
                .Child(userId)
                .OnceSingleAsync<User>();

            return user;
        }
        protected override bool OnBackButtonPressed()
        {
            return true; // Do not allow the hardware back button to navigate
        }
        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }  
    }
}
