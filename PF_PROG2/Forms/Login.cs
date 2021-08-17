using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PF_PROG2.Entities;
using PF_PROG2.Repository;

namespace PF_PROG2
{
    public partial class Login : Form

        
    {
        //GenericRepository _dbcontext = new GenericRepository();
       
        public Login()
        {
           // _dbcontext.Create(new t)

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Usuario usuario = new Usuario();

            if (txtUsuario.Text == usuario.NombreUsuario && txtPassword.Text == usuario.Contrasena)
            {
                MessageBox.Show("Acceso concedido");

            }
           else
            {
                MessageBox.Show("Usuario o contraseña inválido, favor internet de nuevo");
                txtUsuario.Text = "";
                txtPassword.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
