using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static LocalRestaurants.Restaurants;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;
using Firebase.Auth;
using Plugin.FirebaseAuth;
using Xamarin.Essentials;


namespace LocalRestaurants
{
    public partial class MainPage : ContentPage
    {
        private User _user;

        public MainPage(User user)
        {
            InitializeComponent();
            _user = user;
            DisplayUserName();
            NavigationPage.SetHasNavigationBar(this, false);

            RestaurantData restaurantData = new RestaurantData();
            Restaurants = new ObservableCollection<Restaurant>(restaurantData.GetAllRestaurants());


            // Set the BindingContext to the MainPage instance
            BindingContext = this;
        }

        private void DisplayUserName()
        {
            // Update the UI element (e.g., a Label) with the user's display name
            UserNameLabel.Text = $"Shall we eat, {_user.DisplayName}! (user)";
        }
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(searchBar.Text))
            {
                UpdateRestaurants(Restaurants.ToList());
            }
        }
        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            var query = searchBar.Text?.ToLowerInvariant() ?? string.Empty;
            var filteredRestaurants = GetFilteredRestaurants(query);
            UpdateRestaurants(filteredRestaurants);
        }

        private List<Restaurant> GetFilteredRestaurants(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                // Return all restaurants when the search bar is empty
                return Restaurants.ToList();
            }
            else
            {
                // Filter the restaurants based on the search term
                return Restaurants.Where(restaurant => restaurant.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
        }

        private void UpdateRestaurants(List<Restaurant> filteredRestaurants)
        {
            collectionView.ItemsSource = filteredRestaurants;
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            // Add your filter functionality here
        }
        private async void OnRestaurantTapped(object sender, EventArgs e)
        {
            var tappedImage = sender as Image;
            if (tappedImage != null)
            {
                var tappedRestaurant = tappedImage.BindingContext as Restaurant;
                if (tappedRestaurant != null)
                {
                    await Navigation.PushAsync(new RestaurantDetailPage(tappedRestaurant));
                }
            }

        }
        public ObservableCollection<Restaurant> Restaurants { get; set; }

        protected override bool OnBackButtonPressed()
        {
            return true; // Do not allow the hardware back button to navigate
        }
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            // Sign out the user
            CrossFirebaseAuth.Current.Instance.SignOut();

            Preferences.Set("isLoggedIn", false);
            Preferences.Remove("userId");
            Preferences.Remove("email");
            Preferences.Remove("displayName");

            // Navigate back to the login page
            await Navigation.PushAsync(new LoginPage());
            Navigation.RemovePage(Navigation.NavigationStack[0]);
        }

    }

}
