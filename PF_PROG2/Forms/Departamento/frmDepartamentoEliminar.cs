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

namespace PF_PROG2
{
    public partial class frmDepartamentoEliminar : Form
    {
        DepartamentoRepository departamentoRepository = new DepartamentoRepository(); //Instanciando los metodos de Departamento

        public frmDepartamentoEliminar()
        {
            InitializeComponent();
        }

        private void FillDGvDepartamentos() //Metodo privado para llenar de DGV con el metodo GetAll
        {
            dgvDepartamentos.DataSource = departamentoRepository.GetAll();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DepartamentoRepository _departamentoRepo = new DepartamentoRepository();
            Departamento depa = new Departamento();

            if (MessageBox.Show("¿Estas seguro de eliminar este departamento?", "Eliminar Departamento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                depa.Id = Convert.ToInt32(dgvDepartamentos.CurrentRow.Cells["ID"].Value);
                depa.Nombre = dgvDepartamentos.CurrentRow.Cells["Nombre"].Value.ToString();
                _departamentoRepo.Delete(depa);

                OperationResult resultupdt = _departamentoRepo.Delete(depa);

                if (resultupdt.Success)
                {
                    MessageBox.Show("El departamento fue eliminado.");
                    FillDGvDepartamentos();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la actualizacion, comunicarse con el Administrador de TI.");
                }
            }
        }

        private void dgvDepartamentos_MouseClick(object sender, MouseEventArgs e)
        {
            txtIdDepartamento.Text = dgvDepartamentos.CurrentRow.Cells["Id"].Value.ToString();
        }

        private void frmDepartamentoEliminar_Load(object sender, EventArgs e)
        {
            FillDGvDepartamentos();
        }

        private void atrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvDepartamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtIdDepartamento_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
