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
        public bool ValidarUsuario(string mail, string contrasena)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.TableDirect;
                cmd.CommandText = "jugador";
                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (mail == reader.GetString(3) && contrasena == reader.GetString(2))
                        {
                            MessageBox.Show("Bienvenido " + reader.GetString(1)); 
                            conn.Close();
                            return true; 
                        }
                    }
                }
                conn.Close();
                return false;
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
                return false; 
            }
        }
    }
    }




