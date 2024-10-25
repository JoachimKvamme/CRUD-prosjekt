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
        public List<Book> Books {get; set;} = new List<Book>();
    }
}