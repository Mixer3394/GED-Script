﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Kombajn
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            //this.dataGridView1.Columns[].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        DataSet DataExcel;
        Excel excel = new Excel();

        private void button_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            if (opfd.ShowDialog() == DialogResult.OK)
                textselect.Text = opfd.FileName;
        }

        private void button_show_Click(object sender, EventArgs e)
        {
           
            
            //Excel excel = new Excel();
            comboBox1.Items.Clear();
            if (textselect.Text != "")
            {
                //MessageBox.Show("Uruchamianie read-excela");
                DataExcel = excel.ReadExcelFile(textselect.Text);
                dataGridView1.DataSource = DataExcel.Tables[0];
                //MessageBox.Show("Koniec");
            }
            else MessageBox.Show("ERROR");
            int countColumn = dataGridView1.ColumnCount;
            for (int i = 0; i<countColumn; i++)
            {
                comboBox1.Items.Add(dataGridView1.Columns[i].HeaderText.ToString());
            }
        }

        

        private void button_correct_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView1.RowCount.ToString());
            //DataSet data = dataGridView1.Rows[2];
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz kolumnę do poprawy!");
            }
            else
            {
                Correction Correct = new Correction(DataExcel, comboBox1.SelectedIndex);
                Correct.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            excel.WriteExcelFile(dataGridView1);
            MessageBox.Show("Zapisano poprawnie.");
        }

        private void button_null_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                if (textBox_null.Text != "")
                {
                    for (int i = 0; i < (dataGridView1.RowCount-1); i++)
                    {
                        //try
                        //{
                        //MessageBox.Show(dataGridView1[comboBox1.SelectedIndex, i].Value.ToString());
                            if (dataGridView1[comboBox1.SelectedIndex, i].Value.ToString() == "")
                            {

                                dataGridView1[comboBox1.SelectedIndex, i].Value = textBox_null.Text;
                            }
                        //}
                        //catch (Exception e)
                        //{
                        //    MessageBox.Show(e.Message);
                        //}
                        

                    }
                }
                else MessageBox.Show("Podaj nową wartość");
            }
            else MessageBox.Show("Wybierz kolumnę do poprawy");
        }
    }
}
