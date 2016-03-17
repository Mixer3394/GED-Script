using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

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


        public void WriteExcelFile(string brows)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + brows + ";Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\"";
            string xls = @"ZATR0701$";

            OleDbConnection oleDBConnection = new OleDbConnection(connectionString);
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT Stanowisko FROM [" + xls + "]", oleDBConnection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);

            adapter.UpdateCommand = new OleDbCommand("UPDATE [" + xls + "] SET Stanowisko = 'Brygadzista'" +
                                                        " WHERE Stanowisko = 'Brygardzista'", oleDBConnection);

            // For Updates, we need to provide the old values so that we only update the corresponding row.
            adapter.UpdateCommand.Parameters.Add("@OldStanowisko", OleDbType.VarChar, 255, "Stanowisko").SourceVersion = DataRowVersion.Original;
            //adapter.UpdateCommand.Parameters.Add("@OldLastName", OleDbType.Char, 255, "LastName").SourceVersion = DataRowVersion.Original;
            //adapter.UpdateCommand.Parameters.Add("@OldAge", OleDbType.Char, 255, "Age").SourceVersion = DataRowVersion.Original;
            adapter.Update(dataset);

        }






        public DataSet ReadExcelFile(string brows)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            //MessageBox.Show("ReadExcel");

            //string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+brows +";Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\"";

            string connectionString = GetConnectionString(brows);
            //string connectionString = test;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
               // MessageBox.Show("RE2");
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;

                // Get all Sheets in Excel File
                DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                //MessageBox.Show("RE przed pętlą");
                // Loop through all Sheets to get data
                foreach (DataRow dr in dtSheet.Rows)
                {
                    string sheetName = dr["TABLE_NAME"].ToString();

                    if (!sheetName.EndsWith("$"))
                        continue;

                    // Get all rows from the Sheet
                    //MessageBox.Show(sheetName);
                    cmd.CommandText = "SELECT * FROM [" + sheetName + "]";

                    
                    dt.TableName = sheetName;

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dt);

                    ds.Tables.Add(dt);
                }

                cmd = null;
                conn.Close();
                //MessageBox.Show("RE wykonane");
            }

            return ds;
        }

    }
}
