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
    public partial class frmDepartamento : Form
    {
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();
        public frmDepartamento()
        {
            InitializeComponent();
        }

        private void FillDGvDepartamentos()
        {
            dgvDepartamentos.DataSource = departamentoRepository.GetAll();
        }

        private void frmDepartamento_Load(object sender, EventArgs e)
        {
            FillDGvDepartamentos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDepartamentoCrear frmcrear = new frmDepartamentoCrear();
            frmcrear.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            frmDepartamentoActualizar frmactualizar = new frmDepartamentoActualizar();
            frmactualizar.ShowDialog();
        }

        private void dgvDepartamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmDepartamentoEliminar frmEliminar = new frmDepartamentoEliminar();
            frmEliminar.ShowDialog();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartamentoCrear frmCrear = new frmDepartamentoCrear();
            frmCrear.ShowDialog();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartamentoActualizar frmupdt = new frmDepartamentoActualizar();
            frmupdt.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartamentoEliminar frmEliminar = new frmDepartamentoEliminar();
            frmEliminar.ShowDialog();
        }
    }
}
