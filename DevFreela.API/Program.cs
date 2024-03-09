using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Application.Queries.GetUser;
using DevFreela.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateProjectCommand).Assembly); });
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateCommentCommand).Assembly); });
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly); });
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(DeleteProjectCommand).Assembly); });
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(UpdateProjectCommand).Assembly); });
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(StartProjectCommand).Assembly); });
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(FinishProjectCommand).Assembly); });
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(GetAllSkillsQuery).Assembly); });
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(GetAllProjectsQuery).Assembly); });
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(GetUserQuery).Assembly); });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
