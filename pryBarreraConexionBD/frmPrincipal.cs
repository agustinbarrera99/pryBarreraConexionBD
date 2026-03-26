using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryBarreraConexionBD
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ClassConexionDB objConectarDB = new ClassConexionDB();
            try 
            {
                objConectarDB.ConectarDB();
                lblEstadoConexion.Text = "Base de datos conectada";
                lblEstadoConexion.BackColor = Color.Green;
            } catch {
                lblEstadoConexion.Text = "Error al conectar la base de datos";
                lblEstadoConexion.BackColor = Color.Red;
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
