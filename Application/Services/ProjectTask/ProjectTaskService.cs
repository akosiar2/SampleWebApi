using Infrastructure.Context;
using System.Threading.Tasks;
using Application.Dtos;

namespace Application.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly ApplicationDbContext _context;

        public ProjectTaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateTask(TaskDto task)
        {
            var model = new Domain.Entities.ProjectTask();
            model.TaskName = task.Name;
            model.TotalEstimate = task.TotalEstimate;
            model.ProjectId = task.ProjectId;

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return model.Id;
        }
    }
}
