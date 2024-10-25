using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_prosjekt.Dto.Book
{
    public class CreateBookRequestDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string FirstNameAuthor {get; set;} = string.Empty;
        [Required]
        public string LastNameAuthor {get; set;} = string.Empty;
        [Required]
        public int Year {get; set;}
        [Required]
        public string Place { get; set; } = string.Empty;
   
    }
}