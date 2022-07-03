using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TheweatherAppcXamarin
{
    
    public partial class ButtonPage : ContentPage
    {
        
        //private object jsonConvert;

        public ButtonPage()
        {
            InitializeComponent();
            
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            CurrentWeatherInfo();
        }



        //=============================================
        //Reference : API key
        //Purpose: Get the API key
        //Date: 31st Oct 2020 
        //Source: OpenWeatherMap
        //url: http://api.openweathermap.org
        //=============================================

        //=============================================
        //Reference : API key
        //Purpose: Set the API key to geth the weather data
        //Date: 31st Oct 2020 but updated that time to time while working on the code
        //Source: github
        //Author: Oludayo Alli / DevCrux
        //url: https://github.com/devcrux/CompleteWeatherApp
        //Adaption: I knew that before how to set that just referencing because I was
        //          unsure how to use the APIStatement class here
        //=============================================


        private async void CurrentWeatherInfo()
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={_cityEntry.Text}&appid=8cc35d9d3498449474e57b068cbeb547&units=metric";
            var result = await APIStatements.Get(url);


            //=============================================
            // End reference
            //=============================================


            //=============================================
            //Reference : Weather datas from JSON
            //Purpose: Get the weather datas
            //Date: 2nd Nov 2020 but updated time to time 
            //url: https://github.com/devcrux/CompleteWeatherApp
            //Adaption: Get the idea from some youtube videos but end up doing my own way
            //=============================================



            if (result.Successful)
            {
                try
                {
                    var weatherInfo = JsonConvert.DeserializeObject<weatherInfo>(result.Response);
                    city.Text = weatherInfo.name.ToUpper();
                    country.Text = weatherInfo.sys.country.ToUpper();
                    condition.Text = weatherInfo.weather[0].description.ToUpper();
                    temp.Text = weatherInfo.main.temp.ToString("0°");
                    tempMax.Text = $"{ weatherInfo.main.temp_max}° Max Temp";
                    tempMin.Text = $"{ weatherInfo.main.temp_min}° Min Temp";


                }

                catch (Exception)
                {

                    await DisplayAlert("Weather Info", "Please try again", "OK");
                }
            }
            else
            {
                await DisplayAlert("Weather Info", "Please check the name", "OK");
            }
        }


    }
}
