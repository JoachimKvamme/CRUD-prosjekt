using System;
using System.Collections.Generic;
using System.Drawing;
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

        [HttpPost("{id:int}")]
        public async Task<IActionResult> AddUserProject([FromBody]string? title, [FromBody] int? id, [FromRoute] int projectId)
        {
            var project = _projectRepo.GetByIdAsync(projectId);
            if(project == null)
                return NotFound("Prosjektet finnes ikke");

            if(title != null)
            {
                var book = await _bookRepo.GetByTitleAsync(title);
                if(book == null)
                    return NotFound($"Det finnes ikke en bok med tittelen {title}. Sjekk at du har skrevet tittelen riktig, og at dokumentet er lagt til.");
                var userProject = await _userProjectRepo.GetUserProjects(projectId);
                
                if(userProject.Any(e => e.Title.ToLower() == book.Title.ToLower()))
                    return BadRequest("Tittelen du prøver å legge til, er allerede forbundet med prosjektet.");

                
                
            } 
            else if (id != null)
            {
                var book = await _bookRepo.GetByIdAsync((int)id);
                if(book == null)
                    return NotFound($"Det finnes ikke en bok med IDen {id}. Sjekk at du har skrevet riktig nummmer, og at dokumentet er lagt til.");

                var userProject = await _userProjectRepo.GetUserProjects(projectId);
                
                if(userProject.Any(e => e.Title.ToLower() == book.Title.ToLower()))
                    return BadRequest("Tittelen du prøver å legge til, er allerede forbundet med prosjektet.");
                
                var userProjectModel = new UserProject
                {
                    ProjectId = project.Id,
                    BookId = book.Id
                };

                
   
            }
            else
            {
                return BadRequest("Du må skrive inn en gyldig tittel eller bokId");
            }

            
        }
    }
}