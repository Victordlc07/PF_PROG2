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
    public partial class frmDepartamentoActualizar : Form
    {
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();
        UsuarioRepository usuarioRepository = new UsuarioRepository();

        public frmDepartamentoActualizar()
        {
            InitializeComponent();
        }

        private void FillDGvDepartamentos()
        {
            dgvDepartamentos.DataSource = departamentoRepository.GetAll();
        }

        private void frmDepartamentoActualizar_Load(object sender, EventArgs e)
        {
            FillDGvDepartamentos();
        }

        private void atrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Valor no válido o campo vacío, intentar nuevamente.");
            }
            else
            {
                var info = departamentoRepository.FindById(Convert.ToInt32(dgvDepartamentos.CurrentRow.Cells["Id"].Value)); //variable para buscar en la base de datos basado en el ID seleccioando en el data grid view.
                Login login = new Login();
                //Modificamos los datos necesarios del registro
                info.Nombre = txtNombre.Text;
                info.FechaModificacion = DateTime.Now;
                //info.ModificadoPor = login.logueado;
                departamentoRepository.Update(info); //llamamos el metodo update del departamentoRepository
                
                OperationResult resultupdt = departamentoRepository.Update(info);

               if (resultupdt.Success)
                    {
                    MessageBox.Show("Los Datos han sido actualizados.");
                    FillDGvDepartamentos();
                    txtNombre.Text = string.Empty;
                    txtOldname.Text = string.Empty;

                    }
                    else
                    {
                    MessageBox.Show("Ha ocurrido un error en la actualizacion, comunicarse con el Administrador de TI.");
                    }
            }
        }

        private void dgvDepartamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void dgvDepartamentos_MouseClick(object sender, MouseEventArgs e)
        {
            txtOldname.Text = dgvDepartamentos.CurrentRow.Cells["Nombre"].Value.ToString();
        }
    }
}
