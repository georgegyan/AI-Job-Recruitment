using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Application.Features.Applications.DTOs;
using RecruitmentSystem.Application.Features.Applications.Services;

namespace RecruitmentSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController(
    IApplicationService applicationService)
    : ControllerBase
{
    private readonly IApplicationService
        _applicationService = applicationService;

    [HttpPost("apply")]
    public async Task<IActionResult> Apply(
        ApplyJobRequest request)
    {
        var result =
            await _applicationService.ApplyAsync(request);

        return Ok(result);
    }

    [HttpGet("candidate/{candidateId}")]
    public async Task<IActionResult>
        CandidateApplications(Guid candidateId)
    {
        return Ok(
            await _applicationService
                .GetCandidateApplicationsAsync(
                    candidateId));
    }

    [HttpGet("job/{jobId}")]
    public async Task<IActionResult>
        JobApplications(Guid jobId)
    {
        return Ok(
            await _applicationService
                .GetJobApplicationsAsync(jobId));
    }
}