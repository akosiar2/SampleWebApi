
namespace Application.Dtos
{
    public class EstimateDto
    { 
        public int Id { get; set; }
        public int Estimated { get; set; }
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
    }
}
