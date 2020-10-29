using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persist.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persist
{
    public class EFDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Regisseur> Regisseurs { get; set; }
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>().HasOne(u => u.User).WithMany();
            modelBuilder.Entity<Film>().HasOne(u => u.Regisseur).WithMany();
        }
    }
    

}
