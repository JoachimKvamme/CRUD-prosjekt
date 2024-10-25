using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Dto;
using CRUD_prosjekt.Dto.Project;
using CRUD_prosjekt.Models;

namespace CRUD_prosjekt.Mappers
{
    public static class ProjectMappers
    {
        public static ProjectDto ToProjectDto(this Project projectModel)
        {
            return new ProjectDto
            {
                Id = projectModel.Id,
                Title = projectModel.Title,
                Books = projectModel.Books.Select(b => b.ToBookDto()).ToList()
            };
        }

        public static Project ToProjectFromCreateDto (this CreateProjectRequestDto projectDto)
        {
            return new Project 
            {
                Title = projectDto.Title,
            };
        }
    }
}