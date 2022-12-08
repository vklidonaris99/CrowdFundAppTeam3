using CrowdFoundAppTeam3.Data;
using CrowdFoundAppTeam3.Interface;
using CrowdFoundAppTeam3.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<CrowdFundDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("CrowdFund")));
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectCreator, ProjectCreatorService>();
builder.Services.AddScoped<IBacker, BackerService>();
builder.Services.AddScoped<IFundingPackage, FundingPackageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapRazorPages();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
