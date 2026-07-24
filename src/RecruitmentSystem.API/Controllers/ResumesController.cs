using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Application.Features.Resumes.Services;

namespace RecruitmentSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResumesController(
    IResumeService resumeService)
    : ControllerBase
{
    private readonly IResumeService
        _resumeService = resumeService;

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(
        [FromForm] Guid candidateId,
        [FromForm] IFormFile file)
    {
        var result =
            await _resumeService.UploadAsync(
                candidateId,
                file);

        return Ok(result);
    }

    [HttpGet("{candidateId}")]
    public async Task<IActionResult> GetResumes(
        Guid candidateId)
    {
        var result =
            await _resumeService
                .GetCandidateResumesAsync(
                    candidateId);

        return Ok(result);
    }
}