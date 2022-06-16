using Application.Dtos;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProjectTaskService
    {
        Task<int> CreateTask(TaskDto task);
    }
}
