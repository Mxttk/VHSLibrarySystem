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
using WpfAnimatedGif;

namespace VHSLibrarySystem
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();

            // Animated GIF control done using the following library -> https://github.com/XamlAnimatedGif/WpfAnimatedGif
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://application:,,,/Assets/VHS.gif");
            image.EndInit();
            ImageBehavior.SetAnimatedSource(VHSGIF, image);
            ImageBehavior.SetAutoStart(VHSGIF, true);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
           ToMenuLoad tml = new ToMenuLoad();
            tml.Show();
            Close();
        }
    }
}
