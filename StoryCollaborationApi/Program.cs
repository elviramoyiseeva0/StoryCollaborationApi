using Microsoft.EntityFrameworkCore;
using StoryCollaborationApi.Data;
using StoryCollaborationApi.Interfaces;
using StoryCollaborationApi.Repositories;
using StoryCollaborationApi.Handlers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(opts => {
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

builder.Services.AddScoped<IStoryRepository, StoryRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(VoteContributionCommandHandler).Assembly));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();