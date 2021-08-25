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
    public partial class frmIncidente : Form
    {
        IncidenteRepository incidenteRepository = new IncidenteRepository();
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();
        PrioridadRepository prioridadRepository = new PrioridadRepository();
        public frmIncidente()
        {
            InitializeComponent();
        }

        private void FillDGvDepartamentos() //Metodo para llenar el DGV con el metodo GetAll
        {
            //dgvIncidente.DataSource = incidenteRepository.GetAll().Select(x => new {x.UsuarioReportaId, x.UsuarioAsignadoId, x.Titulo, x.Prioridad, x.Departamento, x.Descripcion}).ToList(); ;
            #region Acutializar_DataGridView
            var lista = incidenteRepository.GetAll();
            var lista2 = new List<DatosIncidente>();

            foreach (var item in lista)
            {
                var datos = new DatosIncidente()
                {
                    Id = item.Id,
                    Usuario_Afectado = usuarioRepository.FindById(item.UsuarioReportaId).Nombre,
                    Usuario_Asignado = usuarioRepository.FindById(item.UsuarioAsignadoId).Nombre,
                    Prioridad= prioridadRepository.FindById(item.PrioridadId).Nombre,
                    Departamento = departamentoRepository.FindById(item.DepartamentoId).Nombre,
                    Titulo = item.Titulo,
                    Descripcion = item.Descripcion,
                    FechaRegisto = (DateTime)item.FechaRegistro
                };

                lista2.Add(datos);
            }

            dgvIncidente.DataSource = lista2;
            #endregion
        }

        private void frmIncidente_Load(object sender, EventArgs e)
        {
            FillDGvDepartamentos();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmIncidenteCrear incidentecrear = new frmIncidenteCrear();
            incidentecrear.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            frmIncidenteActualizar frmupdt = new frmIncidenteActualizar();
            frmupdt.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmIncidenteEliminar incidentedel = new frmIncidenteEliminar();
            incidentedel.ShowDialog();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIncidenteCrear incidentecrear = new frmIncidenteCrear();
            incidentecrear.ShowDialog();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIncidenteActualizar frmupdt = new frmIncidenteActualizar();
            frmupdt.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIncidenteEliminar incidentedel = new frmIncidenteEliminar();
            incidentedel.ShowDialog();
        }

        //Clase DatosPuesto para que solo salgan las propiedades listadas aqui en el DataGridView
        private class DatosIncidente
        {
            public int Id { get; set; }
            public string Usuario_Afectado { get; set; }
            public string Usuario_Asignado { get; set; }
            public string Prioridad { get; set; }
            public string Departamento { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public DateTime FechaRegisto { get; set; }
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
