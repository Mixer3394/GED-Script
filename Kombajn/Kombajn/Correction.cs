using System;
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
    public partial class Correction : Form
    {
        private  DataSet ObjectCol;
        private int ColIndex;
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
                    return 
                }
            }
            return true;
        }
        public void LoadList()
        {
            for (int i = 0; i < ObjectCol.Tables[0].Rows.Count; i++)
            {
                //MessageBox.Show(ObjectCol.Tables[0].Rows[i][ColIndex].ToString());

                if (FindItem(ObjectCol.Tables[0].Rows[i][ColIndex].ToString()))
                {
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ObjectCol.Tables[0].Columns[ColIndex].ToString());
        }
    }
}
