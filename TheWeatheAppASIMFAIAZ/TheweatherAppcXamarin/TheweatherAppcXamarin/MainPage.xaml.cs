using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TheweatherAppcXamarin
{

    //=============================================
    //Reference : Current Weather
    //Purpose: Get the current weather
    //Date: 4th Oct 2020 but updated that time to time while working on the code
    //Source: github
    //Author: Oludayo Alli / DevCrux
    //url: https://github.com/devcrux/CompleteWeatherApp
    //Adaption: The code I got from the lecture slide was not working properly
    //          that's why i followed that one. Still the current location is not constent.
    //         
    //=============================================

    public partial class MainPage : ContentPage
    {
        //private object jsonConvert;

        public MainPage()
        {
            InitializeComponent();
            GeoCord();


        }

        private String Location { get; set; } = "NEWCASTLE";  //Default value
        public double Latitude { get; set; }
        public double Longitude { get; set; } 




        private async void GeoCord()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);  //GeolocationRequest using Xamarin Essentials and Accuracy best to get exact loaction
                var location = await Geolocation.GetLocationAsync(request);

                if (Location != null)
                {
                    Latitude = location.Latitude;
                    Longitude = location.Longitude;
                    Location = await CityInfo(location);


                    CurrentWeatherInfo();



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }

        private async Task<string> CityInfo(Location location) //Created mathod from location
        {
            var places = await Geocoding.GetPlacemarksAsync(location);
            var currentPlace = places?.FirstOrDefault(); //If not Null

            if (currentPlace != null)

                return $"{currentPlace.Locality},{currentPlace.CountryName}";

            return null;

        }

        //=============================================
        // End reference
        //=============================================



        //=============================================
            //=============================================
            //Reference : Weather datas from JSON
            //Purpose: Get the weather datas
            //Date: 2nd Nov 2020 but updated time to time 
            //url: https://github.com/devcrux/CompleteWeatherApp
            //Adaption: Get the idea from some youtube videos but end up doing my own way
            //============================================= 
        //=============================================

        private async void CurrentWeatherInfo()
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={Location}&appid=8cc35d9d3498449474e57b068cbeb547&units=metric";
            var result = await APIStatements.Get(url);

            if (result.Successful)
            {
                try
                {
                    var weatherInfo = JsonConvert.DeserializeObject<weatherInfo>(result.Response);
                    city.Text = weatherInfo.name.ToUpper();
                    condition.Text = weatherInfo.weather[0].description.ToUpper();
                    temp.Text = weatherInfo.main.temp.ToString("0°");
                    visibility.Text = $"{weatherInfo.visibility}";
                    humidity.Text = $"{weatherInfo.main.humidity}%";
                    pressure.Text = $"{weatherInfo.main.pressure} hpa";
                    wind.Text = $"{weatherInfo.wind.speed} m/s";
                    cloudiness.Text = $"{weatherInfo.clouds.all}%";
                    tempMax.Text =$"{ weatherInfo.main.temp_max}°";
                    tempMin.Text = $"{ weatherInfo.main.temp_min}°";
                }

                catch(Exception)
                {
                    
                        await DisplayAlert("Weather Info", "Please try again", "OK");
                    }
                }
            else
                {
                    await DisplayAlert("Weather Info", "No weather information found", "OK");
                }
            }



        void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ButtonPage());
        }
    }
}


           
      