using RecruitmentSystem.Application.Features.Companies.DTOs;
using RecruitmentSystem.Application.Features.Companies.Responses;
using RecruitmentSystem.Application.Interfaces.Persistence;
using RecruitmentSystem.Domain.Entities;

namespace RecruitmentSystem.Application.Features.Companies.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CompanyService(
        ICompanyRepository companyRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _companyRepository = companyRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CompanyResponse> CreateAsync(
        CreateCompanyRequest request)
    {
        var recruiter = await _userRepository.GetByIdAsync(request.RecruiterId);

        if (recruiter is null)
        {
            throw new ArgumentException(
                "RecruiterId does not reference an existing user.");
        }

        var company = new Company
        {
            Name = request.Name,
            Description = request.Description,
            Website = request.Website,
            RecruiterId = request.RecruiterId
        };

        await _companyRepository.AddAsync(company);
        await _unitOfWork.SaveChangesAsync();

        return new CompanyResponse
        {
            Id = company.Id,
            Name = company.Name,
            Description = company.Description,
            Website = company.Website
        };
    }

    public async Task<CompanyResponse?> GetByIdAsync(Guid id)
    {
        var company = await _companyRepository.GetByIdAsync(id);

        if (company == null)
            return null;

        return new CompanyResponse
        {
            Id = company.Id,
            Name = company.Name,
            Description = company.Description,
            Website = company.Website
        };
    }

    public async Task<List<CompanyResponse>> GetAllAsync()
    {
        var companies = await _companyRepository.GetAllAsync();

        return companies.Select(c => new CompanyResponse
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            Website = c.Website
        }).ToList();
    }
}