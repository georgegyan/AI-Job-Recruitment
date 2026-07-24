using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RecruitmentSystem.Application.Features.Resumes.Responses;
using RecruitmentSystem.Application.Interfaces.Persistence;
using RecruitmentSystem.Domain.Entities;

namespace RecruitmentSystem.Application.Features.Resumes.Services;

public class ResumeService : global::RecruitmentSystem.Application.Features.Resumes.Services.IResumeService
{
    private readonly IResumeRepository _resumeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _environment;

    public ResumeService(
        IResumeRepository resumeRepository,
        IUnitOfWork unitOfWork,
        IWebHostEnvironment environment)
    {
        _resumeRepository = resumeRepository;
        _unitOfWork = unitOfWork;
        _environment = environment;
    }

    public async Task<ResumeResponse> UploadAsync(
        Guid candidateId,
        IFormFile file)
    {
        var uploadsFolder = Path.Combine(
            _environment.WebRootPath,
            "resumes");

        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var uniqueFileName =
            $"{Guid.NewGuid()}_{file.FileName}";

        var filePath =
            Path.Combine(
                uploadsFolder,
                uniqueFileName);

        using (var stream =
               new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var resume = new Resume
        {
            CandidateId = candidateId,
            FileName = file.FileName,
            FilePath = $"/resumes/{uniqueFileName}"
        };

        await _resumeRepository.AddAsync(resume);

        await _unitOfWork.SaveChangesAsync();

        return new ResumeResponse
        {
            Id = resume.Id,
            FileName = resume.FileName,
            FilePath = resume.FilePath
        };
    }

    public async Task<List<ResumeResponse>>
        GetCandidateResumesAsync(Guid candidateId)
    {
        var resumes =
            await _resumeRepository
                .GetByCandidateIdAsync(candidateId);

        return resumes.Select(r =>
            new ResumeResponse
            {
                Id = r.Id,
                FileName = r.FileName,
                FilePath = r.FilePath
            }).ToList();
    }
}