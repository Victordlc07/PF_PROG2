using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Entities
{
    public class Prioridad : BaseEntity
    {
        public int SlaId { get; set; }
        public Sla Sla { get; set; }
        public string Nombre { get; set; }
       
        public List <Incidente> Incidentes { get; set; }
    }
}
