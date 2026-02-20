using IZUMU_Clientes.Application.DTOs;
using IZUMU_Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZUMU_Clientes.Application.Interfaces
{
    public interface IClientesRepository
    {
        Task<IReadOnlyList<ClientesDTO>> GetClientes(CancellationToken ct);
        Task<Cliente> CrearCliente(ClienteCreateUpdateDTO dto, CancellationToken ct);
        Task ActualizarCliente(int idCliente, ClienteCreateUpdateDTO dto, CancellationToken ct);
        Task EliminarCliente(int idCliente, CancellationToken ct);
        Task<ClientesDTO> GetClientesById(int idCliente, CancellationToken ct);

    }
}
