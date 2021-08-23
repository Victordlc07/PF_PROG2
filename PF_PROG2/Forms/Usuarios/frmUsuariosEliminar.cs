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
        PuestoRepository puestoRepository = new PuestoRepository();
        public frmUsuariosEliminar()
        {
            InitializeComponent();
        }

        private void FillDGvUsuarios() //Metodo privado para llenar de DGV con el metodo GetAll
        {
            //dgvUsuarios.DataSource = usuariorepository.GetAll();

            #region Acutializar_DataGridView
            var lista = usuariorepository.GetAll();
            var lista2 = new List<DatosUsuario>();

            foreach (var item in lista)
            {
                var datos = new DatosUsuario()
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Nombre_Usuario = item.NombreUsuario,
                    Puesto = puestoRepository.FindById(item.PuestoId).Nombre
                };

                lista2.Add(datos);
            }

            dgvUsuarios.DataSource = lista2;
            #endregion
        }

        private void frmUsuariosEliminar_Load(object sender, EventArgs e)
        {
            FillDGvUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            var usuario = usuarioRepository.FindById(Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Id"].Value));

            if (MessageBox.Show("¿Estas seguro de eliminar este Usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                usuarioRepository.Delete(usuario);

                OperationResult resultupdt = usuarioRepository.Delete(usuario);

                if (resultupdt.Success)
                {
                    MessageBox.Show("El Usuario fue eliminado.");
                    FillDGvUsuarios();
                    txtIdUsuario.Text = string.Empty;
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

        //Clase DatosPuesto para que solo salgan las propiedades listadas aqui en el DataGridView
        private class DatosUsuario
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Nombre_Usuario { get; set; }
            public string Puesto { get; set; }
        }
    }
}
