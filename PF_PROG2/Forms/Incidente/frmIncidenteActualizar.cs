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
    public partial class frmIncidenteActualizar : Form
    {
        IncidenteRepository incidenteRepository = new IncidenteRepository();
        HistorialIncidente histo = new HistorialIncidente();
        HistorialIncidenteRepository historialincidenteRepo = new HistorialIncidenteRepository();
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();
        PrioridadRepository prioridadRepository = new PrioridadRepository();

        public frmIncidenteActualizar()
        {
            InitializeComponent();
        }

        private void FillDGvIncidente() //Metodo para llenar el DGV con el metodo GetAll
        {

            UsuarioRepository _userRepo = new UsuarioRepository();
            var listaUser = _userRepo.GetAll();
            List<int> listaIDUser = new List<int>();

            foreach (var list in listaUser)
            {
                listaIDUser.Add(list.Id);
            }
      
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
           

            dgvIncidentes.DataSource = lista2;
            #endregion

        }

        private void frmIncidenteActualizar_Load(object sender, EventArgs e)
        {
            FillDGvIncidente();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtComentario.Text))
            {
                MessageBox.Show("Debes introducir un comentario", "Comentario vacio");
            }
            else
            {
                #region ComboBox Modificado 
                ////Llenar comboBox con los Departamentos
                //var listaMo = usuarioRepository.GetAll();
                //cbModificado.Items.Clear();
                //foreach (var list in listaMo)
                //{
                //    cbModificado.Items.Add(list.Nombre);
                //}
                #endregion


                histo.Comentario = txtComentario.Text;
                histo.IncidenteId = Convert.ToInt32(dgvIncidentes.CurrentRow.Cells["ID"].Value);
                histo.Borrado = 0;
                histo.FechaRegistro = DateTime.Now;
                histo.Estatus = "A";
                //histo.ModificadoPor = Convert.ToInt32(listaMo[cbModificado.SelectedIndex]);
                historialincidenteRepo.Create(histo);
               

                //Actualizar fecha de modificacion de la entidad incidentes   
                var actualizarIncidente = incidenteRepository.FindById(Convert.ToInt32(dgvIncidentes.CurrentRow.Cells["ID"].Value));
                actualizarIncidente.FechaModificacion = DateTime.Now;
                incidenteRepository.Update(actualizarIncidente); //Actualizamos la fecha de modificacion del incidente al que se le agrego el comentario

                if (histo.Comentario != "")
                {
                    MessageBox.Show("El comentario ha sido insertado");
                    FillDGvIncidente();
                    txtComentario.Text = string.Empty;
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
            public int? CreadoPor { get; set; }
            public int? ModificadoPor { get; set; }
            public int UsuarioId { get; set; }


        }
    }
}
