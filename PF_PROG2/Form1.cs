using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PF_PROG2.Repository;

namespace PF_PROG2
{
    public partial class Form1 : Form

        
    {
        GenericRepository _dbcontext = new GenericRepository();
       
        public Form1()
        {
           // _dbcontext.Create(new t)

            InitializeComponent();
        }
    }
}
