using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using pokeSharp;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.



        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // builder.Services.AddDbContext<PokemonContext>(p => p.UseInMemoryDatabase("PokeDb"));
        builder.Services.AddSqlServer<PokemonContext>(builder.Configuration.GetConnectionString("CokeString"));

        var app = builder.Build();



        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        dbInit.GetConnection(app.Services.GetRequiredService<PokemonContext>());
    }
}

public class dbInit{
    public static async void GetConnection([FromServices] PokemonContext pokeContext)
     {
        pokeContext.Database.EnsureCreated();
        
     }
}