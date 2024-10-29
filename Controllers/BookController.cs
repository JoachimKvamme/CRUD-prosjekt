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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookRequestDto bookDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();
        

            var bookModel = bookDto.ToBookFromCreate();

            await _bookRepo.CreateAsync(bookModel);
            return CreatedAtAction(nameof(GetById), new {id = bookModel.Id}, bookModel.ToBookDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookDto bookDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var bookModel = await _bookRepo.UpdateAsync(id, bookDto);

            if(bookModel == null)
                return NotFound();
            
            return Ok(bookModel.ToBookDto());
        }        

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var bookModel = await _bookRepo.DeleteAsync(id);

            if(bookModel == null)
                return NotFound();
            
            return NoContent();
        }
    }
}