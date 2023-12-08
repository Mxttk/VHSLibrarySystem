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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace VHSLibrarySystem
{
    /// <summary>
    /// Interaction logic for LoadingScreen.xaml
    /// </summary>
    public partial class LoadingScreen : Window
    {
        private DispatcherTimer timer;

        public LoadingScreen()
        {
            InitializeComponent();

            // Animated GIF control done using the following library -> https://github.com/XamlAnimatedGif/WpfAnimatedGif
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://application:,,,/Assets/night-drive-crop.gif"); 
            image.EndInit();
            ImageBehavior.SetAnimatedSource(loadGIF, image);
            ImageBehavior.SetAutoStart(loadGIF, true);

            // Create and configure a DispatcherTimer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5); // Wait for 5 seconds
            timer.Tick += Timer_Tick;

            // Start the timer
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Close the loading window

            // Open your main window (replace MainWindow with your actual main window class)
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();

        }
    }
}
