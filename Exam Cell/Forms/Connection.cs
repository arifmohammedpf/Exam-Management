using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Exam_Cell
{
    public class Connection
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Exam_Cell.mdf;Integrated Security=True");
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=testapp.accdb");
        public OleDbConnection ActiveCon()
        {
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public OleDbConnection CloseCon()
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            return con;
        }
        // open settings.settings from properties in solution explorer to change connection string

        // DELETE BELOW CODE AFTER COPY

        //try
        //{
        //    OleDbCommand command = new OleDbCommand(queryString, con.ActiveCon());
        //    command.ExecuteNonQuery();
        //    con.Close();
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    con.Close();
        //    return;
        //}
        
    }
}
