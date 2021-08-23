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
    public partial class frmSLACrear : Form
    {
        
        public frmSLACrear()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCantidadhrs.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Favor llenar el campo Nombre", "Campo vacio");
            }
            else
            {
                SLARepository _slaRepo = new SLARepository(); //objeto de tipo slartamentoRepository

                Sla sla = new Sla();
                sla.CantidadHoras = Convert.ToInt32(txtCantidadhrs.Text);
                sla.Descripcion = txtDescripcion.Text;
                sla.Borrado = 0;
                sla.FechaRegistro = DateTime.Now;
                sla.Estatus = "A";

                _slaRepo.Create(sla); //Enviamos el sla al metodo crear del slaRepository

                if (sla.Descripcion != "")
                {
                    MessageBox.Show("El SLA ha sido creado.");
                    txtCantidadhrs.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la actualizacion, comunicarse con el Administrador de TI.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//Botón Cancelar
        {
            txtCantidadhrs.Text = "";
            txtDescripcion.Text = "";
        }

        private void regresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        
    }
}
