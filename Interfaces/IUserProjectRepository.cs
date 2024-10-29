using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Models;

namespace CRUD_prosjekt.Interfaces
{
    public interface IUserProjectRepository
    {
        Task<List<Book>> GetUserProjects(int id);
        Task<List<UserProject>> GetAllProjects();
    }
}