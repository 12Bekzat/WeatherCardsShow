using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherCards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string API = "318d86e610dfb76c01702642e1ff63e1";
        private string url = "https://api.openweathermap.org/data/2.5/forecast?q=*&appid=" + API;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MouseGuidence(object sender, MouseButtonEventArgs e)
        {
            searchCity.Clear();
        }

        private void EnterEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !String.IsNullOrWhiteSpace(searchCity.Text))
            {
                WebClient webClient = new WebClient();

                url = url.Replace("*", searchCity.Text);

                string weatherData = webClient.DownloadString(url);
                RootObject root = JsonConvert.DeserializeObject<RootObject>(weatherData);

                DateTime nowDate = DateTime.Now;
                int i = 0;

                foreach (var item in root.list)
                {

                    DateTime checkDate = new DateTime();
                    DateTime.TryParse(item.dt_txt, out checkDate);
                    if (nowDate.Year == checkDate.Year && nowDate.Month == checkDate.Month && nowDate.Day == checkDate.Day)
                    {
                        DateTime checkTime = new DateTime(nowDate.Year, nowDate.Month, nowDate.Day, 21, 0, 0);
                        if (nowDate.Hour == checkTime.Hour)
                        {
                            i++;
                            nowDate = new DateTime(nowDate.Year, nowDate.Month, nowDate.Day + 1);
                            foreach (var main in item.weather)
                            {
                                if(StreamGeometry.Equals( main.main, "Clouds"))
                                {
                                    item.Icon = "Images/Untitled-3.png";
                                }
                                else if (StreamGeometry.Equals(main.main, "Clear"))
                                {
                                    item.Icon = "Images/Untitled-5.png";
                                }
                                else if (StreamGeometry.Equals(main.main, "Rain"))
                                {
                                    item.Icon = "Images/Untitled-4.png";
                                }
                            }
                        }
                    }                    
                }

                lbWeather.ItemsSource = root.list;
            }
        }
    }
}
