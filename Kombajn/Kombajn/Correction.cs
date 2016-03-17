using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace Kombajn
{
    public partial class Correction : Form
    {
        private  DataSet ObjectCol;
        private int ColIndex;

        public string[,] RegText;
        private int CountRegText = 0;

        public Correction(DataSet Data, int SelectCol)
        {
            InitializeComponent();
            ObjectCol = Data;
            ColIndex = SelectCol;
            LoadList();
            
        }

        private bool FindItem(string ItemName)
        {
            for (int i = 0; i< checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.Items[i].ToString() == ItemName)
                {
                    return true;
                }
            }
            return false;
        }

        public void LoadList()
        {
            for (int i = 0; i < ObjectCol.Tables[0].Rows.Count; i++)
            {
                //MessageBox.Show(ObjectCol.Tables[0].Rows[i][ColIndex].ToString());

                if (!FindItem(ObjectCol.Tables[0].Rows[i][ColIndex].ToString()))
                {
                    checkedListBox1.Items.Add(ObjectCol.Tables[0].Rows[i][ColIndex].ToString());
                }
            }
            label1.Text = "Ilość rekordów: " + checkedListBox1.Items.Count.ToString();
        }

        private bool FindNewElement(string Element)
        {
            for (int i = 0; i< checkedListBox1.CheckedItems.Count; i++)
            {
                if (checkedListBox1.CheckedItems[i].ToString() == Element) return true;
            }
            return false;
        }

        private void NewRekord()
        {
            for(int i = 0; i < ObjectCol.Tables[0].Rows.Count; i++)
            {
                //MessageBox.Show(ObjectCol.Tables[0].Rows[i][ColIndex].ToString());

                if (FindNewElement(ObjectCol.Tables[0].Rows[i][ColIndex].ToString()))
                {
                    ObjectCol.Tables[0].Rows[i][ColIndex] = textBox_new.Text;
                }
            }
        }

        public void LoadRegex(string Br)
        {
            int a = 0;
            CountRegText = -1;
            RegText = new string[100000, 3];
                string line;

                StreamReader file = new StreamReader(Br);
                while ((line = file.ReadLine()) != "END")
                {
                a++;
                        if (a == 1)
                        {
                            CountRegText++;
                            RegText[CountRegText, 0] = line;
                        }
                        else if (a == 2)
                        {
                            RegText[CountRegText, 1] = line;
                        }
                        else if (a == 3)
                        {
                            a = 0;
                            
                        }
                    }
                    file.Close();

        }

        public string StartAnalizeRegex(string Value)
        {
            string result = Value;
            for (int i = 0; i <= CountRegText; i++)
            {


                string input = result;
                string pattern = RegText[i,0];
                string replacement = RegText[i, 1];
                result = Regex.Replace(input, pattern, replacement);
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_new.Text != "")
            {
                NewRekord();
                checkedListBox1.Items.Clear();
                LoadList();
            }
            else MessageBox.Show("Nie podałeś nowej wartości!");
        }

        private void button_regex_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd2 = new OpenFileDialog();
            if (opfd2.ShowDialog() == DialogResult.OK)
                textBox_regex.Text = opfd2.FileName;
        }

        private void button_wykReg_Click(object sender, EventArgs e)
        {
            if (textBox_regex.Text != "")
            {
                //string text = File.ReadAllText(textBox_regex.Text);
                LoadRegex(textBox_regex.Text);
                //MessageBox.Show(ObjectCol.Tables[0].Rows.Count.ToString());
                for (int i = 0; i < ObjectCol.Tables[0].Rows.Count; i++)
                {

                        //MessageBox.Show("petla");
                        ObjectCol.Tables[0].Rows[i][ColIndex] = StartAnalizeRegex(ObjectCol.Tables[0].Rows[i][ColIndex].ToString());
                }
                MessageBox.Show("zakonczyłem");
                checkedListBox1.Items.Clear();
                LoadList();
            }

        }
    }
}
