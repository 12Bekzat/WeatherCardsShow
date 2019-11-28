using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimationLesson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            //DoubleAnimation animation = new DoubleAnimation();
            //animation.From = whiteLoadRextangle.ActualWidth;
            //animation.To = ActualWidth;
            //animation.Duration = TimeSpan.FromSeconds(10);
            //animation.RepeatBehavior = RepeatBehavior.Forever;
            //whiteLoadRextangle.BeginAnimation(Rectangle.WidthProperty, animation);

            //DoubleAnimation animation1 = new DoubleAnimation();
            //animation.From = loadRectangle.ActualWidth;
            //animation.To = ActualWidth;
            //animation.Duration = TimeSpan.FromSeconds(10);
            //animation.RepeatBehavior = RepeatBehavior.Forever;
            //loadRectangle.BeginAnimation(Rectangle.WidthProperty, animation1);

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = double.IsNaN(Canvas.GetLeft(loadRectangle)) ? 0 : Canvas.GetLeft(loadRectangle);
            animation.To = ActualWidth;
            animation.Duration = TimeSpan.FromSeconds(5);
            animation.RepeatBehavior = RepeatBehavior.Forever;
            loadRectangle.BeginAnimation(Canvas.LeftProperty, animation);
        }
    }
}
