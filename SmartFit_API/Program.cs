using Microsoft.EntityFrameworkCore;
using SmartFit_API.Models;
using Microsoft.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //creacion De la config de la cadena de conexion



        // Add services to the container.

        builder.Services.AddControllers();


        //Obtenemos la info de la cadena de conexion desde el archivo de configuracion
        //appsettings.json el nombre de la etiqueta es CNNSTR

        var CnnStrBuilder = new SqlConnectionStringBuilder(
            builder.Configuration.GetConnectionString("CNNSTR")
            );

        var CnnStr = CnnStrBuilder.ConnectionString;


           var conn = @"SERVER=DESKTOP-AIMH9J6;DATABASE=SmartFit; INTEGRATED SECURITY=TRUE; User Id=;Password=;";

          builder.Services.AddDbContext<SmartFitContext>(options => options.UseSqlServer(conn));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }



        app.UseAuthorization();

        app.UseRouting();

        app.MapControllers();

        app.Run();
    }
}
