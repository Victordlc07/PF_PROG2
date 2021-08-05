using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Entities
{
    class HistorialIncidente
    {
        public int HistorialIncidenteID { get; set; }
        public int IncidenteId { get; set; }
        public Incidente Incidentes { get; set; }

        public string Comentario { get; set; }
        public string Estatus { get; set; }
        public bool Borrado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int CreadoPor { get; set; }
        public int ModificadoPor { get; set; }
    }
}
