using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Entities
{
    public class Puesto
    {
        public int PuestoId { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamentos { get; set; }

        public string Nombre { get; set; }
        public string Estatus { get; set; }
        public bool Borrado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int CreadoPor { get; set; }
        public Usuario UsuarioCreadoPor { get; set; } //ojo
        public int ModificadoPor { get; set; }
        public Usuario UsuarioModificadoPor { get; set; } //ojo

        public List<Usuario> Usuarios { get; set; }
}
}
