using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VHSLibrarySystem
{
    internal class CallNumber
    {
        /* 
         * collection to save the data
         * 3 levels in the text file
         */

        // lists for each level
        public static List<string> thirdLevel = new List<string>();
        public static List<string> secondLevel = new List<string>();
        public static List<string> firstLevel = new List<string>();

        // variable that is used to track answers --> for checking
        public static string myAnswer = "";
        public static string myGoal = "";
        public static string finalLevelAnswer = "";

        // list to store options that the user can use 
        public static List<string> thirdLevelChoice = new List<string>();
        public static List<string> secondLevelChoice = new List<string>();
        public static List<string> firstLevelChoice = new List<string>();

        // tracking input 
        public static string thirdLevelAnswer = "";
        public static string secondLevelAnswer = "";
        public static string firstLevelAnswer = "";

        // for randomizing lists
        public static Random random = new Random();

        // get the text file DeweyText\\DeweyText.txt
        public static void LoadCallNumbers()
        {
            // Relative Path issue fix --> https://stackoverflow.com/questions/17405180/how-to-read-existing-text-files-without-defining-path
            string myPath = Path.Combine(Directory.GetCurrentDirectory(), "DeweyText.txt");
            
            string[] textFile;

            // check if it exists
            if (!File.Exists(myPath))
            {
                MessageBox.Show("Call numbers - loading error");
            }
            else
            {
                // read from the file 
                textFile = File.ReadAllLines(myPath);
                // ready to parse text file into the tree
                string totalTree = "";
                // iterate through the file -> for each string character in the text file -> concat
                foreach (string character in textFile)
                {
                    totalTree += character;
                }
                TreeNode tree = TreeNode.BuildTree(textFile);
                // space for random generation and scrambling
                SelectRandomAnswer(tree);
                // obscure the answer by removing call num
                myGoal = thirdLevelAnswer.Substring(4, thirdLevelAnswer.Length - 4);
            }
        }
        // method to select random answer
        private static void SelectRandomAnswer(TreeNode tree)
        {
            firstLevel.Clear();
            secondLevel.Clear();
            thirdLevel.Clear();

            foreach (TreeNode tree1 in tree)

            {
                firstLevel.Add(tree1.ID);
                foreach (TreeNode tree2 in tree1)
                {
                    secondLevel.Add(tree2.ID);
                    foreach (TreeNode tree3 in tree2)
                    {
                        thirdLevel.Add(tree3.ID);
                    }
                }
            }

            firstLevelChoice.Clear();
            secondLevelChoice.Clear();
            thirdLevelChoice.Clear();



            //Randomly choose first level answer
            int choice = random.Next(firstLevel.Count());
            firstLevelAnswer = firstLevel[choice];
            firstLevelChoice.Add(firstLevelAnswer);

            //Add random first level wrong options
            for (int i = 0; i < 3; i++)
            {
                Random theRand = new Random(Guid.NewGuid().GetHashCode());
                int randomChoice = theRand.Next(firstLevel.Count);

                if (!firstLevel[randomChoice].Equals(firstLevelAnswer) && !firstLevelChoice.Contains(firstLevel[randomChoice]))
                {
                    firstLevelChoice.Add(firstLevel[randomChoice]);
                }
                else
                {
                    i--;
                }
            }

            //Randomly choose second level answer
            for (int i = 0; i < 1; i++)
            {
                Random theRand = new Random(Guid.NewGuid().GetHashCode());
                choice = theRand.Next(secondLevel.Count);

                if (secondLevel[choice].StartsWith(firstLevelAnswer.Substring(0, 1)))
                {
                    secondLevelAnswer = secondLevel[choice];
                    secondLevelChoice.Add(secondLevelAnswer);
                }
                else
                {
                    i--;
                }
            }

            //Add random second level wrong options
            for (int i = 0; i < 3; i++)
            {
                Random theRand = new Random(Guid.NewGuid().GetHashCode());
                int randomChoice = theRand.Next(secondLevel.Count);

                if (secondLevel[randomChoice].StartsWith(firstLevelAnswer.Substring(0, 1)) && !secondLevel[randomChoice].Equals(secondLevelAnswer) && !secondLevelChoice.Contains(secondLevel[randomChoice]))
                {
                    secondLevelChoice.Add(secondLevel[randomChoice]);
                }
                else
                {
                    i--;
                }
            }

            //Randomly choose third level answer
            for (int i = 0; i < 1; i++)
            {
                Random theRand = new Random(Guid.NewGuid().GetHashCode());
                choice = theRand.Next(thirdLevel.Count);

                if (thirdLevel[choice].StartsWith(secondLevelAnswer.Substring(0, 2)))
                {
                    thirdLevelAnswer = thirdLevel[choice];
                    thirdLevelChoice.Add(thirdLevelAnswer);
                }
                else
                {
                    i--;
                }
            }

            //Add random third level wrong options
            for (int i = 0; i < 3; i++)
            {
                Random theRand = new Random(Guid.NewGuid().GetHashCode());
                int randomChoice = theRand.Next(8) + 1;
                string wrongChoice = secondLevelAnswer.Substring(0, 2) + randomChoice;

                if (!wrongChoice.Equals(thirdLevelAnswer.Substring(0, 3)) && !thirdLevelChoice.Contains(wrongChoice))
                {
                    thirdLevelChoice.Add(wrongChoice);
                }
                else
                {
                    i--;
                }
            }

            //Change the format of all third level answers to consistent format
            for (int i = 0; i < thirdLevelChoice.Count; i++)
            {
                thirdLevelChoice[i] = thirdLevelChoice[i].Substring(0, 3);
            }

            //Sort the lists numerically
            firstLevelChoice.Sort();
            secondLevelChoice.Sort();
            thirdLevelChoice.Sort();
        } // end of select random answer method
    } // end of class

} // end of file
