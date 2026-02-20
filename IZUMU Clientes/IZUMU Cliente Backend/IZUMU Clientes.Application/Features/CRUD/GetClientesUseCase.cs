using IZUMU_Clientes.Application.DTOs;
using IZUMU_Clientes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZUMU_Clientes.Application.Features.CRUD
{
    public class GetClientesUseCase
    {
        private readonly IClientesRepository _clientesRepository;

        public GetClientesUseCase(IClientesRepository clientes)
        {
            _clientesRepository = clientes;
        }

        public async Task<IReadOnlyList<ClientesDTO>> GetClientes(CancellationToken ct)
        {
            return await _clientesRepository.GetClientes(ct);
        }
    }
}
