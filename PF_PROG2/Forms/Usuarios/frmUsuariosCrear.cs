using PF_PROG2.Entities;
using PF_PROG2.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PF_PROG2.Forms.Usuarios
{
    public partial class frmUsuariosCrear : Form
    {
        UsuarioRepository usuariorepository = new UsuarioRepository();
        public frmUsuariosCrear()
        {
            InitializeComponent();
        }

        private void FillDGvUsuarios() //Metodo privado para llenar de DGV con el metodo GetAll
        {
            dgvUsuarios.DataSource = usuariorepository.GetAll();

            //Cargar puestos en el comboBox
            PuestoRepository puestoRepo = new PuestoRepository();
            var listaDepa = puestoRepo.GetAll();

            List<int> listaIDPuesto = new List<int>();
            cbPuesto.Items.Clear();
            foreach (var list in listaDepa)
            {
                cbPuesto.Items.Add(list.Nombre);
                listaIDPuesto.Add(list.Id);
            }
        }

        private void frmUsuariosCrear_Load(object sender, EventArgs e)
        {
            FillDGvUsuarios();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtCedula.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtFechaNacimiento.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtNombreUsuario.Text) || string.IsNullOrWhiteSpace(cbPuesto.Text))
            {
                MessageBox.Show("No deben existir campos Vacios", "Campo vacio");
            }
            else
            {
                #region paraTraerElPuesto
                PuestoRepository _puestoRepo = new PuestoRepository();
                var listaPuesto = _puestoRepo.GetAll();

                List<int> listaIDPuesto = new List<int>();

                foreach (var list in listaPuesto)
                {
                    listaIDPuesto.Add(list.Id);
                }

                #endregion

                UsuarioRepository userRepo = new UsuarioRepository();
                Usuario user = new Usuario();

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.Borrado = 0;
                user.Cedula = txtCedula.Text;
                user.Contrasena = txtContrasena.Text;
                user.Correo = txtCorreo.Text;
                user.Estatus = "A";
                user.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                user.FechaRegistro = DateTime.Now;
                user.NombreUsuario = txtNombreUsuario.Text;
                user.Telefono = txtTelefono.Text;
                user.PuestoId = listaIDPuesto[cbPuesto.SelectedIndex];

                userRepo.Create(user);

                if (user.Nombre != "") //Condicional para crear la entrada y de pueda actualizar el DGV y limpiar los campos.
                {
                    MessageBox.Show("Los Datos han sido actualizados.");
                    FillDGvUsuarios();
                    txtNombre.Text = string.Empty;
                    txtApellido.Text = string.Empty;
                    txtCedula.Text = string.Empty;
                    txtContrasena.Text = string.Empty;
                    txtCorreo.Text = string.Empty;
                    txtFechaNacimiento.Text  = string.Empty;
                    txtNombreUsuario.Text = string.Empty;
                    txtTelefono.Text = string.Empty;
                    cbPuesto.Text = string.Empty;
                }

            }
        }

        private void atrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            txtNombreUsuario.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            cbPuesto.Text = string.Empty;
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtFechaNacimiento_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
