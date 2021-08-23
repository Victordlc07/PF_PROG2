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
    public partial class frmUsuarios : Form
    {
        UsuarioRepository usuariorepository = new UsuarioRepository();
        PuestoRepository puestoRepository = new PuestoRepository();
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void FillDGvUsuarios() //Metodo privado para llenar de DGV con el metodo GetAll
        {
            // dgvUsuarios.DataSource = usuariorepository.GetAll();

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

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            FillDGvUsuarios();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmUsuariosCrear usercreate = new frmUsuariosCrear();
            usercreate.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuariosCrear usercreate = new frmUsuariosCrear();
            usercreate.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            frmUsuariosActualizar userupdt = new frmUsuariosActualizar();
            userupdt.ShowDialog();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuariosActualizar userupdt = new frmUsuariosActualizar();
            userupdt.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmUsuariosEliminar usuariodel = new frmUsuariosEliminar();
            usuariodel.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuariosEliminar usuariodel = new frmUsuariosEliminar();
            usuariodel.ShowDialog();
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

        private void bntUpdtDgv_Click(object sender, EventArgs e)
        {
            FillDGvUsuarios();
        }
    }
}
