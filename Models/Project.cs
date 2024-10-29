using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_prosjekt.Models
{
    [Table("Projects")]
    public class Project
    {
        public int Id {get; set;}
        public string Title {get; set;} = string.Empty;
        //public string AppUserId {get; set; } = string.Empty;
       // public AppUser AppUser {get; set;} 
        public List<UserProject> userProjects = new List<UserProject>();
    }
}