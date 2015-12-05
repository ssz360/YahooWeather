using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTest
{
    [TestClass]
    public class ClientTesting
    {
        [TestMethod]
        public void GetWeatherByGeoIdTest()
        {
            Client.WeatherService.Weather wInfo = new Client.WeatherService.Weather()
            {
                cityName = "tehran",
                condition = "suny",
                IconPath = "",
                temp = "30"
            };

            Mock<Client.WeatherService.IGetWeather> wcfMock = new Mock<Client.WeatherService.IGetWeather>();
            wcfMock.Setup(s => s.GetWeatherByGeoId("tehran")).Returns(wInfo);

            //Client.Entitys.Weather wInfo = Client.DAL.RetriveData.GetWeather("tehran").Result;
            var result = wcfMock.Object;

            var r= result.GetWeatherByGeoId("tehran");

            Assert.IsNotNull(r);
            Assert.AreEqual(r.cityName.ToLower(), "tehran");
        }
    }

}
