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
    /// Interaction logic for LoadToReplaceBooks.xaml
    /// </summary>
    public partial class LoadToReplaceBooks : Window
    {
        public LoadToReplaceBooks()
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
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);

            // attaching event handler for when progress bar completed
            doubleanimation.Completed += DoubleAnimationCompleted;

            progressBarReplaceBooks.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);

            loadingGIF.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/VHSLibrary-Tape.png"));

 
        }
        private void DoubleAnimationCompleted(object sender, EventArgs e)
        {
            btnNextReplaceBooks.Visibility = Visibility.Visible;
            loadingTextReplaceBooks.Text = "LOAD COMPLETE";
            loadingElipseOne.Text = "";
            loadingElipseTwo.Text = "";
            loadingElipseThree.Text = "";
        }

        private void btnNextReplaceBooks_Click(object sender, RoutedEventArgs e)
        {
            ReplaceBooks rb = new ReplaceBooks();  
            rb.Show();
            Close();
        }

   
    }
}
