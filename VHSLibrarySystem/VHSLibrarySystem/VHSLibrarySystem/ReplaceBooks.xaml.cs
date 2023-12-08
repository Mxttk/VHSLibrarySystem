using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace VHSLibrarySystem
{
    /// <summary>
    /// Interaction logic for ReplaceBooks.xaml
    /// </summary>
    public partial class ReplaceBooks : Window
    {
        // object for dragging listbox item
        private object draggedItem;

        // random object for generating call number
        static Random random = new Random();

        // img for button
        private BitmapImage gifImage = new BitmapImage();

        // entry for leaderboard
        private List<LeaderboardEntry> leaderboard = new List<LeaderboardEntry>();

        // for holding score and username 
        static string? userName;
        static int correctCount;

        // score list that will be displayed on leaderboard page
        public static List<string> scoreList = new List<string>();

        // dewey call number list will be the users non-sorted list
        public static List<string> deweyCallNumbers = new List<string>();

        // sorted version of the users list to use as comparision 
        public static List<string> deweyCallNumbersSorted = new List<string>();

        // for bg music
        SoundPlayer musicPlayerRB = new SoundPlayer();


        public ReplaceBooks()
        {
            InitializeComponent();

            // Animated GIF control done using the following library -> https://github.com/XamlAnimatedGif/WpfAnimatedGif
            var imageBg = new BitmapImage();
            imageBg.BeginInit();
            imageBg.UriSource = new Uri("pack://application:,,,/Assets/bg-test-two.gif");
            imageBg.EndInit();
            ImageBehavior.SetAnimatedSource(bgImg, imageBg);
            ImageBehavior.SetAutoStart(bgImg, true);
       
         //   bgImg.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/cat-bg.png"));

            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://application:,,,/Assets/VHS.gif");
            image.EndInit();
            ImageBehavior.SetAnimatedSource(VHSGIFListboxRandom, image);
            ImageBehavior.SetAnimatedSource(VHSGIFListboxAnswer, image);
            ImageBehavior.SetAutoStart(VHSGIFListboxRandom, true);
            ImageBehavior.SetAutoStart(VHSGIFListboxAnswer, true);

            // creating duration for button press
            TimeSpan duration = TimeSpan.FromMilliseconds(2000);

            ImageBehavior.SetAnimationDuration(VHSGIFListboxRandom,duration);
            ImageBehavior.SetAnimationDuration(VHSGIFListboxAnswer,duration);

            var recordSpinning = new BitmapImage();
            recordSpinning.BeginInit();
            recordSpinning.UriSource = new Uri("pack://application:,,,/Gifs/record-spinning.gif");
            recordSpinning.EndInit();
            ImageBehavior.SetAnimatedSource(recordGifRB, recordSpinning);
            ImageBehavior.SetAutoStart(recordGifRB, true);

            // creating random object that will be used to select song on startup
            Random random = new Random();
            // Generate a random number between 1 and 4 (inclusive)
            int randomNumber = random.Next(1, 5); // The range is [1, 5), so it includes 1, 2, 3, and 4.

            switch (randomNumber)
            {
                case 1:
                    // init Music -> https://www.youtube.com/watch?v=1UT0qGfw-iM
                    musicPlayerRB.SoundLocation = "sugar-coat.wav";
                    // play the music on a loop
                    musicPlayerRB.PlayLooping();
                    musicPlayerBoxRB.Text = "NOW PLAYING: \nSugar coat\nby Purrple Cat";
                    break;
                case 2:
                    musicPlayerRB.SoundLocation = "Crescent-Moon.wav";
                    musicPlayerRB.PlayLooping();
                    musicPlayerBoxRB.Text = "NOW PLAYING: \nCrescent Moon\nby Purrple Cat";
                    break;
                case 3:
                    musicPlayerRB.SoundLocation = "Missing-You.wav";
                    musicPlayerRB.PlayLooping();
                    musicPlayerBoxRB.Text = "NOW PLAYING: \nMissing You\nby Purrple Cat";
                    break;
                case 4:
                    musicPlayerRB.SoundLocation = "And-So-It-Begins.wav";
                    musicPlayerRB.PlayLooping();
                    musicPlayerBoxRB.Text = "NOW PLAYING: \nAnd So It Begins\nby Artificial Music";
                    break;
                default:
                    break;
            }

            gifImage = new BitmapImage(new Uri("pack://application:,,,/Assets/btnUp.png"));
            imgButton.Source = gifImage;


            // Randomized Listbox population here
            for (int i = 0; i < 10; i++)
            {
                string callNumber = GenerateDeweyDecimalCallNumber();
                listBoxRandom.Items.Add(new customListBoxItem { Code = callNumber });
            }

        }

        // method for generating dewey decimal sequence
        static string GenerateDeweyDecimalCallNumber()
        {
            // Generate a random classification number (e.g., 100-999)
            int classificationNumber = random.Next(100, 1000);

            // Generate a random author mark (e.g., A-Z)
            string authorName = GenerateRandomAuthorName();

            // Generate a random book number (e.g., 1-9999)
            int bookNumber = random.Next(1, 10000);

            // Combine the parts to create the Dewey Decimal call number
            string deweyDecimalCallNumber = classificationNumber.ToString() + "." + bookNumber.ToString() + " " + authorName;

            return deweyDecimalCallNumber;
        }

        // generate a random 3 character author name
        static string GenerateRandomAuthorName()
        {
            char[] authorName = new char[3];

            // Generate the first character
            authorName[0] = (char)random.Next('A', 'Z' + 1);

            // Generate the second character (ensure it's a vowel)
            authorName[1] = GenerateRandomVowel();

            // Generate the third character
            authorName[2] = (char)random.Next('A', 'Z' + 1);

            return new string(authorName);
        }
        
        // generate a vowel for the middle character to ensure author name readability
        static char GenerateRandomVowel()
        {
            string vowels = "AEIOU";
            return vowels[random.Next(0, vowels.Length)];
        }

        // back button click -> back to menu
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ToMenuLoad tml = new ToMenuLoad();
            tml.Show();
            musicPlayerRB.Stop();
            Close();
        }

        // when left mouse button clicked
        private void listBoxRandom_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Capture the item being dragged
            ListBox listBox = sender as ListBox;
            draggedItem = GetDraggedItem(listBox, e.GetPosition(listBox));
        }

        // checks what item was grabbed when click was made
        private void listBoxRandom_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            // Check for left mouse button click and draggedItem
            if (e.LeftButton == MouseButtonState.Pressed && draggedItem != null)
            {
                // Start the drag-and-drop operation
                DragDrop.DoDragDrop((DependencyObject)sender, draggedItem, DragDropEffects.Move);
            }
        }

        // handles dropping the list item from the randomized screen to the answer screen
        private void listBoxDrop(object sender, DragEventArgs e)
        {
            // Get the target ListBox
            ListBox listBox = sender as ListBox;

            // Check if the data can be dropped
            if (e.Data.GetDataPresent(typeof(customListBoxItem)))
            {
                // Remove the item from the source ListBox
                ListBox sourceListBox = listBoxRandom;

                // Add the item to the target ListBox
                customListBoxItem item = (customListBoxItem)e.Data.GetData(typeof(customListBoxItem));
                sourceListBox.Items.Remove(item);
                listBoxRandom.Items.Remove(item);
                listBox.Items.Add(item);
            }
        }

        // locate what item is being grabbed in the list 
        private customListBoxItem GetDraggedItem(ListBox listBox, Point point)
        {
            // Find the item at the given point
            customListBoxItem item = null;

            for (int i = 0; i < listBox.Items.Count; i++)
            {
                customListBoxItem listBoxItem = listBox.Items[i] as customListBoxItem;
                ListBoxItem container = listBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;

                if (listBoxItem != null && container != null && container.IsMouseOver)
                {
                    item = listBoxItem;
                    break;
                }
            }

            return item;
        }


        // when big red button pressed
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // Load the animated GIF 
            var bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri("pack://application:,,,/Assets/buttonPress.gif");
            bitMap.EndInit();
            ImageBehavior.SetAnimatedSource(imgButton, bitMap);

            // creating duration for button press
            TimeSpan duration = TimeSpan.FromMilliseconds(1000);
            // setting the duration of the gif animation
            ImageBehavior.SetAnimationDuration(imgButton, duration);
            // set the gif to only play once
            ImageBehavior.SetRepeatBehavior(imgButton,new System.Windows.Media.Animation.RepeatBehavior(1));

            CheckOrder();

        }

        // method for determining whether the order of each item is correct or incorrect 
        private void CheckOrder()
        {
            // Create a list to hold Dewey Decimal call numbers in the answer list
            List<string> deweyCallNumbersSorted = new List<string>();

            userName = GetUserName(); // Get the user's name

            foreach (customListBoxItem item in listBoxAnswer.Items)
            {
                deweyCallNumbers.Add(item.Code);
                deweyCallNumbersSorted.Add(item.Code);
            }

            // Sort the call numbers using Quick Sort
            SortList(deweyCallNumbersSorted, 0, deweyCallNumbersSorted.Count - 1);

            // init to 0 before calc score
            correctCount = 0;

            for (int i = 0; i < deweyCallNumbers.Count; i++)
            {
                // if the values at the same indices match -> answer is correct
                if (deweyCallNumbers[i] == deweyCallNumbersSorted[i])
                {
                    scoreList.Add($"{i + 1}\n -\n CORRECT");
                    correctCount++;
                }
                else
                {
                    scoreList.Add($"{i + 1}\n -\n INCORRECT");
                }
            }

            // Create a new leaderboard entry with the user's name
            LeaderboardEntry entry = new LeaderboardEntry
            {
                UserName = userName,
                Score = correctCount
            };

            leaderboard.Add(entry);

            // Sort the leaderboard by score in descending order
            leaderboard = leaderboard.OrderByDescending(e => e.Score).ToList();

            // Display the updated leaderboard
            // show leaderboard dialog
            LeaderBoard leaderBoardDialog = new LeaderBoard();

            leaderBoardDialog.Show();
            leaderBoardDialog.setBoxes(userName,correctCount);


            // close the window
            Close();
        }

        // gets username from textbox popup after button click 
        private string GetUserName()
        {
            LeaderboardInputWindow inputDialog = new LeaderboardInputWindow();
            if (inputDialog.ShowDialog() == true)
            {
                return inputDialog.NameTextBox.Text;
            }
            return "Anonymous"; // Default name if the user cancels the input dialog
        }

        // QUICK SORT used from -> https://code-maze.com/csharp-quicksort-algorithm/
        public List<string> SortList(List<string> list, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = list[leftIndex];

            while (i <= j)
            {
                while (string.Compare(list[i], pivot) < 0)
                {
                    i++;
                }

                while (string.Compare(list[j], pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    string temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                SortList(list, leftIndex, j);

            if (i < rightIndex)
                SortList(list, i, rightIndex);

            return list;
        }

    } // end of class

    // class holding values for listbox items
    public class customListBoxItem
    {
        public string Code { get; set; }
        // Add other properties as needed
        public override string ToString()
        {
            return Code;
        }

    }

    public class LeaderboardEntry
    {
        public string UserName { get; set; }
        public int Score { get; set; }
    }



}
