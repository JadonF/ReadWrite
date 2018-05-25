/*
 * Created by: Jadon F
 * Created on: 25-May-2018
 * Created for: ICS3U Programming
 * Daily Assignment – Day #37 - Read/Write File
 * This program reads a file to check if the strings on each line are equal.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ReadWrite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool StringsAreEqual(string word1, string word2)
        {
            //local variables
            string upperW1;
            string upperW2;
            string arrayW1;
            string arrayW2;
            bool isEqual = false;

            //define variables
            arrayW1 = word1;
            arrayW2 = word2;
            upperW1 = arrayW1.ToUpper();
            upperW2 = arrayW2.ToUpper();

            //check
            if (word1.Length == word2.Length)
            {
                if (upperW1 == upperW2)
                {
                    isEqual = true;
                }
            }
            return isEqual;
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            //create arrays and variables
            string[] lines = System.IO.File.ReadAllLines(@"input.txt");

            char[] charSeparators = new char[] { ' ', '\t' };

            string output = "";

            //foreach loop
            foreach (string line in lines)
            {
                string[] words = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

                if (StringsAreEqual(words[0], words[1]) == true)
                {
                    output = output + "True\r\n";
                }
                else
                {
                    output = output + "False\r\n";
                }
            }
            //write the output file
            System.IO.File.WriteAllText(@"output.txt", output);

            //notify user it has been written
            MessageBox.Show("The output file has been written.", "Output");
        }
    }
}
