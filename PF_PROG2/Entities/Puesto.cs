using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Entities
{
    public class Puesto : BaseEntity
    {
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public string Nombre { get; set; }
<<<<<<< HEAD
     //   public string Estatus { get; set; }
    //    public bool Borrado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
    //    public int CreadoPor { get; set; }
        public Usuario UsuarioCreadoPor { get; set; } //ojo
    //    public int ModificadoPor { get; set; }
        public Usuario UsuarioModificadoPor { get; set; } //ojo
=======
>>>>>>> ae7169d24bf84ba7b411c2b3939a3dd2c8d794c6

        public List<Usuario> Usuarios { get; set; }
}
}
