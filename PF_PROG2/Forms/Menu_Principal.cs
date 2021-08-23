using PF_PROG2.Forms;
using PF_PROG2.Forms.Prioridades;
using PF_PROG2.Forms.Puestos;
using PF_PROG2.Forms.Usuarios;
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
    public partial class Menu_Principal : Form
    {
        IncidenteRepository incidenteRepository = new IncidenteRepository();
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();
        PrioridadRepository prioridadRepository = new PrioridadRepository();
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void FillDGvIncidentes()
        {
            // dGvincidentes.DataSource = incidenteRepository.GetAll().Select(x => new { x.Titulo, x.UsuarioReportaId, x.UsuarioAsignadoId, x.PrioridadId, x.DepartamentoId, x.Descripcion }).ToList();
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
                    Prioridad = prioridadRepository.FindById(item.PrioridadId).Nombre,
                    Departamento = departamentoRepository.FindById(item.DepartamentoId).Nombre,
                    Titulo = item.Titulo,
                    Descripcion = item.Descripcion,
                    FechaRegisto = (DateTime)item.FechaRegistro,
                };

                lista2.Add(datos);
            }

            dGvincidentes.DataSource = lista2;
            #endregion
        }

        private void Menu_Principal_Load(object sender, EventArgs e)
        {
            FillDGvIncidentes();
        }

        private void departamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartamento dept = new frmDepartamento();
            dept.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dGvincidentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void puestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPuestos puestos = new frmPuestos();
            puestos.ShowDialog();
        }

        private void salirXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUsuarios usuarios = new frmUsuarios();
            usuarios.ShowDialog();
        }

        private void sLAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSLA sla = new frmSLA();
            sla.ShowDialog();
        }

        private void sLAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrioridades frmPrioridades = new frmPrioridades();
            frmPrioridades.ShowDialog();
        }

        private void incidenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIncidente frminc = new frmIncidente();
            frminc.ShowDialog();
        }

        private void historialIncidentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorialIncidente frmh = new frmHistorialIncidente();
            frmh.ShowDialog();
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
            FillDGvIncidentes();
        }
    }
}
