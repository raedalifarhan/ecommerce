

using Core.Interfaces;
using Core.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.ProjectStartup
{
    public static class RegisterStartupServices
    {
        [Obsolete]
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {

            // Add services to the container.
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddFluentValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(
                builder.Configuration.GetConnectionString("ConnectionDb")
            ));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // // Add services to the container.
            // builder.Services.AddScoped<IBookService, BookService>();

            // builder.Services.AddDbContext<ApplicationDbContext>(option =>
            //     option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDb"))
            // );

            // builder.Services.AddAutoMapper(typeof(Program));
            // builder.Services.AddControllersWithViews();

            return builder;
        }
    }
}