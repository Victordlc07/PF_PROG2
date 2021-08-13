using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Entities
{
    public class Usuario : BaseEntity
    {

        public int PuestoId { get; set; }
        public Puesto Puesto { get; set; }
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }

        public List <Incidente> Incidentes { get; set; }
        public List <HistorialIncidente> historialIncidentes { get; set; }
        public List <Prioridad> Prioridades { get; set; }


    }
}
