using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
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
    /// Interaction logic for IdentifyAreas.xaml
    /// </summary>
    public partial class IdentifyAreas : Window
    {
        public static int qCount = 4;
        public static bool callQ = true;
        public static int myScore;
        public static int maxScore;
        Random rnd = new Random();
        IDictionary<string, string> baseQuestions = new Dictionary<string, string>();
        IDictionary<string, string> usedQuestions = new Dictionary<string, string>();

        // for bg music
        SoundPlayer musicPlayerIA = new SoundPlayer();

        public IdentifyAreas()
        {
            InitializeComponent();

            // Animated GIF control done using the following library -> https://github.com/XamlAnimatedGif/WpfAnimatedGif
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://application:,,,/BackgroundGifs/arcademachines.gif"); 
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();
            ImageBehavior.SetAnimatedSource(VHSGIF, image);
            ImageBehavior.SetAutoStart(VHSGIF, true);

            var recordSpinning = new BitmapImage();
            recordSpinning.BeginInit();
            recordSpinning.UriSource = new Uri("pack://application:,,,/Gifs/record-spinning.gif");
            recordSpinning.EndInit();
            ImageBehavior.SetAnimatedSource(recordGif, recordSpinning);
            ImageBehavior.SetAutoStart(recordGif, true);

            // load defaults on start
            loadDefaults();
            // load lists on start 
            repopulateLists();

            // creating random object that will be used to select song on startup
            Random random = new Random();
            // Generate a random number between 1 and 4 (inclusive)
            int randomNumber = random.Next(1, 5); // The range is [1, 5), so it includes 1, 2, 3, and 4.

            switch (randomNumber)
            {
                case 1:
                    // init Music -> https://www.youtube.com/watch?v=1UT0qGfw-iM
                    musicPlayerIA.SoundLocation = "sugar-coat.wav";
                    // play the music on a loop
                    musicPlayerIA.PlayLooping();
                    musicPlayerBoxIA.Text = "NOW PLAYING: \nSugar coat\nby Purrple Cat";
                    break;
                case 2:
                    musicPlayerIA.SoundLocation = "Crescent-Moon.wav";
                    musicPlayerIA.PlayLooping();
                    musicPlayerBoxIA.Text = "NOW PLAYING: \nCrescent Moon\nby Purrple Cat";
                    break;
                case 3:
                    musicPlayerIA.SoundLocation = "Missing-You.wav";
                    musicPlayerIA.PlayLooping();
                    musicPlayerBoxIA.Text = "NOW PLAYING: \nMissing You\nby Purrple Cat";
                    break;
                case 4:
                    musicPlayerIA.SoundLocation = "And-So-It-Begins.wav";
                    musicPlayerIA.PlayLooping();
                    musicPlayerBoxIA.Text = "NOW PLAYING: \nAnd So It Begins\nby Artificial Music";
                    break;
                default:
                    break;
            }


        }

        private void loadDefaults()
        {

            baseQuestions.Clear();
            usedQuestions.Clear();
            //list of possible questions
            baseQuestions.Add("000-099", "General Works");
            baseQuestions.Add("100-199", "Philosphy and Psychology");
            baseQuestions.Add("200-299", "Religion");
            baseQuestions.Add("300-399", "Social Sciences");
            baseQuestions.Add("400-499", "Language");
            baseQuestions.Add("500-599", "Natural Science");
            baseQuestions.Add("600-699", "Technology");
            baseQuestions.Add("700-799", "The Arts");
            baseQuestions.Add("800-899", "Literature and Rhetoric");
            baseQuestions.Add("900-999", "History, Biography and Geography");

        }

        internal static void FindChildren<T>(List<T> results, DependencyObject startNode) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(startNode);

            for (int i = 0; i < count; i++)
            {

                DependencyObject current = VisualTreeHelper.GetChild(startNode, i);
                if ((current.GetType()).Equals(typeof(T)) || (current.GetType()).GetTypeInfo().IsSubclassOf(typeof(T)))
                {

                    T asType = (T)current;
                    results.Add(asType);

                }

                FindChildren<T>(results, current);

            }


        }

        //method to calc score
        private int CalcScore()
        {
            int score = 0;
            List<ListBoxItem> list = new List<ListBoxItem>();
            FindChildren(list, lstAns);
            for (int i = 0; i < qCount; i++)
            {

                string callNumber;
                string description;
                if (!callQ)
                {

                    callNumber = lstQuestions.Items[i].ToString();
                    description = lstAns.Items[i].ToString();

                }
                else // flip them around
                {

                    callNumber = lstAns.Items[i].ToString();
                    description = lstQuestions.Items[i].ToString();

                }
                if (usedQuestions[callNumber] == description)
                {

                    //pick a color to light up them up
                    list[i].Background = new SolidColorBrush(Colors.Green);
                    //add onto the score
                    score++;
                }
                else
                {
                    //pick a color to light up them up
                    list[i].Background = new SolidColorBrush(Colors.Red);
                }

            }
            for (int i = qCount; i < lstAns.Items.Count; i++)
            {

                //pick a color to light up them up
                list[i].Background = new SolidColorBrush(Colors.PaleVioletRed);

            }



            return score;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //up btn
            ListControls.SwapIndexes(-1, lstAns);
            //can pull the recolor option here

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            //down btn
            ListControls.SwapIndexes(1, lstAns);
            //can pull the recolor option here
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            // Submit btn
            // submits answers to be checked 
            // pull the method -- setup the textblocks
            //add gamification features -- if u need too

            int score = CalcScore();

            btnUp.IsEnabled = false;
            btnDown.IsEnabled = false;

            //any other btns or features you want to disable st this point

            //load the defaults
            loadDefaults();
            myScore = myScore + score; // add to the score
            maxScore = maxScore + qCount; //checks that you cant execute    

            switch (score)
            {
                case 1:
                    //pop up --> mbox or gamification badge
                    // poor score
                    var catGif1 = new BitmapImage();
                    catGif1.BeginInit();
                    catGif1.UriSource = new Uri("pack://application:,,,/Gifs/cat1.gif");
                    catGif1.EndInit();
                    ImageBehavior.SetAnimatedSource(awardGif, catGif1);
                    ImageBehavior.SetAutoStart(awardGif, true);
                    scoreTb.Text = "Score: " + myScore + "/" + maxScore + "\nTry again, you got this :)";
                    break;
                case 2:
                    //pop up --> mbox or gamification badge
                    // mediocre score
                    var catGif2 = new BitmapImage();
                    catGif2.BeginInit();
                    catGif2.UriSource = new Uri("pack://application:,,,/Gifs/cat2.gif");
                    catGif2.EndInit();
                    ImageBehavior.SetAnimatedSource(awardGif, catGif2);
                    ImageBehavior.SetAutoStart(awardGif, true);
                    scoreTb.Text = "Score: " + myScore + "/" + maxScore + "\nGetting there, dont give up :D";
                    break;
                case 3:
                    //pop up --> mbox or gamification badge
                    // near perfect score
                    var catGif3 = new BitmapImage();
                    catGif3.BeginInit();
                    catGif3.UriSource = new Uri("pack://application:,,,/Gifs/cat3.gif");
                    catGif3.EndInit();
                    ImageBehavior.SetAnimatedSource(awardGif, catGif3);
                    ImageBehavior.SetAutoStart(awardGif, true);
                    scoreTb.Text = "Score: " + myScore + "/" + maxScore + "\nAlmost there, so close now!";
                    break;
                case 4:
                    //pop up --> mbox or gamification badge
                    //perfect score
                    var catGif4 = new BitmapImage();
                    catGif4.BeginInit();
                    catGif4.UriSource = new Uri("pack://application:,,,/Gifs/cat4.gif");
                    catGif4.EndInit();
                    ImageBehavior.SetAnimatedSource(awardGif, catGif4);
                    ImageBehavior.SetAutoStart(awardGif, true);

                    scoreTb.Text = "Score: " + myScore + "/" + maxScore + "\nGreat Job, you got a perfect score!";
                    break;
                default:
                    // no answers correct 
                    var catGif0 = new BitmapImage();
                    catGif0.BeginInit();
                    catGif0.UriSource = new Uri("pack://application:,,,/Gifs/cat0.gif");
                    catGif0.EndInit();
                    ImageBehavior.SetAnimatedSource(awardGif, catGif0);
                    ImageBehavior.SetAutoStart(awardGif, true);

                    scoreTb.Text = "Score: " + myScore + "/" + maxScore + "\nOh no!, better luck next time :(";
                    break;
            }

        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            // new game button
            if (btnSubmit.IsEnabled == true)
            {
                MessageBoxResult dialogResult = MessageBox.Show("Are you sure you want to start a new game?", "This will reset your score", MessageBoxButton.YesNo);

                if (dialogResult == MessageBoxResult.Yes)
                {
                    myScore = 0;
                    maxScore = 0;
                    scoreTb.Text = "Match the columns";
                   
                }
                else
                {
                    return;
                }
            }
            // because of new game -> reset everything to default 
            loadDefaults();
            repopulateLists();


            ImageBehavior.SetAnimatedSource(awardGif, null); // reset award gif

            // btns enabled
            btnUp.IsEnabled = true;
            btnDown.IsEnabled = true;
        }

        //Dictionary --> kvp --> method
        private void getKVP(out string call, out string desc)
        {

            KeyValuePair<string, string> kvp;
            int index = rnd.Next(baseQuestions.Count());
            kvp = baseQuestions.ElementAt(index);
            usedQuestions.Add(kvp);
            baseQuestions.Remove(kvp);
            call = kvp.Key;
            desc = kvp.Value;

        }

        private void repopulateLists()
        {
            lstQuestions.Items.Clear();
            lstAns.Items.Clear();

            // alternate between call numbers and descriptions 
            if (callQ)
            {
                // generate 4 callNo + 4 desc
                for (int i = 0; i < 4; i++)
                {
                    getKVP(out string callNo, out string desc);
                    lstQuestions.Items.Add(callNo);
                    lstAns.Items.Add(desc);
                }
                // generate 3 more desc
                for (int i = 0; i < 3; i++)
                {
                    getKVP(out _, out string desc);
                    lstAns.Items.Add(desc);
                }
                // prep alt
                callQ = false;
            }
            else
            {
                // generate 4 desc + 4 callNos
                for (int i = 0; i < 4; i++)
                {
                    getKVP(out string callNo, out string desc);
                    lstQuestions.Items.Add(desc);
                    lstAns.Items.Add(callNo);
                }
                // gen 3 more callups
                for (int i = 0; i < 3; i++)
                {
                    getKVP(out string callNo, out _);
                    lstAns.Items.Add(callNo);
                }
                // prep alt 
                callQ = true;
            }
            // TO-DO Randomize lists
            ListControls.randomizeList(lstQuestions);
            ListControls.randomizeList(lstAns);

            // recolor();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ToMenuLoad tml = new ToMenuLoad();
            tml.Show();
            musicPlayerIA.Stop();
            Close();
        }
    }
}
