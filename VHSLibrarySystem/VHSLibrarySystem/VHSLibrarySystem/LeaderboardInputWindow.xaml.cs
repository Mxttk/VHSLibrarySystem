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

namespace VHSLibrarySystem
{
    /// <summary>
    /// Interaction logic for LeaderboardInputWindow.xaml
    /// </summary>
    public partial class LeaderboardInputWindow : Window
    {
        public LeaderboardInputWindow()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true; // Set the DialogResult to true to indicate the user clicked "OK"
            Close(); // Close the dialog
        }

    }
}
