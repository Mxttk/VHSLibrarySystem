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
    /// Interaction logic for ToMenuLoad.xaml
    /// </summary>
    public partial class ToMenuLoad : Window
    {
        public ToMenuLoad()
        {
            InitializeComponent();

            // Animated GIF control done using the following library -> https://github.com/XamlAnimatedGif/WpfAnimatedGif
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://application:,,,/Assets/VHS.gif");
            image.EndInit();
            ImageBehavior.SetAnimatedSource(VHSGIF, image);
            ImageBehavior.SetAutoStart(VHSGIF, true);

            progressBarReplaceBooks.IsIndeterminate = false;
            progressBarReplaceBooks.Orientation = Orientation.Horizontal;
            progressBarReplaceBooks.Width = 1520;
            progressBarReplaceBooks.Height = 30;
            Duration duration = new Duration(TimeSpan.FromSeconds(0.5));
            DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);

            // attaching event handler for when progress bar completed
            doubleanimation.Completed += DoubleAnimationCompleted;

            progressBarReplaceBooks.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
        }

        private void DoubleAnimationCompleted(object sender, EventArgs e)
        {
            btnBackToMenu.Visibility = Visibility.Visible;
            loadingTextReplaceBooks.Text = "LOAD COMPLETE";
        }

        private void btnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }
    }
}
