using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RecruitmentSystem.Persistence.Context;
using RecruitmentSystem.Persistence.Seed;
using RecruitmentSystem.Application.Interfaces.Authentication;
using RecruitmentSystem.Infrastructure.Authentication;
using RecruitmentSystem.Application.Interfaces.Persistence;
using RecruitmentSystem.Persistence.Repositories;
using RecruitmentSystem.Application.Features.Authentication.Services;
using RecruitmentSystem.Application.Features.Companies.Services;
using RecruitmentSystem.Application.Features.Jobs.Services;
using RecruitmentSystem.Application.Features.Applications.Services;
using RecruitmentSystem.Application.Features.Resumes.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddControllers();

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));

var jwtSettings =
    builder.Configuration.GetSection("JwtSettings");

var secret =
    jwtSettings["Secret"]!;

builder.Services
    .AddAuthentication(
        JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(secret))
            };
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped<IJwtTokenGenerator,
    JwtTokenGenerator>();

builder.Services.AddScoped<IRegisterService,
    RegisterService>();

builder.Services.AddScoped<ILoginService,
    LoginService>();

builder.Services.AddScoped<IUserRepository,
    UserRepository>();

builder.Services.AddScoped<IRoleRepository,
    RoleRepository>();

builder.Services.AddScoped<ICompanyRepository,
    CompanyRepository>();

builder.Services.AddScoped<IUnitOfWork,
    UnitOfWork>();

builder.Services.AddScoped<ICompanyService,
    CompanyService>();

builder.Services.AddScoped<IJobRepository,
    JobRepository>();

builder.Services.AddScoped<IJobService,
    JobService>();

builder.Services.AddScoped<
    IApplicationRepository,
    ApplicationRepository>();

builder.Services.AddScoped<
    IApplicationService,
    ApplicationService>();

builder.Services.AddScoped<
    IResumeRepository,
    ResumeRepository>();

builder.Services.AddScoped<
    IResumeService,
    ResumeService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();

    // If migrations are present, apply them; otherwise create the database
    var migrations = context.Database.GetMigrations();
    if (migrations != null && migrations.Any())
    {
        await context.Database.MigrateAsync();
    }
    else
    {
        await context.Database.EnsureCreatedAsync();
    }

    await RoleSeeder.SeedAsync(context);
}


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
