using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Entities
{
    public class Sla : BaseEntity
    {
        public string Descripcion { get; set; }
        public int CantidadHoras { get; set; }
        
        public List <Prioridad> Prioridades { get; set; }
    }
}
