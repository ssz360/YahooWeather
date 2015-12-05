using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.BLL
{
    public class PreparingData
    {
        public static async Task<Client.Entitys.Weather> AsyncGetData(System.Windows.FrameworkElement loading, string cityName)
        {
            Client.Entitys.Weather weatherInfo;
            loading.Visibility = Visibility.Visible;
            weatherInfo = await Task.Run(() => Client.DAL.RetriveData.GetWeather(cityName));
            loading.Visibility = Visibility.Hidden;
            return weatherInfo;
        }
    }
}
