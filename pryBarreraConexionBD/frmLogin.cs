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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string mail = txtMail.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            // Validar campos vacíos
            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(contrasena))
            {
                lblMensaje.Text = "Complete todos los campos para ingresar a la aplicacion";
                return;
            }

            ClassConexionDB objDB = new ClassConexionDB();
            try
            {
                objDB.ConectarDB();

                if (objDB.ValidarUsuario(mail, contrasena))
                {
                    frmPrincipal principal = new frmPrincipal();
                    principal.Show();
                    this.Hide();
                }
                else
                {
                    lblMensaje.Text = "Mail o contraseña incorrectos";
                    txtContrasena.Clear();
                    txtMail.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
