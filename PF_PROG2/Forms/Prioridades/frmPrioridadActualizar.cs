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

namespace PF_PROG2.Forms.Prioridades
{
    public partial class frmPrioridadesActualizar : Form
    {
        PrioridadRepository prioridadRepository = new PrioridadRepository();
        SLARepository slaRepository = new SLARepository();
        public frmPrioridadesActualizar()
        {
            InitializeComponent();
        }

        private void FillDGvPrioridades() //Metodo para llenar el DGV con el metodo GetAll
        {
            //dgvPrioridades.DataSource = prioridadRepository.GetAll().Select(x => new { x.Id, x.Nombre}).ToList();

            #region Acutializar_DataGridView
            var lista = prioridadRepository.GetAll();
            var lista2 = new List<DatosPrioridad>();

            foreach (var item in lista)
            {
                var datos = new DatosPrioridad()
                {
                    Id = item.Id,
                    Prioridad = item.Nombre,
                    SLA = slaRepository.FindById(item.SlaId).Descripcion,
                    SLA_Hrs = slaRepository.FindById(item.SlaId).CantidadHoras,
                    Estado = item.Estatus

                };

                lista2.Add(datos);
            }

            dgvPrioridades.DataSource = lista2;
            #endregion

        }

        private void frmPrioridadesActualizar_Load(object sender, EventArgs e)
        {
            FillDGvPrioridades();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debes llenar los campos", "Campo vacio");
            }
            else
            {
                 SLARepository _slaRepo = new SLARepository();
                var infoPrioridad = prioridadRepository.FindById(Convert.ToInt32(dgvPrioridades.CurrentRow.Cells["Id"].Value));
                var infoSla = _slaRepo.FindById(infoPrioridad.SlaId);

                infoPrioridad.Nombre = txtNombre.Text;
                infoPrioridad.FechaModificacion = DateTime.Now;
                infoPrioridad.SlaId = infoSla.Id;
                prioridadRepository.Update(infoPrioridad);

                OperationResult resultupdt = prioridadRepository.Update(infoPrioridad);

                if (resultupdt.Success)
                {
                    MessageBox.Show("La prioridad ha sido actualizada.");
                    FillDGvPrioridades();
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

        private void dgvPrioridades_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void dgvPrioridades_MouseClick(object sender, MouseEventArgs e)
        {
            txtOldname.Text = dgvPrioridades.CurrentRow.Cells["Prioridad"].Value.ToString();
        }

        //Clase DatosPuesto para que solo salgan las propiedades listadas aqui en el DataGridView
        private class DatosPrioridad
        {
            public int Id { get; set; }
            public string Prioridad { get; set; }
            public string SLA { get; set; }
            public int SLA_Hrs { get; set; }
            public string Estado { get; set; }
        }
    }
}
