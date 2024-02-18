using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InfraData.Context
{
    public class ConnectionContext: DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options): base(options) { }
        
        // crear DBsets
        public DbSet<Success> Success { get; set; }
        public DbSet<LocalidadDevolucion> LocalidadDevolucion { get; set; }
        public DbSet<LocalidadRecogida> LocalidadRecogida { get; set; }
        public DbSet<TipoVehiculo> TipoVehiculo { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }  
        public DbSet<Disponibilidad> VehiculosDisponibles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Success>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<LocalidadDevolucion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Devolucion).IsRequired();
                entity.HasIndex(e => e.Devolucion).IsUnique();
            });
            modelBuilder.Entity<LocalidadRecogida>(entity =>
            {
                entity.HasKey(e => e.Id);              
                entity.Property(e => e.Recogida).IsRequired();
                entity.HasIndex(e => e.Recogida).IsUnique();
            });
   
            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Tipo).IsRequired();
                entity.HasIndex(e => e.Tipo).IsUnique();
            });
            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<Disponibilidad>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
