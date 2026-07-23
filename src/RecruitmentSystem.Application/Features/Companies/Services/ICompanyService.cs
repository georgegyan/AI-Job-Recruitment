using RecruitmentSystem.Application.Features.Companies.DTOs;
using RecruitmentSystem.Application.Features.Companies.Responses;

namespace RecruitmentSystem.Application.Features.Companies.Services;

public interface ICompanyService
{
    Task<CompanyResponse> CreateAsync(CreateCompanyRequest request);
    Task<CompanyResponse?> GetByIdAsync(Guid id);
    Task<List<CompanyResponse>> GetAllAsync();
}