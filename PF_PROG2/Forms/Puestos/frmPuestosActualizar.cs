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
    public partial class frmPuestosActualizar : Form
    {
        PuestoRepository puestoRepository = new PuestoRepository();
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();
        public frmPuestosActualizar()
        {
            InitializeComponent();
        }

        private void FillDGvPuestos() //Metodo para llenar el DGV con el metodo GetAll
        {

            #region Acutializar_DataGridView
            var lista = puestoRepository.GetAll();
            var lista2 = new List<DatosPuesto>();

            foreach (var item in lista)
            {
                var datos = new DatosPuesto()
                {
                    Id = item.Id,
                    Puesto = item.Nombre,
                    Departamento = departamentoRepository.FindById(item.DepartamentoId).Nombre
                };

                lista2.Add(datos);
            }
            dgvPuestos.DataSource = lista2;
            #endregion
        }

        private void frmPuestosActualizar_Load(object sender, EventArgs e)
        {
            FillDGvPuestos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debes llenar los campos nombre", "Campo vacio");
            }
            else
            {
                //PuestoRepository _puestoRepo = new PuestoRepository();

                DepartamentoRepository _departamentoRepo = new DepartamentoRepository();

                var infoPuesto = puestoRepository.FindById(Convert.ToInt32(dgvPuestos.CurrentRow.Cells["Id"].Value));
                var infoDepa = _departamentoRepo.FindById(infoPuesto.DepartamentoId);

                infoPuesto.Nombre = txtNombre.Text;
                infoPuesto.FechaModificacion = DateTime.Now;
                infoPuesto.DepartamentoId = infoDepa.Id;
                puestoRepository.Update(infoPuesto);

                OperationResult resultupdt = puestoRepository.Update(infoPuesto);

                if (resultupdt.Success)
                {
                    MessageBox.Show("Los Datos de puesto han sido actualizados.");

                    FillDGvPuestos();
                    txtNombre.Text = string.Empty;
                    txtOldname.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la actualizacion, comunicarse con el Administrador de TI.");
                }
            }
        }

        private void atrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void dgvPuestos_MouseClick(object sender, MouseEventArgs e)
        {
            txtOldname.Text = dgvPuestos.CurrentRow.Cells["Puesto"].Value.ToString();
        }

        //Clase DatosPuesto para que solo salgan las propiedades listadas aqui en el DataGridView
        private class DatosPuesto
        {
            public int Id { get; set; }
            public string Puesto { get; set; }
            public string Departamento { get; set; }
        }

    }
}
