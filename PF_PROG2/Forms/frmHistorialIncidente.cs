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

namespace PF_PROG2.Forms
{
    public partial class frmHistorialIncidente : Form
    {
        IncidenteRepository incidenteRepository = new IncidenteRepository();
        HistorialIncidenteRepository historialIncidenteRepository = new HistorialIncidenteRepository();


        public frmHistorialIncidente()
        {
            InitializeComponent();
        }

        private void FillDGvHistorialIncidente() //Metodo para llenar el DGV con el metodo GetAll
        {
            //dgvIncidente.DataSource = incidenteRepository.GetAll().Select(x => new {x.UsuarioReportaId, x.UsuarioAsignadoId, x.Titulo, x.Prioridad, x.Departamento, x.Descripcion}).ToList(); ;
            #region Acutializar_DataGridView
            var lista = historialIncidenteRepository.GetAll();
            var lista2 = new List<DatosHIncidente>();

            foreach (var item in lista)
            {
                var datos = new DatosHIncidente()
                {
                    Id = item.Id,
                    Titulo = incidenteRepository.FindById(item.IncidenteId).Titulo,
                    Descripcion = incidenteRepository.FindById(item.IncidenteId).Descripcion,
                    Comentario = item.Comentario,
                    //Fecha_Cierre = (DateTime)incidenteRepository.FindById(item.IncidenteId).FechaCierre,
                };

                lista2.Add(datos);
            }

            dGVHincidente.DataSource = lista2;
            #endregion
        }

            //Clase DatosPuesto para que solo salgan las propiedades listadas aqui en el DataGridView
        private class DatosHIncidente
        {
            public int Id { get; set; }
            public string Titulo { get; set; }
            public string Comentario { get; set; }
            //public DateTime Fecha_Cierre { get; set; }
            public string Descripcion { get; set; }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHistorialIncidente_Load(object sender, EventArgs e)
        {
            FillDGvHistorialIncidente();
        }
    }
    }
