using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_prosjekt.Dto.Project
{
    public class UpdateProjectDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Tittelen må inneholde minst ett tegn.")]
        public string Title { get; set; } = string.Empty;
    }
}