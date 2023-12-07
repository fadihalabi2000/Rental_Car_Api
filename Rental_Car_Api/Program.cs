using Microsoft.EntityFrameworkCore;
using Rental_Car_Api.Controllers;
using Rental_Car_DataAccess;
namespace Rental_Car_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddDbContext<CarRentalDbContext>(option =>
option.UseSqlServer(builder.Configuration["ConnectionStrings:CarApiConnectionString"]));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

                        if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

                        app.MapProgramEndpoints();

            app.Run();
        }
    }


public static class ProgramEndpoints
{
	public static void MapProgramEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Program", () =>
        {
            return new [] { new Program() };
        })
        .WithName("GetAllPrograms")
        .Produces<Program[]>(StatusCodes.Status200OK);

        routes.MapGet("/api/Program/{id}", (int id) =>
        {
            //return new Program { ID = id };
        })
        .WithName("GetProgramById")
        .Produces<Program>(StatusCodes.Status200OK);

        routes.MapPut("/api/Program/{id}", (int id, Program input) =>
        {
            return Results.NoContent();
        })
        .WithName("UpdateProgram")
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Program/", (Program model) =>
        {
            //return Results.Created($"//api/Programs/{model.ID}", model);
        })
        .WithName("CreateProgram")
        .Produces<Program>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Program/{id}", (int id) =>
        {
            //return Results.Ok(new Program { ID = id });
        })
        .WithName("DeleteProgram")
        .Produces<Program>(StatusCodes.Status200OK);
    }
}}
