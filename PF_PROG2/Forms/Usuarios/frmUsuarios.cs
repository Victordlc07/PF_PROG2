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
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void FillDGvUsuarios() //Metodo privado para llenar de DGV con el metodo GetAll
        {
            dgvUsuarios.DataSource = usuariorepository.GetAll();
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
    }
}
