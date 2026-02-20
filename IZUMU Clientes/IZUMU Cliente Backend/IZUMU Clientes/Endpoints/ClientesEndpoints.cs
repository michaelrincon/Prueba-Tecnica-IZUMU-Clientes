using IZUMU_Clientes.Application.DTOs;
using IZUMU_Clientes.Application.Features.CRUD;
using System.Collections.Generic;

namespace IZUMU_Clientes.Endpoints
{
    public static class ClientesEndpoints
    {
        public static void ObtenerClientes(this WebApplication app)
        {

            app.MapGet("/api/clientes", async (
                GetClientesUseCase useCase,
                CancellationToken ct) =>
            {
                try
                {
                    var data = await useCase.GetClientes(ct);
                    if (!data.Any())
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(data);
                }
                catch (Exception)
                {

                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
                }
                
            });
        }

        public static void ObtenerClientePorId(this WebApplication app)
        {

            app.MapGet("/api/clientes/{idCliente}", async (
                int idCliente,
                GetClienteByIdUseCase useCase,
                CancellationToken ct) =>
            {
                try
                {
                    var data = await useCase.GetClientesById(idCliente, ct);
                    if (data is null)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(data);
                }
                catch (Exception)
                {

                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
                }

            });
        }

        public static void CrearCliente(this WebApplication app)
        {
            app.MapPost("/api/clientes", async (
                ClienteCreateUpdateDTO cliente,
                PostClienteUseCase useCase,
                CancellationToken ct) =>
            {
                try
                {
                    var result = await useCase.CrearClientes(cliente, ct);
                    return Results.Created($"/api/clientes/{result.ClienteId}", result);
                }
                catch (Exception)
                {

                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
                }

            });
        }

        public static void ActualizarCliente(this WebApplication app)
        {
            app.MapPut("/api/clientes/{idCliente}", async (
                int idCliente,
                ClienteCreateUpdateDTO cliente,
                PutClienteUseCase useCase,
                CancellationToken ct) =>
            {
                try
                {
                    await useCase.ActualizarCliente(idCliente, cliente, ct);
                    return Results.Ok("Cliente actualizado correctamente");
                }
                catch (Exception)
                {

                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
                }
                
            });
        }

        public static void EliminarCliente(this WebApplication app)
        {
            app.MapDelete("/api/clientes/{idCliente}", async (
                int idCliente,
                DeleteClienteUseCase useCase,
                CancellationToken ct) =>
            {
                try
                {
                    await useCase.EliminarCliente(idCliente, ct);
                    return Results.Ok("Cliente eliminado correctamente.");
                }
                catch (Exception)
                {

                    return Results.StatusCode(StatusCodes.Status500InternalServerError);
                }
                
            });
        }
    }
}
