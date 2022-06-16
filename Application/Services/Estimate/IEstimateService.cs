
using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IEstimateService
    {
        Task<EstimateDto> CreateEstimate(EstimateDto estimated);
        Task<IEnumerable<EmployeeEstimatesDto>> GetAllEstimate();
    }
}
