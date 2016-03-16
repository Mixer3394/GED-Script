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


        private void WriteExcelFile(string brows)
        {
            string connectionString = GetConnectionString(brows);

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;

                cmd.CommandText = "CREATE TABLE [table1] (id INT, name VARCHAR, datecol DATE );";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO [table1](id,name,datecol) VALUES(1,'AAAA','2014-01-01');";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO [table1](id,name,datecol) VALUES(2, 'BBBB','2014-01-03');";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO [table1](id,name,datecol) VALUES(3, 'CCCC','2014-01-03');";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "UPDATE [table1] SET name = 'DDDD' WHERE id = 3;";
                cmd.ExecuteNonQuery();

                conn.Close();
            }
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
