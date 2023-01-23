

using Core.Interfaces;
using Core.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.ProjectStartup
{
    public static class RegisterStartupServices
    {
        [Obsolete]
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {

            // Add services to the container.

            // Custom Dependancy Injection of Repositories
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Add Fluent Validation
            builder.Services.AddFluentValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();

            builder.Services.AddControllers();
            // Add SQL Server Connection String
            builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(
                builder.Configuration.GetConnectionString("ConnectionDb")
            ));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // builder.Services.AddAutoMapper(typeof(Program));

            return builder;
        }
    }
}