using JobTrackerAPI.DTOs;
using JobTrackerAPI.Helpers;
using JobTrackerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobsController(IJobService jobService)
        {
            this._jobService = jobService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateJob(CreateJobDto dto)
        {
            var job = await _jobService.CreateJobAsync(dto);
            return Ok(new ApiResponse<object>(true, "Job created successfully", job));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return Ok(new ApiResponse<object>(true, "Jobs fetched successfully", jobs));
        }
    }
}
