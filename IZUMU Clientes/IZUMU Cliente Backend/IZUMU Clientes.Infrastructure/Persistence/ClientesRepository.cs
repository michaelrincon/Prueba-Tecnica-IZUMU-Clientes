using IZUMU_Clientes.Application.DTOs;
using IZUMU_Clientes.Application.Interfaces;
using IZUMU_Clientes.Domain.Entities;
using IZUMU_Clientes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.TestManagement.TestPlanning.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZUMU_Clientes.Infrastructure.Persistence
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly IzumuDbContext _db;

        public ClientesRepository(IzumuDbContext db)
        {
            _db = db;
        }
        public async Task ActualizarCliente(int idCliente, ClienteCreateUpdateDTO dto, CancellationToken ct)
        {
            var entity = await _db.Clientes.FirstOrDefaultAsync(c => c.ClienteId == idCliente, ct);

            entity.TipoDocumentoId = dto.TipoDocumentoId;
            entity.NumeroDocumento = dto.NumeroDocumento.Trim();
            entity.FechaNacimiento = dto.FechaNacimiento.Date;
            entity.PrimerNombre = dto.PrimerNombre.Trim();
            entity.SegundoNombre = dto.SegundoNombre;
            entity.PrimerApellido = dto.PrimerApellido.Trim();
            entity.SegundoApellido = dto.SegundoApellido;
            entity.Direccion = dto.Direccion.Trim();
            entity.NumeroCelular = dto.NumeroCelular.Trim();
            entity.Email = dto.Email.Trim();
            entity.PlanId = dto.PlanId;

            await _db.SaveChangesAsync(ct);
        }

        public async Task<Cliente> CrearCliente(ClienteCreateUpdateDTO dto, CancellationToken ct)
        {
            var entity = new Cliente
            {
                TipoDocumentoId = dto.TipoDocumentoId,
                NumeroDocumento = dto.NumeroDocumento.Trim(),
                FechaNacimiento = dto.FechaNacimiento.Date,
                PrimerNombre = dto.PrimerNombre.Trim(),
                SegundoNombre = dto.SegundoNombre,
                PrimerApellido = dto.PrimerApellido.Trim(),
                SegundoApellido = dto.SegundoApellido,
                Direccion = dto.Direccion.Trim(),
                NumeroCelular = dto.NumeroCelular.Trim(),
                Email = dto.Email.Trim(),
                PlanId = dto.PlanId
            };

            _db.Clientes.Add(entity);
            await _db.SaveChangesAsync(ct);

            return entity;
        }

        public async Task<IReadOnlyList<ClientesDTO>> GetClientes(CancellationToken ct)
        {
            var listClientes = await _db.Clientes
            .AsNoTracking()
            .Include(c => c.TipoDocumento)
            .Include(c => c.Plan)
            .Select(c => new ClientesDTO
            {
                ClienteId = c.ClienteId,
                TipoDocumentoId = c.TipoDocumentoId,
                TipoDocumentoNombre = c.TipoDocumento!.Nombre,
                NumeroDocumento = c.NumeroDocumento,
                FechaNacimiento = c.FechaNacimiento,
                PrimerNombre = c.PrimerNombre,
                SegundoNombre = c.SegundoNombre,
                PrimerApellido = c.PrimerApellido,
                SegundoApellido = c.SegundoApellido,
                Direccion = c.Direccion,
                NumeroCelular = c.NumeroCelular,
                Email = c.Email,
                PlanId = c.PlanId,
                PlanNombre = c.Plan!.Nombre
            })
            .ToListAsync(ct);

            return listClientes;
        }
        public async Task<ClientesDTO> GetClientesById(int idCliente, CancellationToken ct)
        {
            var cliente = await _db.Clientes
           .AsNoTracking()
           .Include(c => c.TipoDocumento)
           .Include(c => c.Plan)
           .Where(c => c.ClienteId == idCliente)
           .Select(c => new ClientesDTO
           {
               ClienteId = c.ClienteId,
               TipoDocumentoId = c.TipoDocumentoId,
               TipoDocumentoNombre = c.TipoDocumento!.Nombre,
               NumeroDocumento = c.NumeroDocumento,
               FechaNacimiento = c.FechaNacimiento,
               PrimerNombre = c.PrimerNombre,
               SegundoNombre = c.SegundoNombre,
               PrimerApellido = c.PrimerApellido,
               SegundoApellido = c.SegundoApellido,
               Direccion = c.Direccion,
               NumeroCelular = c.NumeroCelular,
               Email = c.Email,
               PlanId = c.PlanId,
               PlanNombre = c.Plan!.Nombre
           })
           .FirstOrDefaultAsync(ct);

            return cliente;
        }

        public async Task EliminarCliente(int idCliente, CancellationToken ct)
        {
            var entity = await _db.Clientes.FirstOrDefaultAsync(c => c.ClienteId == idCliente, ct);

            _db.Clientes.Remove(entity);
            await _db.SaveChangesAsync(ct);
        }
    }
}
