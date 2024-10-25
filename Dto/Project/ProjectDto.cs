using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Dto.Book;

namespace CRUD_prosjekt.Dto.Project
{
    public class ProjectDto
    {
        public int Id {get; set;}
        public string Title {get; set;} = string.Empty;
        public List<BookDto> Books {get; set;}
    }
}