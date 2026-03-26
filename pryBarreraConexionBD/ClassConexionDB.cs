using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryBarreraConexionBD
{
    internal class ClassConexionDB
    {
        private OleDbConnection conn;

        public void ConectarDB()
        {
            conn = new OleDbConnection();

            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; " +
                "Data Source=" + Application.StartupPath + "\\..\\..\\base\\baseJuegoRPG.accdb";

            conn.Open();
        }

        public DataTable ObtenerDatos(string consulta)
        {
            DataTable tabla = new DataTable();

            OleDbDataAdapter adaptador = new OleDbDataAdapter(consulta, conn);
            adaptador.Fill(tabla);

            return tabla;
        }
    }
}
