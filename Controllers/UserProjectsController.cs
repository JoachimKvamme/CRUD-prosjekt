using System;
using System.Collections.Generic;
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

        [HttpGet("id:int")]
        //[Authorize]
        public async Task<IActionResult> GetUserProject([FromRoute] int id)
        {

            //var project = await _projectRepo.GetByIdAsync(id);
            var userProjects = await _userProjectRepo.GetUserProjects(id);
            return Ok(userProjects);
        }

    }
}