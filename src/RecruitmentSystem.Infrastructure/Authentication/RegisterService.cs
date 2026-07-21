using RecruitmentSystem.Application.Features.Authentication.Commands.Register;
using RecruitmentSystem.Application.Features.Authentication.Responses;
using RecruitmentSystem.Application.Features.Authentication.Services;
using RecruitmentSystem.Application.Interfaces.Authentication;
using RecruitmentSystem.Application.Interfaces.Persistence;
using RecruitmentSystem.Domain.Entities;

namespace RecruitmentSystem.Infrastructure.Authentication;

public class RegisterService : IRegisterService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterService(
        IUserRepository userRepository,
        IRoleRepository roleRepository,
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<RegisterResult> RegisterAsync(
        RegisterCommand command)
    {
        var existingUser =
            await _userRepository.GetByEmailAsync(command.Email);

        if (existingUser is not null)
        {
            return new RegisterResult
            {
                Success = false,
                Message = "Email already exists."
            };
        }

        var role =
            await _roleRepository.GetByNameAsync(command.Role);

        if (role is null)
        {
            return new RegisterResult
            {
                Success = false,
                Message = "Role not found."
            };
        }

        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            PasswordHash = _passwordHasher.HashPassword(command.Password),
            RoleId = role.Id
        };

        await _userRepository.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return new RegisterResult
        {
            Success = true,
            Message = "User registered successfully."
        };
    }
}