using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Dto.Book;
using CRUD_prosjekt.Interfaces;
using CRUD_prosjekt.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;

namespace CRUD_prosjekt.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;
        private readonly IProjectRepository _projectRepo;
        public BookController(IBookRepository bookRepo, IProjectRepository projectRepo)
        {
            _bookRepo = bookRepo;
            _projectRepo = projectRepo;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var books = await _bookRepo.GetAllAsync();
            var bookDto = books.Select(s => s.ToBookDto());

            return Ok(bookDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var book = await _bookRepo.GetByIdAsync(id);

            if(book == null)
                return NotFound();

            return Ok(book.ToBookDto());
        }

        [HttpPost("{projectId:int}")]
        public async Task<IActionResult> Create([FromRoute] int projectId, [FromBody] CreateBookRequestDto bookDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            
            if(!await _projectRepo.ProjectExists(projectId))
                return BadRequest("Project does not exist");

            var bookModel = bookDto.ToBookFromCreate(projectId);

            await _bookRepo.CreateAsync(bookModel);
            return CreatedAtAction(nameof(GetById), new {id = bookModel.Id}, bookModel.ToBookDto());
        }

        

    }
}