using Bookify.Api.Extensions;
using Bookify.Application;
using Bookify.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
    
    // Command for "Add-Migration Create_Database" in Package Manager Console:
    // dotnet ef migrations add Create_Database --project Bookify.Infrastructure --startup-project Bookify.Api
    // run this command in the root directory of the solution
    app.ApplyMigrations();
    
    // app.SeedData();
}

app.UseHttpsRedirection();

app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();