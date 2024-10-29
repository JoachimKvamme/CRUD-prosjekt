using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_prosjekt.Models
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FirstNameAuthor {get; set;} = string.Empty;
        public string LastNameAuthor {get; set;} = string.Empty;
        public int Year {get; set;}
        public string Publisher {get; set;} = string.Empty;
        public string Place { get; set; } = string.Empty;
        public List<UserProject> userProjects = new List<UserProject>();

    }
}