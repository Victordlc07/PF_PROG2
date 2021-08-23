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

namespace PF_PROG2.Forms.Puestos
{
    public partial class frmPuestosCrear : Form
    {

        PuestoRepository puestoRepository = new PuestoRepository();
        DepartamentoRepository departamentoRepository = new DepartamentoRepository();
        
        public frmPuestosCrear()
        {
            InitializeComponent();
        }

        private void frmPuestosCrear_Load(object sender, EventArgs e)
        {
            FillDGvPuestos();
        }

        private void FillDGvPuestos() //Metodo para llenar el DGV con el metodo GetAll
        {
            //dgvPuestos.DataSource = puestoRepository.GetAll().Select(x => new { x.DepartamentoId, x.Nombre }).ToList();
            
            #region Acutializar_DataGridView
            var lista = puestoRepository.GetAll();
            var lista2 = new List<DatosPuesto>();

            foreach (var item in lista)
            {
                var datos = new DatosPuesto()
                {
                    Id = item.Id,
                    Puesto = item.Nombre,
                    Departamento = departamentoRepository.FindById(item.DepartamentoId).Nombre
                };

                lista2.Add(datos);
            }
            dgvPuestos.DataSource = lista2;
            #endregion

            #region ComboBox Departamento

            var listadep = departamentoRepository.GetAll();
            List<int> listaIDDepar = new List<int>();
            cbDepartamentos.Items.Clear();
            foreach (var list in listadep)
            {
                cbDepartamentos.Items.Add(list.Nombre);
                listaIDDepar.Add(list.Id);
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
                DepartamentoRepository _departamentoRepo = new DepartamentoRepository();
                var listaDepa = _departamentoRepo.GetAll();
                List<int> listaIDDepar = new List<int>();

                foreach (var list in listaDepa)
                {
                    listaIDDepar.Add(list.Id);
                }

                Puesto pues = new Puesto();
                pues.Nombre = txtNombreDpt.Text;
                pues.Borrado = 0;
                pues.FechaRegistro = DateTime.Now;
                pues.Estatus = "A";
                pues.DepartamentoId = listaIDDepar[cbDepartamentos.SelectedIndex];
                puestoRepository.Create(pues);

                if (pues.Nombre != "")
                {
                    MessageBox.Show("El departamento ha sido creado");
                    FillDGvPuestos();
                    txtNombreDpt.Text = string.Empty;
                    cbDepartamentos.Text = string.Empty;
                }
                
            }
        }

        private void atrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void cbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //Clase DatosPuesto para que solo salgan las propiedades listadas aqui en el DataGridView
        private class DatosPuesto
        {
            public int Id { get; set; }
            public string Puesto { get; set; }
            public string Departamento { get; set; }
        }

    }
}
