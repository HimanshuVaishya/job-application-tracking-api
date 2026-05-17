using JobTrackerAPI.DTOs;
using JobTrackerAPI.Helpers;
using JobTrackerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> Apply([FromForm] ApplyJobDto dto)
        {
            var userEmail = User.FindFirst(ClaimTypes.Name)?.Value;

            if (userEmail == null)
                return Unauthorized(new ApiResponse<string>(false, "Invalid token"));

            var userId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");
            var result = await _applicationService.ApplyJobAsync(userId, dto);
            return Ok(new ApiResponse<string>(true, result));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetApplications()
        {
            var apps = await _applicationService.GetApplicationsAsync();
            return Ok(new ApiResponse<object>(true, "List of applications", apps));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, UpdateStatusDto dto)
        {
            var result = await _applicationService.UpdateStatusAsync(id, dto.Status);
            return Ok(new ApiResponse<string>(true, result));
        }
    }
}
