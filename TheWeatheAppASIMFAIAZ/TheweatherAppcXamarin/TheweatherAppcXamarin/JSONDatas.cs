using System;
using System.Collections.Generic;
using System.Text;
namespace TheweatherAppcXamarin


    //JSON datas gets the format from OpenWeather Map

{
    public class ForecastInfo

    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List[] list { get; set; }
        public City city { get; set; }
    }

    public class City
    {

        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }

    }

    public class List
    {
        public Main main { get; set; }
        public Weather[] weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Sys sys { get; set; }

    }

    public class Main
    {
        public float temp { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }



    public class weatherInfo
    {
        public Coord coord { get; set; }
        public Weather[] weather { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public Sys sys { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }

    public class Coord
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }


    public class Wind
    {
        public float speed { get; set; }
    }


    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public string country { get; set; }
    }

    public class Weather
    {
        public string main { get; set; }
        public string description { get; set; }
    }

}


