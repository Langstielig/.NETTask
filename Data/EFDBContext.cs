using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EFDBContext : DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*modelBuilder.Entity<Project>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Projects);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Projects)
                .WithMany(e => e.Users);*/
        }

    }

    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var oprionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            oprionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("Data"));

            return new EFDBContext(oprionsBuilder.Options);
        }
    }
}
