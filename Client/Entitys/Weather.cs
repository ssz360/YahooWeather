
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Entitys
{


    public class Weather : INotifyPropertyChanged
    {
        string _temp;

        public string Temp
        {
            get
            {
                return _temp;
            }
            set
            {
                _temp = value;
                propertyChange("Temp");
            }
        }
        string _condition;

        public string Condition
        {
            get
            {
                return _condition;
            }
            set
            {
                _condition = value;
                propertyChange("Condition");

            }
        }
        string _cityName;

        public string CityName
        {
            get
            {
                return _cityName;
            }
            set
            {
                _cityName = value;
                propertyChange("CityName");

            }
        }
        Uri _iconPath;

        public Uri IconPath
        {
            get
            {
                return _iconPath;
            }
            set
            {
                _iconPath = value;
                propertyChange("IconPath");

            }
        }


        void propertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }


}
