using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Extensions;
using CRUD_prosjekt.Interfaces;
using CRUD_prosjekt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_prosjekt.Controllers
{
    [Route("api/userprojects")]
    [ApiController]
    public class UserProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepo;
        private readonly IBookRepository _bookRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserProjectRepository _userProjectRepo;
        public UserProjectsController( UserManager<AppUser> userManager,
        IProjectRepository projectRepo, IBookRepository bookRepo, IUserProjectRepository userProjectRepo)
        {
            _projectRepo = projectRepo;
            _bookRepo = bookRepo;
            _userManager = userManager;
            _userProjectRepo = userProjectRepo;
        }

        [HttpGet("{id:int}")]
        //[Authorize]
        public async Task<IActionResult> GetUserProject([FromRoute] int id)
        {

            //var project = await _projectRepo.GetByIdAsync(id);
            var userProjects = await _userProjectRepo.GetUserProjects(id);
            return Ok(userProjects);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserProjects()
        {
            var userProjects = await _userProjectRepo.GetAllProjects();
            return Ok(userProjects);
        }

        [HttpPost("{projectId:int}")]
        public async Task<IActionResult> AddUserProject([FromBody] int id, [FromRoute] int projectId)
        {
            var project = _projectRepo.GetByIdAsync(projectId);
            if(project == null)
                return NotFound("Prosjektet finnes ikke");


            var book = await _bookRepo.GetByIdAsync(id);
            if(book == null)
                    return NotFound($"Det finnes ikke en bok med IDen {id}. Sjekk at du har skrevet riktig nummmer, og at dokumentet er lagt til.");

                var userProject = await _userProjectRepo.GetUserProjects(projectId);
                
                if(userProject.Any(e => e.Title.ToLower() == book.Title.ToLower()))
                    return BadRequest("Tittelen du prøver å legge til, er allerede forbundet med prosjektet.");
                
                var userProjectModel = new UserProject
                {
                    ProjectId = projectId,
                    BookId = book.Id
                };

                await _userProjectRepo.CreateAsync(userProjectModel);

                if(userProjectModel == null)
                {
                    return StatusCode(500, "Could not create.");
                }
                else
                {
                    return Created();
                }
   
            }

            [HttpDelete("{projectId:int}")]
            public async Task<IActionResult> DeleteUserProject([FromRoute] int projectId, [FromBody] int bookId)
            {
                var userProject = await _userProjectRepo.GetUserProjects(projectId);

                var filteredUserProject = userProject.Where(b => b.Id == bookId).ToList();

                if(filteredUserProject.Count() > 0)
                {
                    await _userProjectRepo.DeleteUserProject(projectId, bookId);
                } 
                else
                {
                    return BadRequest("Tittelen finnes ikke i prosjektet");
                }

                return Ok();
            }
            
        }
    }