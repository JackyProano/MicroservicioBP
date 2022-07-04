using Microsoft.EntityFrameworkCore;
using Rest.Microservicio.Model.Entidades;
using System;

namespace Rest.Microservicio.DataAccess
{
    public partial class BaseDatosBPContext : DbContext
    {
        public BaseDatosBPContext(DbContextOptions<BaseDatosBPContext> options) : base(options)
        {
        }
        
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<Movimiento> Movimiento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
    }
}
