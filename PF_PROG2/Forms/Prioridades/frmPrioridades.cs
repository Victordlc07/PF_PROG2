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
    public partial class frmPrioridades : Form
    {
        PrioridadRepository prioridadRepository = new PrioridadRepository();
        SLARepository slaRepository = new SLARepository();
        public frmPrioridades()
        {
            InitializeComponent();
        }

        private void FillDGvPrioridades() //Metodo para llenar el DGV con el metodo GetAll
        {
            //dgvPrioridades.DataSource = prioridadRepository.GetAll();

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
                    SLA_Hrs = slaRepository.FindById(item.SlaId).CantidadHoras
                };

                lista2.Add(datos);
            }

            dgvPrioridades.DataSource = lista2;
            #endregion
        }

        private void frmPrioridades_Load(object sender, EventArgs e)
        {
            FillDGvPrioridades();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmPrioridadesCrear prioridadcrear = new frmPrioridadesCrear();
            prioridadcrear.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            frmPrioridadesActualizar frmupdt = new frmPrioridadesActualizar();
            frmupdt.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmPrioridadesEliminar prioridaddel = new frmPrioridadesEliminar();
            prioridaddel.ShowDialog();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrioridadesCrear prioridadcrear = new frmPrioridadesCrear();
            prioridadcrear.ShowDialog();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrioridadesActualizar frmupdt = new frmPrioridadesActualizar();
            frmupdt.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrioridadesEliminar prioridaddel = new frmPrioridadesEliminar();
            prioridaddel.ShowDialog();
        }
        
        //Clase DatosPuesto para que solo salgan las propiedades listadas aqui en el DataGridView
        private class DatosPrioridad
        {
            public int Id { get; set; }
            public string Prioridad { get; set; }
            public string SLA { get; set; }
            public int SLA_Hrs { get; set; }
        }

        private void bntUpdtDgv_Click(object sender, EventArgs e)
        {
            FillDGvPrioridades();
        }
    }
}
