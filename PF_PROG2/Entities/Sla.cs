using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Entities
{
    class Sla
    {
        public int SlaId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadHoras { get; set; }
        public string Estatus { get; set; }
        public bool Borrado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int CreadoPor { get; set; }
        public Usuario UsuarioId { get; set; } // =>??
        public int ModificadoPor { get; set; }

    }
}
