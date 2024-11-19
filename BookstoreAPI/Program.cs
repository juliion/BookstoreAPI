using Bookstore.Infrastructure;
using Bookstore.Application;
using Bookstore.Infrastructure.Persistence;
using BookstoreAPI.Middleware;
using BookstoreAPI.Mappings;
using Bookstore.Application.Common.Mappings;

namespace BookstoreAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAutoMapper(typeof(ApiMappingProfile), typeof(ApplicationMappingProfile));
       
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyOrigin();
                policy.AllowAnyMethod();
            });
        });

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var context = serviceProvider.GetRequiredService<BookstoreDbContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured while app initialization: {ex}");
            }
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionHandlerMiddleware>();
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
