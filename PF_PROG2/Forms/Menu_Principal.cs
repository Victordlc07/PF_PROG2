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
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void FillDGvIncidentes()
        {
            dGvincidentes.DataSource = incidenteRepository.GetAll();
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
            //dGvincidentes.DataSource = incidenteRepository.GetAll();
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
    }
}
