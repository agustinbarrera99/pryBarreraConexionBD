using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pryBarreraConexionBD
{
    internal class ClassConexionDB
    {
        public void ConectarDB()
        {
            OleDbConnection conn = new OleDbConnection();

            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; " +
                "Data Source=" + Application.StartupPath + "\\..\\..\\base\\baseJuegoRPG.accdb";

            conn.Open();

        }



    }
}
