using Microsoft.EntityFrameworkCore;
using PloomesTest.Models;

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