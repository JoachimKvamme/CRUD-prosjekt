using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Data;
using CRUD_prosjekt.Dto;
using CRUD_prosjekt.Interfaces;
using CRUD_prosjekt.Mappers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;


namespace CRUD_prosjekt.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IProjectRepository _projectRepo;
        public ProjectController(ApplicationDbContext context, IProjectRepository projectRepo)
        {
            _context = context;
            _projectRepo = projectRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var projects = await _projectRepo.GetAllAsync();
            return Ok(projects);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var project = await _projectRepo.GetByIdAsync(id);

            if(project == null) return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectRequestDto projectDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var projectModel = projectDto.ToProjectFromCreateDto();

            await _projectRepo.CreateAsync(projectModel);

            return CreatedAtAction(nameof(GetById), new {id = projectModel.Id}, projectModel.ToProjectDto());
        }
    }
}