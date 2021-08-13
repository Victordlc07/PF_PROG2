using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Entities
{
    public class HistorialIncidente : BaseEntity
    {
        public int IncidenteId { get; set; }
        public Incidente Incidente { get; set; }
        public string Comentario { get; set; }

    }
}
