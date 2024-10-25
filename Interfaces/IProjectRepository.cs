using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Models;

namespace CRUD_prosjekt.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync();
        Task<Project> CreateAsync();
        Task<Project?> UpdateAsync(int id, Project projectDto);
        Task<Project?> DeleteAsync(int id);

    }
}