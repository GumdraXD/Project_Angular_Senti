
using System;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace Project_Angular_Senti.Server
{
    public class Program
    {   
        
        public static void Main(string[] args)
        {
            /*Db.Context 
             * 
             * DbContext is a core concept in Entity Framework Core (EF Core). It is a data access class that manages the entity objects (models) and provides methods to query and update the underlying database.
               Purpose:
                Database Access: DbContext acts as the bridge between your application models and the database. It is used to perform CRUD operations and track changes to entities.
                 Manages Entity Relationships: It is responsible for managing the entities that are mapped to database tables, handling relationships like one-to-many or many-to-many.
                Common Use Cases:
                Querying the database using LINQ (DbSet<TEntity>).
                Saving changes to the database (SaveChangesAsync()).
                Defining model relationships (e.g., one-to-many or many-to-many).
                Applying migrations to create and update the database schema.

                 https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/#dbcontext-in-dependency-injection-for-aspnet-core
   
             */

            

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Josh Added
            var connection = String.Empty;
            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.json");
                connection = builder.Configuration.GetConnectionString("ConnectionName2");
            }
            else
            {
                connection = Environment.GetEnvironmentVariable("ConnectionName2");
            }

            builder.Services.AddDbContext<SurveyContext>(options =>
                options.UseSqlServer(connection));

            var app = builder.Build();

            //Tester
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<SurveyContext>();

                if (!dbContext.Database.CanConnect())
                {
                    throw new NotImplementedException("CANNOT CONNECT to DB");
                }

            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
          
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");


            app.MapPost("/Survey", (Survey person, SurveyContext context) =>
            {
                context.Add(person);
                context.SaveChanges();
            })
            .WithName("CreatePerson")
            .WithOpenApi();

            app.Run();
        }
    }
}
