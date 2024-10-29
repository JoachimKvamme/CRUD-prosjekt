using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CRUD_prosjekt.Models
{
    public class AppUser : IdentityUser
    {
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}