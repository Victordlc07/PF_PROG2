using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
       

        private void btniniciar_Click(object sender, EventArgs e)
        {
          string connString = ConfigurationManager.ConnectionStrings["MsSQl"].ConnectionString;
            {
               using (SqlConnection conn = new SqlConnection(connString))
               {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                            cmd.Connection = conn;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "Sp_Login";
                            cmd.Parameters.AddWithValue("@NombreUsuario", txtUsuario.Text);
                            cmd.Parameters.AddWithValue("@Contrasena", txtPassword.Text);

                            cmd.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            
                            if (dt.Rows.Count > 0)
                            {
                            MessageBox.Show("Acceso concedido");
                            logueado = txtUsuario.Text;
                            Menu_Principal frmprin = new Menu_Principal();
                            frmprin.ShowDialog();
                            txtUsuario.Text = string.Empty;
                            txtPassword.Text = string.Empty;
                            }
                            else
                            {
                            MessageBox.Show("Usuario o Contraseña incorrecta, favor intentar nuevamente", "Autenticación Fallida");
                            txtUsuario.Text = string.Empty;
                            txtPassword.Text = string.Empty;
                            }
                    }
               }
            }
        }

        public string logueado;
    }
}
