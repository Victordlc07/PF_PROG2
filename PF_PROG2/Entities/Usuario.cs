﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Entities
{
    class Usuario
    {
        public int UsuarioId { get; set; }

        public int PuestoId { get; set; }
        public Puesto Puestos { get; set; }
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NombreUsuario { get; set; }
        public string Constasena { get; set; }
        public string Estatus { get; set; }
        public bool Borrado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int CreadoPor { get; set; }
        public int ModificadoPor { get; set; }

        

    }
}