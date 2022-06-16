using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Context;
using Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectDto>> GetAll()
        {
            var projects = (await _context.Employees.ToListAsync()).Select(x => new ProjectDto()
            {
                Id = x.Id,
                Name = x.EmployeeName
            });

            return projects;
        }

    }
}
