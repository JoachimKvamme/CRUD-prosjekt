using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Data;
using CRUD_prosjekt.Dto;
using CRUD_prosjekt.Dto.Project;
using CRUD_prosjekt.Interfaces;
using CRUD_prosjekt.Mappers;
using CRUD_prosjekt.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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

        [HttpGet("/booklist/{id:int}")]
        public async Task<IActionResult> GetFormattedBookList([FromRoute] int id)
        {
            List<string> formattedBookList = [];
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookList = await _projectRepo.GetBookListById(id);

            if(bookList == null)
                return NotFound();

            List<Book> sortedBookList = bookList.OrderBy(b => b.LastNameAuthor).ToList();
            foreach (var book in sortedBookList)
            {
                string formattedBook = $"{book.LastNameAuthor}, {book.FirstNameAuthor[0]}. ({book.Year}) {book.Title}. {book.Place}: {book.Publisher}.";
                formattedBookList.Add(formattedBook);
            }

            return Ok(formattedBookList);

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

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProjectDto updateDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            
            var projectModel = await _projectRepo.UpdateAsync(id, updateDto);

            if(projectModel == null)
                return NotFound();
            
            return Ok(projectModel);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            
            var projectModel = await _projectRepo.DeleteAsync(id);

            if(projectModel == null)
                return NotFound();
            
            return NoContent();
        }
    }
}