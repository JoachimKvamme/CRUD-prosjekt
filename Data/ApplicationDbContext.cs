using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Models;
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
    }
}