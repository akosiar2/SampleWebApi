using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class EstimateService : IEstimateService
    {
        private readonly ApplicationDbContext _context;

        public EstimateService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EstimateDto> CreateEstimate(EstimateDto estimated)
        {
            var model = new Domain.Entities.Estimate();
            model.EmployeeId = estimated.EmployeeId;
            model.TaskId = estimated.TaskId;
            model.Estimated = estimated.Estimated;

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            estimated.Id = model.Id;

            return estimated;
        }

        public async Task<IEnumerable<EmployeeEstimatesDto>> GetAllEstimate()
        {
            var estimates = _context.Estimates
                            .Include(e => e.Employee)
                            .Include(t => t.Task)
                            .ThenInclude(p => p.Project).AsQueryable();

            var query = from est in estimates
                        select new EmployeeEstimatesDto
                        {
                            EmployeeId = est.Employee.Id,
                            EmployeeName = est.Employee.EmployeeName,
                            Estimate = est.Estimated,
                            TaskName = est.Task.TaskName,
                            ProjectId = est.Task.Project.Id,
                            ProjectName = est.Task.Project.ProjectName
                        };

            return await query.ToListAsync();
        }
    }
}
