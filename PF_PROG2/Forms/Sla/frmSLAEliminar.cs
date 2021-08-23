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
    public partial class frmSLAEliminar : Form
    {
        SLARepository slaRepository = new SLARepository(); //Instanciando los metodos de SLA

        public frmSLAEliminar()
        {
            InitializeComponent();
        }

        private void FillDGvSLA() //Metodo privado para llenar de DGV con el metodo GetAll
        {
            dgvSLA.DataSource = slaRepository.GetAll();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SLARepository _slaRepo = new SLARepository();
            Sla sla = new Sla();

            if (MessageBox.Show("¿Estas seguro de eliminar este sla?", "Eliminar SLA", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sla.Id = Convert.ToInt32(dgvSLA.CurrentRow.Cells["ID"].Value);
                sla.Descripcion = dgvSLA.CurrentRow.Cells["Descripcion"].Value.ToString();
                _slaRepo.Delete(sla);

                OperationResult resultupdt = _slaRepo.Delete(sla);

                if (resultupdt.Success)
                {
                    MessageBox.Show("El SLA fue eliminado.");
                    FillDGvSLA();
                    txtIdSLA.Text = string.Empty;
                    
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la actualizacion, comunicarse con el Administrador de TI.");
                }
            }
        }

        private void dgvSLA_MouseClick(object sender, MouseEventArgs e)
        {
            txtIdSLA.Text = dgvSLA.CurrentRow.Cells["Id"].Value.ToString();
        }

        private void frmSLAEliminar_Load(object sender, EventArgs e)
        {
            FillDGvSLA();
        }

        private void atrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvSLA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtIdSLA_TextChanged(object sender, EventArgs e)
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
