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
    public partial class frmPuestos : Form
    {
        PuestoRepository puestoRepository = new PuestoRepository();
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();
        public frmPuestos()
        {
            InitializeComponent();
        }

        private void FillDGvDepartamentos() //Metodo para llenar el DGV con el metodo GetAll
        {
            //dgvPuestos.DataSource = puestoRepository.GetAll();
            #region Acutializar_DataGridView
            var lista = puestoRepository.GetAll();
            var lista2 = new List<DatosPuesto>();

            foreach (var item in lista)
            {
                var datos = new DatosPuesto()
                {
                    Id = item.Id,
                    Puesto = item.Nombre,
                    Departamento = departamentoRepository.FindById(item.DepartamentoId).Nombre,
                    FechaCreacion = (DateTime)item.FechaRegistro
                };

                lista2.Add(datos);
            }
            dgvPuestos.DataSource = lista2;
            #endregion
        }

        private void frmPuestos_Load(object sender, EventArgs e)
        {
            FillDGvDepartamentos();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmPuestosCrear puestocrear = new frmPuestosCrear();
            puestocrear.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            frmPuestosActualizar frmupdt = new frmPuestosActualizar();
            frmupdt.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmPuestosEliminar puestodel = new frmPuestosEliminar();
            puestodel.ShowDialog();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPuestosCrear puestocrear = new frmPuestosCrear();
            puestocrear.ShowDialog();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPuestosActualizar frmupdt = new frmPuestosActualizar();
            frmupdt.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPuestosEliminar puestodel = new frmPuestosEliminar();
            puestodel.ShowDialog();
        }

        //Clase DatosPuesto para que solo salgan las propiedades listadas aqui en el DataGridView
        private class DatosPuesto
        {
            public int Id { get; set; }
            public string Puesto { get; set; }
            public string Departamento { get; set; }
            public DateTime FechaCreacion { get; set; }
        }

        private void bntUpdtDgv_Click(object sender, EventArgs e)
        {
            FillDGvDepartamentos();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
