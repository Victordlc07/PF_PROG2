using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Entities
{
    class Incidente
    {
        public int IncidenteId { get; set; }
        public int UsuarioReportaId { get; set; }
        public int UsuarioAsignadoId { get; set; }
        public int PrioridadId { get; set; }
        public Prioridad Prioridades { get; set; }

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCierre { get; set; }
        public string ComentarioCiere { get; set; }
   

    
    }
}
