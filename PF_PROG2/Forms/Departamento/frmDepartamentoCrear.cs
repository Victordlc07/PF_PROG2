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
    public partial class frmDepartamentoCrear : Form
    {
        public frmDepartamentoCrear()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreDtp.Text))
            {
                MessageBox.Show("Favor llenar el campo Nombre", "Campo vacio");
            }
            else
            {
                DepartamentoRepository _departamentoRepo = new DepartamentoRepository(); //objeto de tipo departamentoRepository

                Departamento depa = new Departamento();
                depa.Nombre = txtNombreDtp.Text;
                depa.Borrado = 0;
                depa.FechaRegistro = DateTime.Now;
                depa.Estatus = "A";

                _departamentoRepo.Create(depa); //Enviamos el modelo al metodo crear del departamentoRepository

                if (depa.Nombre != "")
                {
                    MessageBox.Show("El departamento Fue Agregado", "Departamento");
                    txtNombreDtp.Clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//Botón Cancelar
        {
            txtNombreDtp.Text = "";

        }

        private void regresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombreDtp_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmDepartamentoCrear_Load(object sender, EventArgs e)
        {

        }
    }
}
