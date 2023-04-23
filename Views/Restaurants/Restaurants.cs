using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LocalRestaurants
{
    public class Restaurants : ContentPage
    {
        public class Restaurant
        {
            public string Name { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string UserReview { get; set; }
            public string Description { get; set; }
            public List<string> Images { get; set; }
            public string PreviewImage => Images?.FirstOrDefault();

        }
    }
}