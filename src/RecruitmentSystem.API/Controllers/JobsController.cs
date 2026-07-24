using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RecruitmentSystem.Application.Features.Jobs.DTOs;
using RecruitmentSystem.Application.Features.Jobs.Services;

namespace RecruitmentSystem.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class JobsController(
    IJobService jobService) : ControllerBase
{
    private readonly IJobService _jobService = jobService;

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateJobRequest request)
    {
        var result =
            await _jobService.CreateAsync(request);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(
            await _jobService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result =
            await _jobService.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted =
            await _jobService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}