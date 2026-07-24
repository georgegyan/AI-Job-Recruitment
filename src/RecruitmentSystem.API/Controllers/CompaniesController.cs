using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Application.Features.Companies.DTOs;
using RecruitmentSystem.Application.Features.Companies.Services;

namespace RecruitmentSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController(
    ICompanyService companyService) : ControllerBase
{
    private readonly ICompanyService _companyService = companyService;

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateCompanyRequest request)
    {
        try
        {
            var result =
                await _companyService.CreateAsync(request);

            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result =
            await _companyService.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result =
            await _companyService.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}