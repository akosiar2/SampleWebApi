
using System.Collections.Generic;

namespace Application.Dtos
{
    public class ProjectEstimateDto
    {
        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public int TotalEstimate { get; set; }
        public List<EstimateDto> EmployeeEstimates { get; set; }
    }
}
