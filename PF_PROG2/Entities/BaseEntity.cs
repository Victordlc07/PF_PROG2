using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Entities
{
    public class BaseEntity //Esta es la clase COMUN que tiene las propiedades comunes de todas las entidades.
    {
       public int Id { get; set; }
        public string Estatus { get; set; }
        public int Borrado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? CreadoPor { get; set; }
        public int? ModificadoPor { get; set; }
    }

}
