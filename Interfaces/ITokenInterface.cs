using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_prosjekt.Models;

namespace CRUD_prosjekt.Interfaces
{
    public interface ITokenInterface
    {
        string CreateToken(AppUser user);
        
    }
}