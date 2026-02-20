using IZUMU_Clientes.Application.DTOs;
using IZUMU_Clientes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZUMU_Clientes.Application.Features.CRUD
{
    public class GetClienteByIdUseCase
    {
        private readonly IClientesRepository _clientesRepository;

        public GetClienteByIdUseCase(IClientesRepository clientes)
        {
            _clientesRepository = clientes;
        }

        public async Task<ClientesDTO> GetClientesById(int idCliente, CancellationToken ct)
        {
            return await _clientesRepository.GetClientesById(idCliente,ct);
        }
    }
}
