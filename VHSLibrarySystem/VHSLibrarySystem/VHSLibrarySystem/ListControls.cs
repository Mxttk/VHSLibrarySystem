using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace VHSLibrarySystem
{
    public class ListControls
    {

        //method to swap the indexs --1 -7


        public static void SwapIndexes(int change, ListBox listBox)

        {

            //first ensure the item is selected

            if (listBox.SelectedItem == null || listBox.SelectedIndex < 0)
            {
                return;
            }
            //target destination

            int newIndex = listBox.SelectedIndex + change;
            //ensure new destination exists

            if (newIndex < 0 || newIndex >= listBox.Items.Count)
            {
                return;
            }
            //object selected

            object selected = listBox.SelectedItem;
            //insert into a new location
            listBox.Items.Remove(selected);
            listBox.Items.Insert(newIndex, selected);
            listBox.SelectedIndex = newIndex;
        }

        public static void randomizeList(ListBox listBox)
        {

            // new list type of

            var list = new List<string>();
            Random rand = new Random(); // to gen a random list every

            list = listBox.Items.Cast<string>().ToList();

            //shuffle the list of items

            int n = list.Count;
            while (n > 1)
            {

                int k = rand.Next(n);
                n--; // decrements the value
                string value = list[k];
                list[k] = list[n]; //swapping
                list[n] = value;


            }

            // Create FontFamily object
            FontFamily fontFamily = new FontFamily("VCR OSD Mono");
           
            listBox.Items.Clear();
            listBox.FontFamily = fontFamily; // set the fontfamily for listbox items 
            listBox.FontSize = 20;
            listBox.Foreground = new SolidColorBrush(Colors.FloralWhite); // Set foreground ref: https://stackoverflow.com/questions/12727491/programmatically-set-textblock-foreground-color

            for (int i = 0; i < list.Count; i++)
            {
                listBox.Items.Add(list[i]);
            }


        }
    }
}
