using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;

namespace Application.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAll();
    }
}
