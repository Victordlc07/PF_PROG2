using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Entities
{
    public class Departamento : BaseEntity
    {
        //Propiedad unica de esta entidad
        public string Nombre { get; set; }
        
        //Relacion con otras entidades
        public List<Puesto> Puestos { get; set; }          //Relacion de uno a muchos.
        public List<Incidente> Incidentes { get; set; }
    }
}
