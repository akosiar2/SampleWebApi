using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateController : ControllerBase
    {
        private readonly IProjectTaskService _projectTaskService;
        private readonly IEstimateService _estimateService;

        public EstimateController(IProjectTaskService projectTaskService, IEstimateService estimateService)
        {
            _projectTaskService = projectTaskService;
            _estimateService = estimateService;
        }
                
        // POST api/<EstimateController>
        [HttpPost]
        public async Task Post([FromBody] ProjectEstimateDto dto)
        {
            //create task
            var task = new TaskDto();
            task.ProjectId = dto.ProjectId;
            task.Name = dto.TaskName;
            int taskId = await _projectTaskService.CreateTask(task);

            if(taskId > 0)
            {
                foreach(var emp in dto.EmployeeEstimates)
                {
                    emp.TaskId = taskId;

                    await _estimateService.CreateEstimate(emp);
                }
            }
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeEstimatesDto>> GetAll()
        {
            return await _estimateService.GetAllEstimate();
        }

        
    }
}
