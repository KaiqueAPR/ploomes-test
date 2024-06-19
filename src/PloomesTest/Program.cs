using Microsoft.EntityFrameworkCore;
using PloomesTest.Models;
using PloomesTest.Repositories;
using PloomesTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Start: Make connection with DB - SQL Server
builder.Services.AddDbContext<PloomesTestContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
// End: Make connection with DB - SQL Server

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRegisterPerson, RegisterPerson>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();