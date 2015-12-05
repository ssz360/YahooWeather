using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services
{
    [ServiceContract]
    public interface IGetWeather
    {
        [OperationContract]
        Weather GetWeatherByGeoId(string CityName);



    }

    [DataContract]
    public class Weather
    {

        [DataMember]
        public string temp
        {
            get;
            set;
        }
        [DataMember]
        public string condition
        {
            get;
            set;
        }
        [DataMember]
        public string cityName
        {
            get;
            set;
        }
        [DataMember]
        public string IconPath
        {
            get;
            set;
        }


    }

}
