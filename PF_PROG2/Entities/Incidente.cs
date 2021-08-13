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
<<<<<<< HEAD
        public Prioridad Prioridades { get; set; }
=======
        public Prioridad Prioridad { get; set; }
        public Usuario Usuario { get; set; } 
>>>>>>> ae7169d24bf84ba7b411c2b3939a3dd2c8d794c6
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCierre { get; set; }
        public string ComentarioCierre { get; set; }
   
        public List <HistorialIncidente> historialIncidentes { get; set; }
    
    }
}
