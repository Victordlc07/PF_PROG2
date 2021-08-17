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
    public partial class frmUsuariosEliminar : Form
    {
        UsuarioRepository usuariorepository = new UsuarioRepository();
        public frmUsuariosEliminar()
        {
            InitializeComponent();
        }

        private void FillDGvUsuarios() //Metodo privado para llenar de DGV con el metodo GetAll
        {
            dgvUsuarios.DataSource = usuariorepository.GetAll();

            /*//Cargar puestos en el comboBox
            PuestoRepository puestoRepo = new PuestoRepository();
            var listaDepa = puestoRepo.GetAll();

            List<int> listaIDPuesto = new List<int>();
            cbPuesto.Items.Clear();
            foreach (var list in listaDepa)
            {
                cbPuesto.Items.Add(list.Nombre);
                listaIDPuesto.Add(list.Id);
            }*/
        }

        private void frmUsuariosEliminar_Load(object sender, EventArgs e)
        {
            FillDGvUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            var usuario = usuarioRepository.FindById(Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Id"].Value));

            if (MessageBox.Show("¿Estas seguro de eliminar este Puesto?", "Eliminar Puesto", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                usuarioRepository.Delete(usuario);

                OperationResult resultupdt = usuarioRepository.Delete(usuario);

                if (resultupdt.Success)
                {
                    MessageBox.Show("El departamento fue eliminado.");
                    FillDGvUsuarios();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la actualizacion, comunicarse con el Administrador de TI.");
                }
            }
        }

        private void atrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsuarios_MouseClick(object sender, MouseEventArgs e)
        {
            txtIdUsuario.Text = dgvUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
        }
    }
}
