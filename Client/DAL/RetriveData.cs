using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Client.DAL
{
    public static class RetriveData
    {
        public static async Task<Client.Entitys.Weather> GetWeather(string CityId)
        {
            using (WeatherService.GetWeatherClient client = new WeatherService.GetWeatherClient())
            {
                try
                {
                    var data = await client.GetWeatherByGeoIdAsync(CityId);
                   // WeatherService.Weather data = data1.re;

                    var result = new Entitys.Weather()
                    {
                        CityName=data.cityName,
                        Temp=data.temp,
                        Condition=data.condition,
                        IconPath=new Uri(data.IconPath)
                    };

                    return result;
                }
                catch
                {

                }
            }

            return null;
        }
    }
}
