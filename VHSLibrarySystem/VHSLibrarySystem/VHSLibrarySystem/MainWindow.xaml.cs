using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using WpfAnimatedGif;

namespace VHSLibrarySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer musicPlayer = new SoundPlayer();


        public MainWindow()
        {
            InitializeComponent();
            // Animated GIF control done using the following library -> https://github.com/XamlAnimatedGif/WpfAnimatedGif
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://application:,,,/Assets/pixel-store-crop.gif"); 
            image.EndInit();
            ImageBehavior.SetAnimatedSource(VHSGIF, image);
            ImageBehavior.SetAutoStart(VHSGIF, true);

            var recordSpinning = new BitmapImage();
            recordSpinning.BeginInit();
            recordSpinning.UriSource = new Uri("pack://application:,,,/Gifs/record-spinning.gif");
            recordSpinning.EndInit();
            ImageBehavior.SetAnimatedSource(recordGif, recordSpinning);
            ImageBehavior.SetAutoStart(recordGif, true);

            // setting the date time text box
            dateTimeTextBox.Text = DateTime.Now.ToString();

            // creating random object that will be used to select song on startup
            Random random = new Random();
            // Generate a random number between 1 and 4 (inclusive)
            int randomNumber = random.Next(1, 5); // The range is [1, 5), so it includes 1, 2, 3, and 4.

            switch (randomNumber)
            {
                case 1:
                    // init Music -> https://www.youtube.com/watch?v=1UT0qGfw-iM
                    musicPlayer.SoundLocation = "sugar-coat.wav";
                    // play the music on a loop
                    musicPlayer.PlayLooping();
                    musicPlayerBox.Text = "NOW PLAYING: \nSugar coat\nby Purrple Cat";
                    break;
                case 2:
                    musicPlayer.SoundLocation = "Crescent-Moon.wav";
                    musicPlayer.PlayLooping();
                    musicPlayerBox.Text = "NOW PLAYING: \nCrescent Moon\nby Purrple Cat";
                    break;
                case 3:
                    musicPlayer.SoundLocation = "Missing-You.wav";
                    musicPlayer.PlayLooping();
                    musicPlayerBox.Text = "NOW PLAYING: \nMissing You\nby Purrple Cat";
                    break;
                case 4:
                    musicPlayer.SoundLocation = "And-So-It-Begins.wav";
                    musicPlayer.PlayLooping();
                    musicPlayerBox.Text = "NOW PLAYING: \nAnd So It Begins\nby Artificial Music";
                    break;
                default:
                    break;
            }


        }

        private void btnFullscreen_Click(object sender, RoutedEventArgs e)
        {
            // Show a simple OK/Cancel dialog
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButton.OKCancel);

            // Check the user's choice
            if (result == MessageBoxResult.OK)
            {
                // User clicked OK
                Environment.Exit(0);
            }
            else
            {
                // User clicked Cancel or closed the dialog
                return;
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxMenu.SelectedItem != null)
            {
                if (listBoxMenu.SelectedItem is ListBoxItem selectedItem)
                {
                    if (selectedItem.Content is TextBlock textBlock)
                    {
                        string textContent = textBlock.Text;

                        switch (textContent)
                        {
                            case "REPLACING BOOKS":
                                LoadToReplaceBooks ltrb = new LoadToReplaceBooks();
                                ltrb.Show();
                                musicPlayer.Stop();
                                Close();
                                break;
                            case "IDENTIFYING AREAS":
                                LoadToIdentifyAreas ltia = new LoadToIdentifyAreas();
                                ltia.Show();
                                musicPlayer.Stop();
                                Close();
                                break;
                            case "LOCATING CALL NUMBERS":
                                LoadToLocateCallNums lcn = new LoadToLocateCallNums();
                                lcn.Show();
                                Close();
                                break;
                            case "ABOUT":
                                LoadToAbout lta = new LoadToAbout();
                                lta.Show();
                                musicPlayer.Stop();
                                Close();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            else
            {
                // Show an error message if no item is selected
                MessageBox.Show( "Please select an item from the list.");
            }
        }


        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            // on click will on animate from the design side -> actual on click logic will be handled by the start button
        }
    }
}
