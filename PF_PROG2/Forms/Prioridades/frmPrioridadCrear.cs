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

namespace PF_PROG2.Forms.Prioridades
{
    public partial class frmPrioridadesCrear : Form
    {
        PrioridadRepository prioridadRepository = new PrioridadRepository();
        SLARepository slaRepository = new SLARepository();
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        
        public frmPrioridadesCrear()
        {
            InitializeComponent();
        }

        private void frmPrioridadesCrear_Load(object sender, EventArgs e)
        {
            FillDGvPrioridades();
        }

        private void FillDGvPrioridades() //Metodo para llenar el DGV con el metodo GetAll
        {
            //dgvPrioridades.DataSource = prioridadRepository.GetAll().Select(x => new { x.Nombre }).ToList();
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

            #region ComboBox SLA
            //Llenar comboBox con los SLAs
            var listasla = slaRepository.GetAll();
            List<int> listaIDSla = new List<int>();
            cbSlas.Items.Clear();
            foreach (var list in listasla)
            {
                cbSlas.Items.Add(list.Descripcion);
                listaIDSla.Add(list.Id);
            }
            #endregion
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreDpt.Text))
            {
                MessageBox.Show("Debes llenar los campos nombre", "Campo vacio");
            }
            else
            {
                SLARepository _slaRepo = new SLARepository();
                var listaSLA = _slaRepo.GetAll();
                List<int> listaIDSla = new List<int>();

                foreach (var list in listaSLA)
                {
                    listaIDSla.Add(list.Id);
                }

                Prioridad prio = new Prioridad();
                Login login = new Login();
                prio.Nombre = txtNombreDpt.Text;
                prio.Borrado = 0;
                prio.FechaRegistro = DateTime.Now;
                prio.Estatus = "A";
                prio.SlaId = listaIDSla[cbSlas.SelectedIndex];
                //prio.CreadoPor = usuarioRepository.GetAll().Where(x => new { x.NombreUsuario == login.logueado }); //login.logueado;
                prioridadRepository.Create(prio);

                //Tratar de vincular la clase Prioridad con OperationResult
                // OperationResult resultupdt = prioridadRepository.Create(prio);
                if (prio.Nombre != "")
                {
                    MessageBox.Show("La prioridad ha sido creada.");
                    FillDGvPrioridades();
                    txtNombreDpt.Text = string.Empty;
                    cbSlas.Text = string.Empty;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreDpt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbSlas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //Clase DatosPuesto para que solo salgan las propiedades listadas aqui en el DataGridView
        private class DatosPrioridad
        {
            public int Id { get; set; }
            public string Prioridad { get; set; }
            public string SLA { get; set; }
            public int SLA_Hrs { get; set; }
        }
    }
}
