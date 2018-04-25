using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string filePathName = @"U:\NET\products.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadFile()
        {

            StreamReader sr = File.OpenText(filePathName);
            textBox.Text = sr.ReadToEnd();
            sr.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                openFileDialog.DefaultExt = "txt";
                if (string.IsNullOrEmpty(filePathName))
                    openFileDialog.InitialDirectory = filePathName;
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|XML Files (*.xml)|*.xml|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog().Equals(DialogResult.OK))
                {
                    filePathName = openFileDialog.FileName;
                    LoadFile();

                }      
            }
        }

        //exit the application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Application.Exit();
        }

        //binary floating to decimal function
        public static float BinaryStringToSingle(string s)
        {
            int i = Convert.ToInt32(s, 2);
            byte[] b = BitConverter.GetBytes(i);
            return BitConverter.ToSingle(b, 0);
        }

        //convert to binary and put into list
        private void convert_button_Click(object sender, EventArgs e)
        {
            string mystring, search;
            mystring = textBox.Text;
            string[] filetext = File.ReadAllLines(openFileDialog.FileName);
            List<string> termsList = new List<string>();

            foreach (var item in filetext.Skip(1))
            {
                string name = item.Split(':')[1];
                string binary = Convert.ToString(Int32.Parse(name), 2).PadLeft(16, '0');
                termsList.Add(binary);
            }

            //for REAL4
            List<string> partlist = new List<string>() {
                string.Concat(termsList[1], termsList[0]),
                string.Concat(termsList[3], termsList[2]),
                string.Concat(termsList[5], termsList[4]),
               string.Concat(termsList[7], termsList[6]),
                string.Concat(termsList[11], termsList[10]),
                string.Concat(termsList[15], termsList[14]),
               string.Concat(termsList[19], termsList[18]),
               string.Concat(termsList[23], termsList[22]),
              string.Concat(termsList[27], termsList[26]),
               string.Concat(termsList[31], termsList[30]),
                 string.Concat(termsList[33], termsList[32]),
                string.Concat(termsList[35], termsList[34]),
                string.Concat(termsList[37], termsList[36]),
                string.Concat(termsList[39], termsList[38]),
                string.Concat(termsList[41], termsList[40]),
                string.Concat(termsList[43], termsList[42]),
                string.Concat(termsList[45], termsList[44]),
                string.Concat(termsList[47], termsList[46]),
                string.Concat(termsList[77], termsList[76]),
                string.Concat(termsList[79], termsList[78]),
                string.Concat(termsList[81], termsList[80]),
                string.Concat(termsList[83], termsList[82]),
                string.Concat(termsList[85], termsList[84]),
                string.Concat(termsList[87], termsList[86]),
                string.Concat(termsList[89], termsList[88]),
                string.Concat(termsList[97], termsList[96]),
                string.Concat(termsList[99], termsList[98])
            };
         //   textBox2.Text = String.Join(Environment.NewLine, partlist);
            List<string> floatlist = new List<string>();
            for (int i = 0; i < partlist.Count; i = i + 1)
            {
                search = partlist[i];
                float f2 = BinaryStringToSingle(search);
                floatlist.Add(f2.ToString());
            }
            textBox1.Text = "Value of REAL4 format with registar pairs (1,2), (3,4),(5,6),(7,8),(11,12),(15,16),(19,20),(23,24),(27,28),(31,32)," +
                "(33,34),(35,36),(37,38),(39,40),(41,42),(43,44),(45,46),(47,48),(77,78),(79,80),(81,82),(83,84),(85,86),(87,88),(89,90),(97,98),(99,100) are as follow " 
                + Environment.NewLine;
            textBox1.Text += String.Join(Environment.NewLine, floatlist);


            //for INTEGER
            List<string> intlist = new List<string>() {
            termsList[58].Substring(termsList[58].Length - 8),
            termsList[59].Substring(termsList[59].Length - 8),
            termsList[60].Substring(termsList[60].Length - 8),
            termsList[61].Substring(termsList[61].Length - 8),
            termsList[91].Substring(termsList[91].Length - 8),
            termsList[92].Substring(termsList[92].Length - 8),
            termsList[93].Substring(termsList[93].Length - 8),
            termsList[95].Substring(termsList[95].Length - 8)
            };
            List<string> intlistfinal = new List<string>();
            for(int j = 0; j<intlist.Count; j = j + 1)
            {
                int k = Convert.ToInt32(intlist[j], 2);
                intlistfinal.Add(k.ToString());
            }
            textBox2.Text = "Value of integer format with register 59,60,61,62,92,93,94,96 are as follow " + Environment.NewLine;
            textBox2.Text += String.Join(Environment.NewLine, intlistfinal);
            //  textBox1.Text += String.Join(Environment.NewLine, Convert.ToInt32(string.Concat(termsList[21], termsList[20]), 2));


            //for LONG
            List<string> longlist = new List<string>() {
                string.Concat(termsList[9], termsList[8]),
                string.Concat(termsList[13], termsList[12]),
               string.Concat(termsList[17], termsList[16]),
               string.Concat(termsList[21], termsList[20]),
                string.Concat(termsList[25], termsList[24]),
                string.Concat(termsList[29], termsList[28])
            };
            List<string> longlistfinal = new List<string>();
            for (int i = 0; i < longlist.Count; i = i + 1)
            {
                search = longlist[i];
                int f2 = Convert.ToInt32(search,2);
                longlistfinal.Add(f2.ToString());
            }
            textBox3.Text = "Value of LONG format with register pain (9,10),(13,14),(17,18),(21,22),(25,26),(29,30) are as follow " + Environment.NewLine;
            textBox3.Text += String.Join(Environment.NewLine, longlistfinal);

            //for BCD up to 2 char
            List<string> bcd2char = new List<string>()
            {
                 string.Concat(termsList[49], termsList[48]),
                 termsList[50],termsList[25]
            };
            List<string> bcd2charfinal = new List<string>();
            for (int i = 0; i < bcd2char.Count; i = i + 1)
            {
                search = bcd2char[i];
                int f2 = Convert.ToInt32(search, 2);
                bcd2charfinal.Add(f2.ToString());
            }
            textBox4.Text = "Value of BCD format with register (49,50),51,56,(53,54,55) are as follow " + Environment.NewLine;
            textBox4.Text += String.Join(Environment.NewLine, bcd2charfinal);

            //for 3 numbers BCD
            List<string> bcd3char = new List<string>() {

                 termsList[52].Substring(8,4),
                termsList[52].Substring(12,4),
                termsList[52].Substring(0,4),
                termsList[52].Substring(4,4),
                termsList[53].Substring(8,4),
                termsList[53].Substring(12,4),
                termsList[53].Substring(0,4),
                termsList[53].Substring(4,4),
                termsList[54].Substring(8,4),
                termsList[54].Substring(12,4),
                termsList[54].Substring(0,4),
                termsList[54].Substring(4,4)

            };
            List<string> bcd3charfinal = new List<string>();
            for (int i = 0; i < bcd3char.Count; i = i + 1)
            {
                search = bcd3char[i];
                int f2 = Convert.ToInt32(search, 2);
                bcd3charfinal.Add(f2.ToString());
            }
            List<string> bcd3charfinalb = new List<string>(){
                string.Concat(bcd3charfinal[0], bcd3charfinal[1]),
                string.Concat(bcd3charfinal[2], bcd3charfinal[3]),
                string.Concat(bcd3charfinal[4], bcd3charfinal[5]),
                string.Concat(bcd3charfinal[6], bcd3charfinal[7]),
                string.Concat(bcd3charfinal[8], bcd3charfinal[9]),
                string.Concat(bcd3charfinal[10], bcd3charfinal[11])
            }
                ;
            textBox4.Text += Environment.NewLine;
            textBox4.Text += String.Join("", bcd3charfinalb);
        }

    }
}
