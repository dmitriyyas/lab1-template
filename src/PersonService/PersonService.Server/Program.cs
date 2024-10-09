using Microsoft.EntityFrameworkCore;
using PersonService.DataAccess;
using PersonService.DataAccess.Repositories;
using PersonService.Domain.Interfaces.Repositories;
using PersonService.Domain.Interfaces.Services;
using PersonService.Domain.Services;
using PersonService.Server.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPersonsRepository, PersonsRepository>();
builder.Services.AddTransient<IPersonsService, PersonsService>();
builder.Services.AddDbContext<PersonContext>(opt =>
            opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Transient, ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.MigrateDatabaseAsync<PersonContext>();

app.Run();
