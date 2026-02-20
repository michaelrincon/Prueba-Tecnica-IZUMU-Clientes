
using IZUMU_Clientes.Application.Features.CRUD;
using IZUMU_Clientes.Application.Interfaces;
using IZUMU_Clientes.Endpoints;
using IZUMU_Clientes.Infrastructure.Data;
using IZUMU_Clientes.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IZUMU_Clientes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<IzumuDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
            builder.Services.AddScoped<GetClienteByIdUseCase>();
            builder.Services.AddScoped<GetClientesUseCase>();
            builder.Services.AddScoped<PostClienteUseCase>();
            builder.Services.AddScoped<PutClienteUseCase>();
            builder.Services.AddScoped<DeleteClienteUseCase>();

            // Add services to the container.
            builder.Services.AddAuthorization();

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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.ObtenerClientes();
            app.ObtenerClientePorId();
            app.ActualizarCliente();
            app.CrearCliente();
            app.EliminarCliente();

            app.Run();
        }
    }
}
