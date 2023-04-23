using static LocalRestaurants.Restaurants;
using System.Collections.Generic;

public class RestaurantData
{
    public List<Restaurant> GetAllRestaurants()
    {
        var restaurants = new List<Restaurant>();

        var restaurant = new Restaurant
        {

            Name = "Baan Thai Street Food",
            Description = "The atmosphere is warm and welcoming, and the staff are friendly and attentive.Plus the food turns out be incredible as well",
            UserReview = " The food was so delicious it makes me want to visit Thailand also the service was top-notch!",
            Latitude = 52.203010,
            Longitude = 0.126240,
            Images = new List<string>
            {
               "https://i.postimg.cc/qRcm3CGf/104-509860342.jpg",
               "https://i.postimg.cc/wv35QfLd/crispy.jpg",
               "https://i.postimg.cc/ZKz3WK7m/r710-Baan-Thai-Street-Food-seafood-2021-09.jpg",
            }
        };
        restaurants.Add(restaurant);

        var restaurant2 = new Restaurant
        {
            Name = "The Riverbar Steakhouse and Grill",
            Description = "A cozy bistro offering a wide variety of delicious dishes and a warm atmosphere.",
            UserReview = "I had a fantastic experience at The Great Bistro. The food was delicious, and the service was top-notch!",
            Latitude = 52.209190,
            Longitude = 0.117670,
            Images = new List<string>
            {
               "https://i.postimg.cc/K84MTJwy/varsity-PWF-1917.jpg",
               "https://i.postimg.cc/HxrxJp2g/3020d078-d262-42cc-a8fc-bedf07ffa402.jpg",
               "https://i.postimg.cc/MHV8g2n8/varsity-PWF-0901.jpg",
            }
        };
        restaurants.Add(restaurant2);

        var restaurant3 = new Restaurant
        {
            Name = "Pizza Palace",
            Description = "A family-friendly pizza place offering a wide selection of pizzas and other Italian dishes.",
            UserReview = "Pizza Palace has the best pizza in town. The crust is perfect, and the toppings are always fresh!",
            Latitude = 52.197979,
            Longitude = 0.143080,
            Images = new List<string>
            {
                "https://i.postimg.cc/zvVHCCFV/21c243cb-dd5a-40d6-b79f-35354f294d38-image-jpeg.jpg",
                "https://i.postimg.cc/c6G1vw9q/ta-img-20180106-140706.jpg",
                "https://i.postimg.cc/sD327dsb/image.jpg",
            }
        };
        restaurants.Add(restaurant3);

        var restaurant4 = new Restaurant
        {
            Name = "Namaste Village",
            Description = "A vibrant and welcoming Indian restaurant that offers a wide selection of traditional Indian dishes. From tandoori specialties to curry dishes, the menu is packed with flavorful options that are sure to satisfy any appetite.\r\n\r\n",
            UserReview = " Hands down the best Indian restaurant I've ever been to. The food is absolutely amazing - the spices are perfectly balanced, and everything is cooked to perfection.",
            Latitude = 52.212330,
            Longitude = 0.113050,
            Images = new List<string>
            {
                "https://i.postimg.cc/4d23PQVC/huge.jpg",
                "https://i.postimg.cc/FztHwsWG/0-Namaste-Village.jpg",
                "https://i.postimg.cc/Prjq4J85/16bb0a3ab8ea98cfe8906135767f7bf4.webp",
            }
        };
        restaurants.Add(restaurant4);

        var restaurant5 = new Restaurant
        {
            Name = "Tradizioni ",
            Description = "Tradizioni Cambridge is an authentic Italian restaurant that offers a warm and welcoming atmosphere and a menu packed with classic Italian dishes. From handmade pasta to wood-fired pizza",
            UserReview = "If you're looking for authentic Italian food, look no further than Tradizioni Cambridge. The pasta is handmade and cooked al dente, and the sauces are rich and flavorful",
            Latitude = 52.209830,
            Longitude = 0.114674,
            Images = new List<string>
            {
                "https://i.postimg.cc/YqQT6N5h/Screenshot-2023-04-17-232553.png",
                "https://i.postimg.cc/nzqGyMVh/tradizioni.jpg",
                "https://i.postimg.cc/xCN4c00w/image.jpg",
            }
        };
        restaurants.Add(restaurant5);

        var restaurant6 = new Restaurant
        {
            Name = "The Cambridge Tap",
            Description = "The Cambridge Tap is a cozy and welcoming pub that offers a wide selection of craft beers and pub fare. With a rotating selection of local and regional beers on tap, there's always something new to try, and the menu features classic pub favorites like fish and chips and burgers.",
            UserReview = "Tap is my go-to spot for craft beer and pub food. The beer selection is always top-notch, with a great mix of local and regional brews, and the staff are knowledgeable and always ready to offer recommendations",
            Latitude = 52.205071,
            Longitude = 0.118611,
            Images = new List<string>
            {
                "https://i.postimg.cc/SsXxRzYm/Cambridge-Tap-ext.jpg",
                "https://i.postimg.cc/cLXxccQs/our-upstairs-bar.jpg",
                "https://i.postimg.cc/RFfx21nJ/336711143-736401468033497-3053992738618696380-n.jpg",
                "https://i.postimg.cc/WzGjqmNc/our-main-bar.jpg",
                
            }
        };
        restaurants.Add(restaurant6);

        return restaurants;
    }
}
