using HotelListing.API.Configurations;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using HotelListing.API.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        //connection database
        var connectionstring = builder.Configuration.GetConnectionString("HotellistingDbConnectionString");
        builder.Services.AddDbContext<HotelListingDbContext>(options =>
        {
            options.UseSqlServer(connectionstring);
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        //Add CORS => Cross Origin ResourceS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", 
                p => p.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod());
        });

        //Add Serilog
        builder.Host.UseSerilog((ctx,lc)=>lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));// ctx => context:builder, lc => logger configuration

        //Add Mappers
        builder.Services.AddAutoMapper(typeof(MapperConfig));

        //Add Repositories
        builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
        builder.Services.AddScoped<ICountriesRepository,CountriesRepository>();
        builder.Services.AddScoped<IHotelsRepository,HotelsRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //Request Logging
        app.UseSerilogRequestLogging();

        app.UseHttpsRedirection();

        app.UseCors("AllowAll");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}