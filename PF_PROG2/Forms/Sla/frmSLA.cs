using PF_PROG2.Forms;
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

namespace PF_PROG2
{
    public partial class frmSLA : Form
    {
        SLARepository slaRepository = new SLARepository();
        public frmSLA()
        {
            InitializeComponent();
        }

        public void FillDGvSLA()
        {
            dgvSLA.DataSource = slaRepository.GetAll();
        }

        private void frmSLA_Load(object sender, EventArgs e)
        {
            FillDGvSLA();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSLACrear frmcrear = new frmSLACrear();
            frmcrear.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            frmSLAActualizar frmactualizar = new frmSLAActualizar();
            frmactualizar.ShowDialog();
        }

        private void dgvSLA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmSLAEliminar frmEliminar = new frmSLAEliminar();
            frmEliminar.ShowDialog();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSLACrear frmCrear = new frmSLACrear();
            frmCrear.ShowDialog();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSLAActualizar frmupdt = new frmSLAActualizar();
            frmupdt.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSLAEliminar frmEliminar = new frmSLAEliminar();
            frmEliminar.ShowDialog();
        }

        private void bntUpdtDgv_Click(object sender, EventArgs e)
        {
            FillDGvSLA();
        }
    }
}
