using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.IO;


/* To work eith EPPlus library */
using OfficeOpenXml;
using OfficeOpenXml.Drawing;

/* For I/O purpose */


/* For Diagnostics */
using System.Diagnostics;



namespace Kombajn
{
    class Excel
    {

        //MessageBox.Show("Jestem w excel");
        private string GetConnectionString(string Brows)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Brows + ";Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\"";

            return connectionString;
        }


        public void WriteExcelFile(DataGridView dGV)
        {



            var dia = new System.Windows.Forms.SaveFileDialog();
            dia.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dia.Filter = "Excel Worksheets (*.xlsx)|*.xlsx|xls file (*.xls)|*.xls|All files (*.*)|*.*";
            if (dia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataTable data = (DataTable)(dGV.DataSource);
                var excel = new OfficeOpenXml.ExcelPackage();
                var ws = excel.Workbook.Worksheets.Add("worksheet-name");
                // you can also use LoadFromCollection with an `IEnumerable<SomeType>`
                ws.Cells["A1"].LoadFromDataTable(data, true, OfficeOpenXml.Table.TableStyles.Light1);
                ws.Cells[ws.Dimension.Address.ToString()].AutoFitColumns();

                using (var file = File.Create(dia.FileName))
                    excel.SaveAs(file);
            }




            //string stOutput = "";
            //// Export titles:
            //string sHeaders = "";

            //for (int j = 0; j < dGV.Columns.Count; j++)
            //    sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            //stOutput += sHeaders + "\r\n";
            //// Export data.
            //for (int i = 0; i < dGV.RowCount - 1; i++)
            //{
            //    string stLine = "";
            //    for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
            //        stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
            //    stOutput += stLine + "\r\n";
            //}
            //Encoding utf16 = Encoding.GetEncoding(1254);
            //byte[] output = utf16.GetBytes(stOutput);
            //FileStream fs = new FileStream((filenames + "x"), FileMode.Create);
            //BinaryWriter bw = new BinaryWriter(fs);
            //bw.Write(output, 0, output.Length); //write the encoded file
            //bw.Flush();
            //bw.Close();
            //fs.Close();

        }






        public DataSet ReadExcelFile(string brows)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
           
            string connectionString = GetConnectionString(brows);

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {

                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                foreach (DataRow dr in dtSheet.Rows)
                {
                    string sheetName = dr["TABLE_NAME"].ToString();

                    if (!sheetName.EndsWith("$"))
                        continue;
                    cmd.CommandText = "SELECT * FROM [" + sheetName + "]";  
                    dt.TableName = sheetName;
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);
                    ds.Tables.Add(dt);
                }
                cmd = null;
                conn.Close();
            }
            return ds;
        }

    }
}
