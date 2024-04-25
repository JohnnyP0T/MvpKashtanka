using Kashtanka.Api.Dal;
using Kashtanka.Api.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddDbContext<ApplicationContext>(options =>
        options.UseSqlite("Data Source=Kashtanka.db"));

    
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost", builder =>
        {
            builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddControllers(options => 
    {
        options.OutputFormatters.RemoveType<StringOutputFormatter>();
    });
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Kashtanka API", Version = "v1" });
    });

    var app = builder.Build();
    
    // Middleware pipeline configuration
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors("AllowLocalhost");  // Ensure CORS is used before UseAuthorization and UseEndpoints
    app.UseAuthorization();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kashtanka API V1");
    });

    app.MapControllers();

    // Initialize and seed the database
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ApplicationContext>();
        context.Database.EnsureCreated();
        if (!context.Pets.Any())
        {
            context.Pets.AddRange(
                new Pet { Name = "Мурка" },
                new Pet { Name = "Барсик" },
                new Pet { Name = "Мурзик" }
            );
            context.SaveChanges();
        }
    }

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
