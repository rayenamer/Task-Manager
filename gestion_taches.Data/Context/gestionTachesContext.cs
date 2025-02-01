using gestion_taches.Domain.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace gestion_taches.Data.Context
{
    public class gestionTachesContext : DbContext
    {
        public gestionTachesContext(DbContextOptions<gestionTachesContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Project { get; set; }
        public DbSet<Ressources> Ressources { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>()
                .HasKey(b => b.IdProject);

            modelBuilder.Entity<Ressources>()
                .HasKey(b => b.IdRessources);
            
            modelBuilder.Entity<Ressources>()
                .HasOne(b => b.Project)
                .WithMany(b => b.Ressources)
                .HasForeignKey(b => b.IdProject);
            
            /*modelBuilder.Entity<Personnes>()
                .HasOne(b => b.Project)
                .WithMany(b => b.Personnes)
                .HasForeignKey(b => b.IdP);*/


        }
    }
}
