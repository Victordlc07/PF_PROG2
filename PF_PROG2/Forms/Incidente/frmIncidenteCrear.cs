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

namespace PF_PROG2
{
    public partial class frmIncidenteCrear : Form
    {
        IncidenteRepository incidenteRepository = new IncidenteRepository();
        PrioridadRepository prioridadRepository = new PrioridadRepository();
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();

        public frmIncidenteCrear()
        {
            InitializeComponent();
        }

        private void frmIncidenteCrear_Load(object sender, EventArgs e)
        {
            FillDGvIncidente();
        }

        private void FillDGvIncidente() //Metodo para llenar el DGV con el metodo GetAll
        {
            //dgvIncidente.DataSource = incidenteRepository.GetAll().Select(x => new { x.Titulo, x.UsuarioReportaId, x.UsuarioAsignadoId, x.Prioridad, x.Departamento, x.Descripcion }).ToList();

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
                    FechaRegisto = (DateTime)item.FechaRegistro
                };

                lista2.Add(datos);
            }

            dgvIncidente.DataSource = lista2;
            #endregion

            #region ComboBox Usuarios afectados/asignados
            //Llenar comboBox con los usuarios
            var listauser = usuarioRepository.GetAll();
            cbUsuariosaf.Items.Clear();
            cbUsuarioasig.Items.Clear();
            foreach (var list in listauser)
            {
                cbUsuariosaf.Items.Add(list.Nombre);
                cbUsuarioasig.Items.Add(list.Nombre);
            }
            #endregion

            #region ComboBox Prioridades
            //Llenar comboBox con las Prioridades
            var listaprio = prioridadRepository.GetAll();
            cbPrioridades.Items.Clear();
            foreach (var list in listaprio)
            {
                cbPrioridades.Items.Add(list.Nombre);
                
            }
            #endregion

            #region ComboBox Departamentos
            //Llenar comboBox con los Departamentos
            var listadep = departamentoRepository.GetAll();
            cbDepartamentos.Items.Clear();
            foreach (var list in listadep)
            {
                cbDepartamentos.Items.Add(list.Nombre);
            }
            #endregion
            #region ComboBox CreadoPor
            ////Llenar comboBox con los 
            //var listaCre = usuarioRepository.GetAll();
            //cbCreadoPor.Items.Clear();
            //foreach (var list in listaCre)
            //{
            //    cbCreadoPor.Items.Add(list.Nombre);
            //}
            #endregion
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text) || string.IsNullOrWhiteSpace(cbUsuariosaf.Text) || string.IsNullOrWhiteSpace(cbUsuarioasig.Text) || string.IsNullOrWhiteSpace(cbPrioridades.Text) || string.IsNullOrWhiteSpace(cbDepartamentos.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text) )
            {
                MessageBox.Show("Debes llenar los campos vacíos", "Campo vacio");
            }
            else
            {
                UsuarioRepository _userRepo = new UsuarioRepository();
                var listaUser = _userRepo.GetAll();
                List<int> listaIDUser = new List<int>();

                foreach (var list in listaUser)
                {
                    listaIDUser.Add(list.Id);
                }

                PrioridadRepository _prioRepo = new PrioridadRepository();
                var listaPrio = _prioRepo.GetAll();
                List<int> listaIDPrio = new List<int>();

                foreach (var list in listaPrio)
                {
                    listaIDPrio.Add(list.Id);
                }

                DepartamentoRepository _deparRepo = new DepartamentoRepository();
                var listaDep = _deparRepo.GetAll();
                List<int> listaIDDep = new List<int>();

                foreach (var list in listaDep)
                {
                    listaIDDep.Add(list.Id);
                }

                Incidente inc = new Incidente();
                IncidenteRepository incidenteRepo = new IncidenteRepository();
                inc.Titulo = txtTitulo.Text;
                inc.Descripcion = txtDescripcion.Text;
                inc.Borrado = 0;
                inc.FechaRegistro = DateTime.Now;
                inc.FechaModificacion = DateTime.Now;
                inc.Estatus = "A";
                inc.UsuarioReportaId = listaIDUser[cbUsuariosaf.SelectedIndex];
                inc.UsuarioAsignadoId = listaIDUser[cbUsuarioasig.SelectedIndex];
                inc.PrioridadId = listaIDPrio[cbPrioridades.SelectedIndex];
                inc.DepartamentoId = listaIDDep[cbDepartamentos.SelectedIndex];
                //inc.CreadoPor = listaIDUser[cbCreadoPor.SelectedIndex];
                inc.ComentarioCierre = "";
                
                incidenteRepo.Create(inc);

             
                if (inc.Titulo != "")
                {
                    MessageBox.Show("El incidente ha sido creado.");
                    FillDGvIncidente();
                    txtTitulo.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    cbUsuariosaf.Text = string.Empty;
                    cbUsuarioasig.Text = string.Empty;
                    cbPrioridades.Text = string.Empty;
                    cbDepartamentos.Text = string.Empty;
                    

                }
  
            }
        }

        private void atrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   
           


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

        private void cbUsuarioasig_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtTitulo.Text = "";
            txtDescripcion.Text ="";
            cbUsuariosaf.Text = "";
            cbUsuarioasig.Text ="";
            cbPrioridades.Text ="";
            cbDepartamentos.Text = "";

        }
    }
}
