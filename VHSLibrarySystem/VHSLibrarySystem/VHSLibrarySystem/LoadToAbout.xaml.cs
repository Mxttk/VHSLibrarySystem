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
using System.Windows.Shapes;
using WpfAnimatedGif;

namespace VHSLibrarySystem
{
    /// <summary>
    /// Interaction logic for LoadToAbout.xaml
    /// </summary>
    public partial class LoadToAbout : Window
    {
        public LoadToAbout()
        {
            InitializeComponent();


            // Animated GIF control done using the following library -> https://github.com/XamlAnimatedGif/WpfAnimatedGif
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://application:,,,/Assets/VHS.gif");
            image.EndInit();
            ImageBehavior.SetAnimatedSource(VHSGIF, image);
            ImageBehavior.SetAutoStart(VHSGIF, true);

            progressBarAbout.IsIndeterminate = false;
            progressBarAbout.Orientation = Orientation.Horizontal;
            progressBarAbout.Width = 1520;
            progressBarAbout.Height = 30;
            Duration duration = new Duration(TimeSpan.FromSeconds(0.5));
            DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);

            // attaching event handler for when progress bar completed
            doubleanimation.Completed += DoubleAnimationCompleted;

            progressBarAbout.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
        }

        private void DoubleAnimationCompleted(object sender, EventArgs e)
        {
            btnNextAbout.Visibility = Visibility.Visible;
            loadingTextAbout.Text = "LOAD COMPLETE";
        }

        private void btnNextAbout_Click(object sender, RoutedEventArgs e)
        {
            About ab = new About();
            ab.Show();
            Close();
        }
    }
}
