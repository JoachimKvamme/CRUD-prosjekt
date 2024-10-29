using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRUD_prosjekt.Data
{

    // Denne klassen lar oss sende, endre og lese c#-objekter i databasen. Styres av EntityFramework.
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Project> Projects {get; set;}
        public DbSet<Book> Books {get; set;}
        public DbSet<UserProject> UserProjects {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserProject>(x => x.HasKey(u => new {u.BookId, u.ProjectId}));

     // Forteller Entity Framework hvordan Project- og Book-klassen relaterer til hverandre i UserProjects (tror jeg).
            builder.Entity<UserProject>()
                .HasOne(u => u.Project)
                .WithMany(u => u.userProjects)
                .HasForeignKey(f => f.ProjectId);

            builder.Entity<UserProject>()
                .HasOne(u => u.Book)
                .WithMany(u => u.userProjects)
                .HasForeignKey(f => f.BookId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}