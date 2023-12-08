using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
    /// Interaction logic for LocateCallNum.xaml
    /// </summary>
    public partial class LocateCallNum : Window
    {
        // global vars
        DispatcherTimer timer = new DispatcherTimer();
        // Timer increment variable 
        private int increment = 0;


        // for bg music
        SoundPlayer musicPlayerLCN = new SoundPlayer();
        public LocateCallNum()
        {
            InitializeComponent();

            // Animated GIF control done using the following library -> https://github.com/XamlAnimatedGif/WpfAnimatedGif
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://application:,,,/BackgroundGifs/testbg.gif");
            image.EndInit();
            ImageBehavior.SetAnimatedSource(VHSGIF, image);
            ImageBehavior.SetAutoStart(VHSGIF, true);

            var recordSpinning = new BitmapImage();
            recordSpinning.BeginInit();
            recordSpinning.UriSource = new Uri("pack://application:,,,/Gifs/record-spinning.gif");
            recordSpinning.EndInit();
            ImageBehavior.SetAnimatedSource(recordGif, recordSpinning);
            ImageBehavior.SetAutoStart(recordGif, true);


            // creating random object that will be used to select song on startup
            Random random = new Random();
            // Generate a random number between 1 and 4 (inclusive)
            int randomNumber = random.Next(1, 5); // The range is [1, 5), so it includes 1, 2, 3, and 4.

            switch (randomNumber)
            {
                case 1:
                    // init Music -> https://www.youtube.com/watch?v=1UT0qGfw-iM
                    musicPlayerLCN.SoundLocation = "sugar-coat.wav";
                    // play the music on a loop
                    musicPlayerLCN.PlayLooping();
                    musicPlayerBoxIA.Text = "NOW PLAYING: \nSugar coat\nby Purrple Cat";
                    break;
                case 2:
                    musicPlayerLCN.SoundLocation = "Crescent-Moon.wav";
                    musicPlayerLCN.PlayLooping();
                    musicPlayerBoxIA.Text = "NOW PLAYING: \nCrescent Moon\nby Purrple Cat";
                    break;
                case 3:
                    musicPlayerLCN.SoundLocation = "Missing-You.wav";
                    musicPlayerLCN.PlayLooping();
                    musicPlayerBoxIA.Text = "NOW PLAYING: \nMissing You\nby Purrple Cat";
                    break;
                case 4:
                    musicPlayerLCN.SoundLocation = "And-So-It-Begins.wav";
                    musicPlayerLCN.PlayLooping();
                    musicPlayerBoxIA.Text = "NOW PLAYING: \nAnd So It Begins\nby Artificial Music";
                    break;
                default:
                    break;
            }

            labelTimer.Visibility = Visibility.Hidden;
            labelAnswer.Visibility = Visibility.Hidden;
            btnNext1.Visibility = Visibility.Hidden;
            btnNext2.Visibility = Visibility.Hidden;
            bgAward.Visibility = Visibility.Hidden;
            btnSubmit.Visibility = Visibility.Hidden;   
        }

        // method to place timer in label
        private void Dt_Tick(object sender, EventArgs e)
        {
            increment++;
            labelTimer.Content = increment.ToString();
        }
        // back btn clicked --> back to menu
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ToMenuLoad tml = new ToMenuLoad();
            tml.Show();
            musicPlayerLCN.Stop();
            Close();
        }

        // next btn click --> for submitting 3rd level answer
        private void btnNext1_Click(object sender, RoutedEventArgs e)
        {
            // error message if user selected nothing
            if (listFirstLevel.SelectedItem == null)
            {
                MessageBox.Show("Please select an item");
            }
            else
            {
                // check user answers
                if (listFirstLevel.SelectedItem.Equals(CallNumber.firstLevelAnswer))
                {
                    // give random positive feedback to user
                    Random ran = new Random();
                    var corResponses = new List<string> { "Well done that is correct!", "Nice job, you did it!", "Dewey Decimal Dominator!" };
                    int choice = ran.Next(corResponses.Count);
                    MessageBox.Show(corResponses[choice]);

                    // show next phase of game
                    listFirstLevel.IsEnabled = false;
                    btnNext1.Visibility = Visibility.Hidden;
                    listSecondLevel.Visibility = Visibility.Visible;
                    listSecondLevel.IsEnabled = true;
                    btnNext2.Visibility = Visibility.Visible;

                }
                else
                {
                    // user will get hit with a time penalty upon getting an incorrect answer --> ties gamfication to getting best possible time rather than just getting it right for the sake of it
                    // add 5 seconds to timer --> good time is main goal
                    labelTimer.Foreground = new SolidColorBrush(Colors.Red);
                    increment += 5;
                    System.Timers.Timer t = new System.Timers.Timer(); // https://stackoverflow.com/questions/8496275/wait-for-a-while-without-blocking-main-thread
                    t.Interval = 1000; // In milliseconds
                    t.AutoReset = false; // Stops it from repeating
                    t.Elapsed += new ElapsedEventHandler(TimerElapsed);
                    t.Start();
                }
            }
        }

        // next btn 2 click --> for submitting 2nd level answer
        private void btnNext2_Click(object sender, RoutedEventArgs e)
        {
            //Error message if user selects nothing
            if (listSecondLevel.SelectedItem == null)
            {
                MessageBox.Show("Please select an item");
            }
            else
            {
                //Check user answer
                if (listSecondLevel.SelectedItem.Equals(CallNumber.secondLevelAnswer))
                {
                    //Give Random positive feeback to user
                    Random rand = new Random(Guid.NewGuid().GetHashCode());
                    var corResponses = new List<string> { "Well Done, that is correct!", "Wow, one step closer to victory. Well Done!", "Spot on! You made that look easy." };
                    int choice = rand.Next(corResponses.Count);
                    MessageBox.Show(corResponses[choice]);

                    //Show next phase of game
                    listSecondLevel.IsEnabled = false;
                    btnNext2.Visibility = Visibility.Hidden;
                    listThirdLevel.Visibility = Visibility.Visible;
                    listThirdLevel.IsEnabled = true;
                    btnSubmit.Visibility = Visibility.Visible;
                }
                else
                {
                    // add 5 seconds to timer --> good time is main goal
                    labelTimer.Foreground = new SolidColorBrush(Colors.Red);
                    increment += 5;
                    System.Timers.Timer t = new System.Timers.Timer(); // https://stackoverflow.com/questions/8496275/wait-for-a-while-without-blocking-main-thread
                    t.Interval = 1000; // In milliseconds
                    t.AutoReset = false; // Stops it from repeating
                    t.Elapsed += new ElapsedEventHandler(TimerElapsed);
                    t.Start();
                } // end of inner else

            } // end of outer else
        }

        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            // bug fix https://stackoverflow.com/questions/9732709/the-calling-thread-cannot-access-this-object-because-a-different-thread-owns-it
            this.Dispatcher.Invoke(() =>
            {
                labelTimer.Foreground = new SolidColorBrush(Colors.FloralWhite);
            });
        }

        // btn start click --> for starting the game
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.Content = "Start";
            btnStart.Visibility = Visibility.Hidden;
            listFirstLevel.Visibility = Visibility.Visible;
            listFirstLevel.IsEnabled = true;
            btnNext1.Visibility = Visibility.Visible;
            listSecondLevel.Visibility = Visibility.Hidden;
            btnNext2.Visibility = Visibility.Hidden;
            listThirdLevel.Visibility = Visibility.Hidden;
            bgAward.Visibility = Visibility.Hidden;
            btnSubmit.Visibility = Visibility.Hidden;

            labelTimer.Visibility = Visibility.Visible;
            labelAnswer.Visibility = Visibility.Visible;

            // reset award
            ImageBehavior.SetAnimatedSource(awardGif, null);

            // reset text associated with award 
            textBlockResult.Text = string.Empty;

            // load the call nums from the file into the tree -> into UI
            CallNumber.LoadCallNumbers();

            // load the quiz goal that the user must get to 
            labelAnswer.Text = CallNumber.myGoal;

            // prepare lists to add quiz options to UI for the user to select
            listThirdLevel.Items.Clear();
            listSecondLevel.Items.Clear();
            listFirstLevel.Items.Clear();

            foreach (string i in CallNumber.firstLevelChoice)
            {
                listFirstLevel.Items.Add(i);
            }

            foreach (string i in CallNumber.secondLevelChoice)
            {
                listSecondLevel.Items.Add(i);
            }



            foreach (string i in CallNumber.thirdLevelChoice)
            {
                listThirdLevel.Items.Add(i);
            }

            // reset timer --> label 
            labelTimer.Content = "0"; // reset the timer display 
            increment = 0;

            // creating timer to start on button click --> https://www.youtube.com/watch?v=pf6IEcfHqdk
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,0,1);
            timer.Tick += Dt_Tick;
            timer.Start();
        }

        // btn submit click --> used for submitting 1st level answer --> finishes the game
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Error message if user selects nothing
            if (listThirdLevel.SelectedItem == null)
            {
                MessageBox.Show("Please select an item");
            }
            else
            {
                //Check user answer
                if (listThirdLevel.SelectedItem.Equals(CallNumber.thirdLevelAnswer.Substring(0, 3)))
                {
                    //Give Random positive feeback to user
                    Random rand = new Random(Guid.NewGuid().GetHashCode());
                    var corResponses = new List<string> { "You won the game congrats!", "Winner Winner Chicken Dinner!", "You're the champ, nice work!" };
                    int choice = rand.Next(corResponses.Count);
                    MessageBox.Show(corResponses[choice]);

                    // handle game completed logic
                    listThirdLevel.IsEnabled = false;

                    // make BG award background visible now
                    bgAward.Visibility = Visibility.Visible;

                    // stop the timer
                    timer.Stop();

                    // parse string to int for award handling
                    int time = int.Parse(labelTimer.Content.ToString());

                    if (time <= 20)
                    {
                        //pop up --> mbox or gamification badge
                        // poor score
                        var catGif1 = new BitmapImage();
                        catGif1.BeginInit();
                        catGif1.UriSource = new Uri("pack://application:,,,/Gifs/cat2.2.gif");
                        catGif1.EndInit();
                        ImageBehavior.SetAnimatedSource(awardGif, catGif1);
                        ImageBehavior.SetAutoStart(awardGif, true);
                        textBlockResult.Text = "Super speedsters like you deserve the best cat :)";
                    } 
                    else if (time <= 30)
                    {
                        var catGif2 = new BitmapImage();
                        catGif2.BeginInit();
                        catGif2.UriSource = new Uri("pack://application:,,,/Gifs/cat2.6.gif");
                        catGif2.EndInit();
                        ImageBehavior.SetAnimatedSource(awardGif, catGif2);
                        ImageBehavior.SetAutoStart(awardGif, true);
                        textBlockResult.Text = "Woah that was quick, nice job!";
                    }
                    else if (time <= 40)
                    {
                        var catGif3 = new BitmapImage();
                        catGif3.BeginInit();
                        catGif3.UriSource = new Uri("pack://application:,,,/Gifs/cat2.4.gif");
                        catGif3.EndInit();
                        ImageBehavior.SetAnimatedSource(awardGif, catGif3);
                        ImageBehavior.SetAutoStart(awardGif, true);
                        textBlockResult.Text = "Pretty quick if I do say so myself :D";
                    }
                    else if (time <= 50)
                    {
                        var catGif4 = new BitmapImage();
                        catGif4.BeginInit();
                        catGif4.UriSource = new Uri("pack://application:,,,/Gifs/cat2.5.gif");
                        catGif4.EndInit();
                        ImageBehavior.SetAnimatedSource(awardGif, catGif4);
                        ImageBehavior.SetAutoStart(awardGif, true);
                        textBlockResult.Text = "Not too bad although there is room for improvement :3";
                    }
                    else if (time <= 60)
                    {
                        var catGif5 = new BitmapImage();
                        catGif5.BeginInit();
                        catGif5.UriSource = new Uri("pack://application:,,,/Gifs/cat2.3.gif");
                        catGif5.EndInit();
                        ImageBehavior.SetAnimatedSource(awardGif, catGif5);
                        ImageBehavior.SetAutoStart(awardGif, true);
                        textBlockResult.Text = "More practice would do you good!";
                    }
                    else
                    {
                        // any amount of elapsed time after 60 seconds
                        var catGif6 = new BitmapImage();
                        catGif6.BeginInit();
                        catGif6.UriSource = new Uri("pack://application:,,,/Gifs/cat2.1.gif");
                        catGif6.EndInit();
                        ImageBehavior.SetAnimatedSource(awardGif, catGif6);
                        ImageBehavior.SetAutoStart(awardGif, true);
                        textBlockResult.Text = "What happened? :/";
                    }

                    // reset start button
                    btnStart.Visibility = Visibility.Visible;
                    btnStart.Content = "Try Again?";

                    // change visibility of submit btn
                    btnSubmit.Visibility = Visibility.Hidden;
                }
                else
                {
                    // add 5 seconds to timer --> good time is main goal
                    labelTimer.Foreground = new SolidColorBrush(Colors.Red);
                    increment += 5;
                    System.Timers.Timer t = new System.Timers.Timer(); // https://stackoverflow.com/questions/8496275/wait-for-a-while-without-blocking-main-thread
                    t.Interval = 1000; // In milliseconds
                    t.AutoReset = false; // Stops it from repeating
                    t.Elapsed += new ElapsedEventHandler(TimerElapsed);
                    t.Start();

                } // end of inner else

            } // end of outer else
        }
    }
}
