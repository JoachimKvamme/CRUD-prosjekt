using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_prosjekt.Dto.Book
{
    public class UpdateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string FirstNameAuthor {get; set;} = string.Empty;
        public string LastNameAuthor {get; set;} = string.Empty;
        public int Year {get; set;}
        public string Publisher {get; set;} = string.Empty;
        public string Place { get; set; } = string.Empty;

    }
}