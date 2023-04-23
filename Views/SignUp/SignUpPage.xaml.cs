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
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }
        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            try
            {
                var authResult = await CrossFirebaseAuth.Current.Instance.CreateUserWithEmailAndPasswordAsync(emailEntry.Text, passwordEntry.Text);

                // Update the user's display name
                var profileUpdates = new Plugin.FirebaseAuth.UserProfileChangeRequest
                {
                    DisplayName = displayNameEntry.Text,
                };
                await authResult.User.UpdateProfileAsync(profileUpdates);

                // Save the user's information to the Firebase Realtime Database
                var user = new User
                {
                    UserId = authResult.User.Uid,
                    Email = emailEntry.Text,
                    DisplayName = displayNameEntry.Text
                };
                await SaveUserData(user);

                // Navigate to the main page, passing the fetched user data
                await Navigation.PushAsync(new MainPage(user));
            }
            catch (Plugin.FirebaseAuth.FirebaseAuthException ex)
            {
                // Display an error message
                await DisplayAlert("Error", ex.Message, "OK");
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
        private async Task SaveUserData(User user)
        {
            var firebaseClient = new FirebaseClient("https://finalproject-f2591-default-rtdb.europe-west1.firebasedatabase.app/");
            await firebaseClient
                .Child("users")
                .Child(user.UserId)
                .PutAsync(user);
        }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}
