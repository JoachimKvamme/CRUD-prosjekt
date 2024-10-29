using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_prosjekt.Models
{
    public class Project
    {
        public int Id {get; set;}
        public string Title {get; set;} = string.Empty;
        public string AppUserId {get; set; }
        public AppUser AppUser {get; set;} 
        public List<UserProject> userProjects = new List<UserProject>();
    }
}