using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Entities
{
    public class Incidente : BaseEntity
    { 
        public int UsuarioReportaId { get; set; }
        public int UsuarioAsignadoId { get; set; }
        public int PrioridadId { get; set; }
        public Prioridad Prioridad { get; set; }
        public Usuario Usuario { get; set; } 
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaCierre { get; set; }
        public string ComentarioCierre { get; set; }
   
        public List <HistorialIncidente> historialIncidentes { get; set; }
    
    }
}
