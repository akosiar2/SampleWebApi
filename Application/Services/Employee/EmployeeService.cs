using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            var employees = (await _context.Employees.ToListAsync()).Select(x => new EmployeeDto()
            {
                Id = x.Id,
                Name = x.EmployeeName
            });

            return employees;
        }
    }
}
