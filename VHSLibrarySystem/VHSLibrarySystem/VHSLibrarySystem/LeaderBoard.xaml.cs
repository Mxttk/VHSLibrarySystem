using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    /// Interaction logic for LeaderBoard.xaml
    /// </summary>
    public partial class LeaderBoard : Window
    {
        public LeaderBoard()
        {
            InitializeComponent();

            // Animated GIF control done using the following library -> https://github.com/XamlAnimatedGif/WpfAnimatedGif
            var imageBg = new BitmapImage();
            imageBg.BeginInit();
            imageBg.UriSource = new Uri("pack://application:,,,/Assets/arcade.gif");
            imageBg.EndInit();
            ImageBehavior.SetAnimatedSource(bgImg, imageBg);
            ImageBehavior.SetAutoStart(bgImg, true);

            setListBoxes();

        }

        public void setBoxes(string userName, int score)
        {
            userNameLabel.Text = userName;
            userNameScore.Text = $"{score}/10";
        }

        public void setListBoxes()
        {
            
            foreach (string item in ReplaceBooks.scoreList)
            {
                ListBoxItem itemListBox = new ListBoxItem();

                // styling listbox item
                itemListBox.FontFamily.Equals("VCR OSD Mono");
                itemListBox.FontSize = 15;
                itemListBox.HorizontalAlignment = HorizontalAlignment.Center;
                itemListBox.VerticalAlignment = VerticalAlignment.Center;


                itemListBox.Content = item.ToString();
                listBoxScore.Items.Add(itemListBox);
            }
            
            foreach (string item in ReplaceBooks.deweyCallNumbers)
            {
                ListBoxItem itemListBox = new ListBoxItem();

                // styling listbox item
                itemListBox.FontFamily.Equals("VCR OSD Mono");
                itemListBox.FontSize = 15;
                itemListBox.HorizontalAlignment = HorizontalAlignment.Center;
                itemListBox.VerticalAlignment = VerticalAlignment.Center;
                itemListBox.Padding = new Thickness(0,5,0,0);

                itemListBox.Content = item.ToString();
                listBoxUserSelectedList.Items.Add(itemListBox);
            }

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ReplaceBooks rb = new ReplaceBooks();

            // clear lists before navigating to page
            ReplaceBooks.scoreList.Clear();
            ReplaceBooks.deweyCallNumbers.Clear();
            ReplaceBooks.deweyCallNumbersSorted.Clear();

            rb.Show();
            this.Close();

            
        }
    }
}
