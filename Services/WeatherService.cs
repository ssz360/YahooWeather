using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class WeatherService : IGetWeather
    {


        public Weather GetWeatherByGeoId(string CityName)
        {
            Weather result = null;
            using (WebClient client = new WebClient())
            {
                try
                {

                    //string data = client.DownloadString("https://query.yahooapis.com/v1/public/yql?q=select%20item.condition%20from%20weather.forecast%20where%20woeid%20%3D%" + CityId + "%20AND%20u%3D%22c%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");
                    string data = client.DownloadString("https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22"+CityName+"%22)%20and%20u%3D%22c%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys");


                    JObject jobject = JObject.Parse(data);
                    JToken temp = jobject.SelectToken("query.results.channel.item.condition.temp");
                    JToken cityName = jobject.SelectToken("query.results.channel.item.title");
                    JToken con = jobject.SelectToken("query.results.channel.item.condition.text");
                    JToken iconPath = jobject.SelectToken("query.results.channel.item.description");

                    var cName = Regex.Match(cityName.Parent.First.ToString(), "(?<=Conditions for ).*(?=,)").Value;
                    var iPath = Regex.Match(iconPath.Parent.First.ToString(), "(?<=src=\").*(?=\")").Value;

                    var temprature = temp.Parent.First.ToString();
                    string condition = con.Parent.First.ToString();

                    result = new Weather()
                    {
                        temp=temprature,
                        cityName=cName,
                        IconPath=iPath,
                        condition=condition
                    };
                    return result;
                    
                }
                catch
                {

                }
            }

            return result;
        }
    }
}
