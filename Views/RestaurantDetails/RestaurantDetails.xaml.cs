using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using LocalRestaurants;
using static LocalRestaurants.Restaurants;

namespace LocalRestaurants
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantDetailPage : ContentPage
    {
        public RestaurantDetailPage(Restaurant restaurant)
        {
            InitializeComponent();

            NameLabel.Text = restaurant.Name;
            DescriptionLabel.Text = restaurant.Description;
            UserReviewLabel.Text = restaurant.UserReview;

            var position = new Position(restaurant.Latitude, restaurant.Longitude);
            RestaurantMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(1)));
            RestaurantMap.Pins.Add(new Pin { Position = position, Label = restaurant.Name });

            ImageCarousel.ItemsSource = restaurant.Images;
        }
    }
}
