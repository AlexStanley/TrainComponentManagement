using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using TrainComponentManagement.Data;
using TrainComponentManagement.Models;
using TrainComponentManagement.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder 
        => builder.WithOrigins("http://localhost:4200").AllowAnyMethod()
        .WithHeaders(HeaderNames.ContentType, "x-custom-header"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TrainComponentContext>(options 
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITrainComponentRepository, TrainComponentRepository>();
builder.Services.AddScoped<IComponentHierarchyRepository, ComponentHierarchyRepository>();
builder.Services.AddScoped<ITrainComponentQuantityAssignmentRepository, TrainComponentQuantityAssignmentRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

InitializationDbWithData.PrepPopulation(app);

app.MapControllers();

app.Run();
