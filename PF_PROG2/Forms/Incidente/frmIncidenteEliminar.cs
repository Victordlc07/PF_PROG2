using PF_PROG2.Entities;
using PF_PROG2.Repositories;
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
    public partial class frmIncidenteEliminar : Form
    {
        IncidenteRepository incidenteRepository = new IncidenteRepository();
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();
        PrioridadRepository prioridadRepository = new PrioridadRepository();

        public frmIncidenteEliminar()
        {
            InitializeComponent();
        }

        private void FillDGvIncidente() //Metodo para llenar el DGV con el metodo GetAll
        {
            //dgvIncidente.DataSource = incidenteRepository.GetAll().Select(x => new { x.Id, x.Titulo, x.ComentarioCierre}).ToList();
           
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

            dgvIncidente.DataSource = lista2;
            #endregion
        }

        private void frmIncidenteEliminar_Load(object sender, EventArgs e)
        {
            FillDGvIncidente();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            IncidenteRepository incidenteRepository = new IncidenteRepository();
            HistorialIncidenteRepository historepo = new HistorialIncidenteRepository();
            HistorialIncidente histo = new HistorialIncidente();
            var incidente = incidenteRepository.FindById(Convert.ToInt32(dgvIncidente.CurrentRow.Cells["ID"].Value));

            if (string.IsNullOrWhiteSpace(txtComentsol.Text) || string.IsNullOrWhiteSpace(txtIncidente.Text))
            {
                MessageBox.Show("Favor introducir comentario de la solución y seleccionar el incidente.", "Campos vacíos");
            }
            else
            { 
                if (MessageBox.Show("¿Desea solucionar este incidente?", "Solucionar incidente", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    histo.Comentario = txtComentsol.Text;
                    histo.IncidenteId = Convert.ToInt32(dgvIncidente.CurrentRow.Cells["ID"].Value);
                    histo.Borrado = 0;
                    histo.FechaRegistro = DateTime.Now;
                    histo.Estatus = "A";
                    historepo.Create(histo); //utilizamos el metodo crear para agregar un nuevo comentario

                    var updateincident = incidenteRepository.FindById(Convert.ToInt32(dgvIncidente.CurrentRow.Cells["ID"].Value));
                    updateincident.FechaModificacion = DateTime.Now;
                    updateincident.FechaCierre = DateTime.Now;
                    updateincident.ComentarioCierre = txtComentsol.Text;
                    updateincident.Borrado = 1;
                    updateincident.Estatus = "I";
                    incidenteRepository.Delete(updateincident); //Actualizamos el incidente al que se le agrego el comentario Solucion

                    //incidenteRepository.Delete(incidente);

                    OperationResult resultupdt = incidenteRepository.Delete(updateincident);

                    if (resultupdt.Success)
                    {
                        MessageBox.Show("El incidente fue solucionado.");
                        FillDGvIncidente();
                        txtComentsol.Text = string.Empty;
                        txtIncidente.Text = string.Empty;
                    }
                    else
                    {
                    MessageBox.Show("Ha ocurrido un error en la actualizacion, comunicarse con el Administrador de TI.");
                    }
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

        private void dgvIncidente_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void dgvIncidente_MouseClick(object sender, MouseEventArgs e)
        {
            txtIncidente.Text = dgvIncidente.CurrentRow.Cells["Titulo"].Value.ToString();
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
    }
}
