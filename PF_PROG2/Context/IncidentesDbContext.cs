using PF_PROG2.Entities;
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

        //propiedades dbset, para indicar que esta seran las tablas a crear en la base de datos.
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sla> SLAs { get; set; }
        public DbSet<Prioridad> Prioridades { get; set; }
        public DbSet<Incidente> Incidentes { get; set; }
        public DbSet<HistorialIncidente> historialIncidentes { get; set; }

        //Fluent-API de las entidades.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Fluent API de la entidad departamento.
            #region Departamento

            modelBuilder.Entity<Departamento>().ToTable("Departamento").HasKey(k => k.ID);
            modelBuilder.Entity<Departamento>().Property(p => p.ID).HasColumnName("DepartamentoID");
            modelBuilder.Entity<Departamento>().Property(P => P.Nombre).HasMaxLength(100).HasColumnType("varchar").IsRequired();

            //Comunes
            modelBuilder.Entity<Departamento>().Property(P => P.Estatus).HasMaxLength(2).HasColumnType("varchar").IsOptional();
            modelBuilder.Entity<Departamento>().Property(P => P.Borrado).HasColumnType("int").IsOptional();
            modelBuilder.Entity<Departamento>().Property(P => P.FechaRegistro).HasColumnType("DateTime").IsOptional();
            modelBuilder.Entity<Departamento>().Property(P => P.FechaModificacion).HasColumnType("DateTime").IsOptional();
            modelBuilder.Entity<Departamento>().Property(P => P.CreadoPor).HasColumnType("int").IsOptional();
            modelBuilder.Entity<Departamento>().Property(P => P.ModificadoPor).HasColumnType("int").IsOptional();

            #endregion

            //Fluent API de la entidad Puesto
            #region Puesto

            modelBuilder.Entity<Puesto>().ToTable("Puesto").HasKey(k => k.ID);
            modelBuilder.Entity<Puesto>().Property(p => p.ID).HasColumnName("PuestoID");
            modelBuilder.Entity<Puesto>().Property(P => P.DepartamentoId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Puesto>().Property(P => P.Nombre).HasMaxLength(100).HasColumnType("varchar").IsRequired();

            //Comunes
            modelBuilder.Entity<Puesto>().Property(P => P.Estatus).HasMaxLength(2).HasColumnType("varchar");
            modelBuilder.Entity<Puesto>().Property(P => P.Borrado).HasColumnType("int");
            modelBuilder.Entity<Puesto>().Property(P => P.FechaRegistro).HasColumnType("DateTime");
            modelBuilder.Entity<Puesto>().Property(P => P.FechaModificacion).HasColumnType("DateTime");
            modelBuilder.Entity<Puesto>().Property(P => P.CreadoPor).HasColumnType("int");
            modelBuilder.Entity<Puesto>().Property(P => P.ModificadoPor).HasColumnType("int");

            #endregion

            //Fluent API de la entidad Usuario
            #region Usuario

            modelBuilder.Entity<Usuario>().ToTable("Usuario").HasKey(k => k.ID);
            modelBuilder.Entity<Usuario>().Property(p => p.ID).HasColumnName("UsuarioID");
            modelBuilder.Entity<Usuario>().Property(P => P.PuestoId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Usuario>().Property(P => P.Nombre).HasMaxLength(100).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Usuario>().Property(P => P.Apellido).HasMaxLength(100).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Usuario>().Property(P => P.Cedula).HasMaxLength(11).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Usuario>().Property(P => P.Correo).HasMaxLength(50).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Usuario>().Property(P => P.Telefono).HasMaxLength(15).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Usuario>().Property(P => P.FechaNacimiento).HasColumnType("DateTime").IsRequired();
            modelBuilder.Entity<Usuario>().Property(P => P.NombreUsuario).HasMaxLength(100).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Usuario>().Property(P => P.Contrasena).HasMaxLength(500).HasColumnType("varchar").IsRequired();

            //Comunes
            modelBuilder.Entity<Usuario>().Property(P => P.Estatus).HasMaxLength(2).HasColumnType("varchar");
            modelBuilder.Entity<Usuario>().Property(P => P.Borrado).HasColumnType("int");
            modelBuilder.Entity<Usuario>().Property(P => P.FechaRegistro).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(P => P.FechaModificacion).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(P => P.CreadoPor).HasColumnType("int");
            modelBuilder.Entity<Usuario>().Property(P => P.ModificadoPor).HasColumnType("int");

            #endregion

            //Fluent API de la entidad SLA
            #region SLA

            modelBuilder.Entity<Sla>().ToTable("SLA").HasKey(k => k.ID);
            modelBuilder.Entity<Sla>().Property(p => p.ID).HasColumnName("SLAID");
            modelBuilder.Entity<Sla>().Property(P => P.Descripcion).HasMaxLength(200).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Sla>().Property(P => P.CantidadHoras).HasColumnType("int").IsRequired();

            //Comunes
            modelBuilder.Entity<Sla>().Property(P => P.Estatus).HasMaxLength(2).HasColumnType("varchar");
            modelBuilder.Entity<Sla>().Property(P => P.Borrado).HasColumnType("int");
            modelBuilder.Entity<Sla>().Property(P => P.FechaRegistro).HasColumnType("DateTime");
            modelBuilder.Entity<Sla>().Property(P => P.FechaModificacion).HasColumnType("DateTime");
            modelBuilder.Entity<Sla>().Property(P => P.CreadoPor).HasColumnType("int");
            modelBuilder.Entity<Sla>().Property(P => P.ModificadoPor).HasColumnType("int");

            #endregion

            //Fluent API de la entidad Prioridad
            #region Prioridad

            modelBuilder.Entity<Prioridad>().ToTable("Prioridad").HasKey(k => k.ID);
            modelBuilder.Entity<Prioridad>().Property(p => p.ID).HasColumnName("PrioridadID");
            modelBuilder.Entity<Prioridad>().Property(P => P.SlaId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Prioridad>().Property(P => P.Nombre).HasMaxLength(50).HasColumnType("varchar").IsRequired();

            //Comunes
            modelBuilder.Entity<Prioridad>().Property(P => P.Estatus).HasMaxLength(2).HasColumnType("varchar");
            modelBuilder.Entity<Prioridad>().Property(P => P.Borrado).HasColumnType("int");
            modelBuilder.Entity<Prioridad>().Property(P => P.FechaRegistro).HasColumnType("DateTime");
            modelBuilder.Entity<Prioridad>().Property(P => P.FechaModificacion).HasColumnType("DateTime");
            modelBuilder.Entity<Prioridad>().Property(P => P.CreadoPor).HasColumnType("int");
            modelBuilder.Entity<Prioridad>().Property(P => P.ModificadoPor).HasColumnType("int");

            #endregion

            //Fluent API de la entidad Incidente
            #region Incidente

            modelBuilder.Entity<Incidente>().ToTable("Incidente").HasKey(k => k.ID);
            modelBuilder.Entity<Incidente>().Property(p => p.ID).HasColumnName("IncidenteID");
            modelBuilder.Entity<Incidente>().Property(P => P.UsuarioReportaId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Incidente>().Property(P => P.UsuarioAsignadoId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Incidente>().Property(P => P.PrioridadId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Incidente>().Property(P => P.DepartamentoId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Incidente>().Property(P => P.Titulo).HasMaxLength(200).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Incidente>().Property(P => P.Descripcion).HasMaxLength(500).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Incidente>().Property(P => P.FechaCierre).HasColumnType("DateTime").IsOptional();
            modelBuilder.Entity<Incidente>().Property(P => P.ComentarioCierre).HasMaxLength(500).HasColumnType("varchar").IsOptional();

            //Comunes
            modelBuilder.Entity<Incidente>().Property(P => P.Estatus).HasMaxLength(2).HasColumnType("varchar");
            modelBuilder.Entity<Incidente>().Property(P => P.Borrado).HasColumnType("int");
            modelBuilder.Entity<Incidente>().Property(P => P.FechaRegistro).HasColumnType("DateTime");
            modelBuilder.Entity<Incidente>().Property(P => P.FechaModificacion).HasColumnType("DateTime");
            modelBuilder.Entity<Incidente>().Property(P => P.CreadoPor).HasColumnType("int");
            modelBuilder.Entity<Incidente>().Property(P => P.ModificadoPor).HasColumnType("int");

            #endregion

            //Fluent API de la entidad HistorialIncidente
            #region HistorialIncidente

            modelBuilder.Entity<HistorialIncidente>().ToTable("HistorialIncidente").HasKey(k => k.ID);
            modelBuilder.Entity<HistorialIncidente>().Property(p => p.ID).HasColumnName("HistorialIncidenteID");
            modelBuilder.Entity<HistorialIncidente>().Property(P => P.IncidenteId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<HistorialIncidente>().Property(P => P.Comentario).HasMaxLength(500).HasColumnType("varchar").IsRequired();

            //Comunes
            modelBuilder.Entity<HistorialIncidente>().Property(P => P.Estatus).HasMaxLength(2).HasColumnType("varchar");
            modelBuilder.Entity<HistorialIncidente>().Property(P => P.Borrado).HasColumnType("int");
            modelBuilder.Entity<HistorialIncidente>().Property(P => P.FechaRegistro).HasColumnType("DateTime");
            modelBuilder.Entity<HistorialIncidente>().Property(P => P.FechaModificacion).HasColumnType("DateTime");
            modelBuilder.Entity<HistorialIncidente>().Property(P => P.CreadoPor).HasColumnType("int");
            modelBuilder.Entity<HistorialIncidente>().Property(P => P.ModificadoPor).HasColumnType("int");

            #endregion
        }
    }
}
