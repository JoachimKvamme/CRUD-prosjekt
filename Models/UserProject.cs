using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_prosjekt.Models
{

    // Denne klassen fungerer som et join-table mellom Book-objekter og Project-objekter, sånn at man kan ha flere 
    // kombinasjoner av bøker og prosjekter.
    public class UserProject
    {
        public int BookId { get; set; }
        public int ProjectId {get; set;}
        public Book Book {get; set;}
        public Project Project {get; set;}
    }
}