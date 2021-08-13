using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Entities
{
    public class Sla : BaseEntity
    {
        public string Descripcion { get; set; }
        public int CantidadHoras { get; set; }
<<<<<<< HEAD
      //  public string Estatus { get; set; }
      //  public bool Borrado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
      //  public int CreadoPor { get; set; }
        public Usuario UsuarioId { get; set; } // =>??
      //  public int ModificadoPor { get; set; }

=======
        
        public List <Prioridad> Prioridades { get; set; }
>>>>>>> ae7169d24bf84ba7b411c2b3939a3dd2c8d794c6
    }
}
