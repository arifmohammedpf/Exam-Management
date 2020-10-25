using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Exam_Cell
{
    public class Connection
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Exam_Cell.mdf;Integrated Security=True");
        public SqlConnection ActiveCon()
        {
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
    }
}
