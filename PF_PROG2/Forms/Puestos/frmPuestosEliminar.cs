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

namespace PF_PROG2.Forms.Puestos
{
    public partial class frmPuestosEliminar : Form
    {
        PuestoRepository puestoRepository = new PuestoRepository();
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();
        public frmPuestosEliminar()
        {
            InitializeComponent();
        }

        private void FillDGvPuestos() //Metodo para llenar el DGV con el metodo GetAll
        {
            dgvPuestos.DataSource = puestoRepository.GetAll().Select(x => new { x.Id, x.Nombre}).ToList();

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

        private void frmPuestosEliminar_Load(object sender, EventArgs e)
        {
            FillDGvPuestos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            PuestoRepository puestoRepository = new PuestoRepository();
            var puesto = puestoRepository.FindById(Convert.ToInt32(dgvPuestos.CurrentRow.Cells["ID"].Value));

            if (MessageBox.Show("¿Estas seguro de eliminar este Puesto?", "Eliminar Puesto", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                puestoRepository.Delete(puesto);

            OperationResult resultupdt = puestoRepository.Delete(puesto);

                if (resultupdt.Success)
                {
                    MessageBox.Show("El departamento fue eliminado.");
                    FillDGvPuestos();
                    txtIdPuesto.Text = string.Empty;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvPuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void dgvPuestos_MouseClick(object sender, MouseEventArgs e)
        {
            txtIdPuesto.Text = dgvPuestos.CurrentRow.Cells["Puesto"].Value.ToString();
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
