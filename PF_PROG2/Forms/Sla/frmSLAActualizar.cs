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

namespace PF_PROG2.Forms
{
    public partial class frmSLAActualizar : Form
    {
        SLARepository departamentoRepository = new SLARepository();

        public frmSLAActualizar()
        {
            InitializeComponent();
        }

        private void FillDGvSLA()
        {
            dgvSLA.DataSource = departamentoRepository.GetAll();
        }

        private void frmSLAActualizar_Load(object sender, EventArgs e)
        {
            FillDGvSLA();
        }

        private void atrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcanthrs.Text) || string.IsNullOrWhiteSpace(txtdescripcion.Text))
            {
                MessageBox.Show("Valor no válido o campo vacío, intentar nuevamente.");
            }
            else
            {
                var info = departamentoRepository.FindById(Convert.ToInt32(dgvSLA.CurrentRow.Cells["Id"].Value)); //variable para buscar en la base de datos basado en el ID seleccioando en el data grid view.

                //Modificamos los datos necesarios del registro
                info.CantidadHoras = Convert.ToInt32(txtcanthrs.Text);
                info.Descripcion = txtdescripcion.Text;
                info.FechaModificacion = DateTime.Now;

                departamentoRepository.Update(info); //llamamos el metodo update del departamentoRepository
                
                OperationResult resultupdt = departamentoRepository.Update(info);

               if (resultupdt.Success)
                    {
                    MessageBox.Show("Los Datos de SLA han sido actualizados.");
                    txtcanthrs.Text = string.Empty;
                    txtdescripcion.Text = string.Empty;
                    txtOldname.Text = string.Empty;
                    }
                    else
                    {
                    MessageBox.Show("Ha ocurrido un error en la actualizacion, comunicarse con el Administrador de TI.");
                    }
            }
        }

        private void dgvSLA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtOldname_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dgvSLA_MouseClick(object sender, MouseEventArgs e)
        {
            txtOldname.Text = dgvSLA.CurrentRow.Cells["Descripcion"].Value.ToString();
        }
    }
}
