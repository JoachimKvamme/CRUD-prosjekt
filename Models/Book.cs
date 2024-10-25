using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_prosjekt.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FirstNameAuthor {get; set;} = string.Empty;
        public string LastNameAuthor {get; set;} = string.Empty;
        public int? ProjectId {get; set;}
        public Project? Project {get; set;}
    }
}