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

namespace PF_PROG2.Forms.Puestos
{
    public partial class frmPuestos : Form
    {
        PuestoRepository puestoRepository = new PuestoRepository();
        public frmPuestos()
        {
            InitializeComponent();
        }

        private void FillDGvDepartamentos() //Metodo para llenar el DGV con el metodo GetAll
        {
            dgvPuestos.DataSource = puestoRepository.GetAll();
        }

        private void frmPuestos_Load(object sender, EventArgs e)
        {
            FillDGvDepartamentos();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmPuestosCrear puestocrear = new frmPuestosCrear();
            puestocrear.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            frmPuestosActualizar frmupdt = new frmPuestosActualizar();
            frmupdt.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmPuestosEliminar puestodel = new frmPuestosEliminar();
            puestodel.ShowDialog();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPuestosCrear puestocrear = new frmPuestosCrear();
            puestocrear.ShowDialog();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPuestosActualizar frmupdt = new frmPuestosActualizar();
            frmupdt.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPuestosEliminar puestodel = new frmPuestosEliminar();
            puestodel.ShowDialog();
        }
    }
}
