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
    public partial class frmUsuariosActualizar : Form
    {
        UsuarioRepository usuariorepository = new UsuarioRepository();
        public frmUsuariosActualizar()
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

            private void frmUsuariosActualizar_Load(object sender, EventArgs e)
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
                PuestoRepository _puestoRepo = new PuestoRepository();
                var infoUsuario = usuariorepository.FindById(Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["ID"].Value));
                var infoPuesto = _puestoRepo.FindById(infoUsuario.PuestoId);
                var listaPuesto = _puestoRepo.GetAll();
                List<int> listaIDPuesto = new List<int>();

                foreach (var list in listaPuesto)
                {
                    listaIDPuesto.Add(list.Id);
                }

                infoUsuario.Nombre = txtNombre.Text;
                infoUsuario.Id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Id"].Value);
                infoUsuario.FechaModificacion = DateTime.Now;
                infoUsuario.Estatus = "A";
                infoUsuario.Apellido = txtApellido.Text;
                infoUsuario.Cedula = txtCedula.Text;
                infoUsuario.Contrasena = txtContrasena.Text;
                infoUsuario.Correo = txtCorreo.Text;
                infoUsuario.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                infoUsuario.NombreUsuario = txtNombreUsuario.Text;
                infoUsuario.Telefono = txtTelefono.Text;

                OperationResult resultupdt = usuariorepository.Update(infoUsuario);

                if (resultupdt.Success)
                {
                    MessageBox.Show("Los Datos han sido actualizados.");
                    usuariorepository.Update(infoUsuario);
                    FillDGvUsuarios();
                }
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
        }

        private void dgvUsuarios_MouseClick(object sender, MouseEventArgs e)
        {
            txtNombre.Text = dgvUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
            txtApellido.Text = dgvUsuarios.CurrentRow.Cells["Apellido"].Value.ToString();
            txtCedula.Text = dgvUsuarios.CurrentRow.Cells["Cedula"].Value.ToString();
            txtCorreo.Text = dgvUsuarios.CurrentRow.Cells["Correo"].Value.ToString();
            txtFechaNacimiento.Text = dgvUsuarios.CurrentRow.Cells["FechaNacimiento"].Value.ToString();
            txtTelefono.Text = dgvUsuarios.CurrentRow.Cells["Telefono"].Value.ToString();
            txtNombreUsuario.Text = dgvUsuarios.CurrentRow.Cells["NombreUsuario"].Value.ToString();
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
            txtCorreo.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtNombreUsuario.Text = string.Empty;
        }
    }
}
