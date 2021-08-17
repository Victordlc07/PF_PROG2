using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Entities
{
    public class Puesto : BaseEntity
    {
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public string Nombre { get; set; }

        public List<Usuario> Usuarios { get; set; }

        
    }
}
