using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_PROG2.Context
{
    class IncidentesDbContext:DbContext
    {
        public IncidentesDbContext()
            :base ("MsSQL")

        { 
        }

        public DbSet Departamento { get; set; }
        public DbSet Puesto { get; set; }
        public DbSet UsuarioId { get; set; }
        public DbSet Sla { get; set; }
        public DbSet Prioridad { get; set; }
        public DbSet Incidente { get; set; }
        public DbSet HistorialIncidente { get; set; }
    }
}
