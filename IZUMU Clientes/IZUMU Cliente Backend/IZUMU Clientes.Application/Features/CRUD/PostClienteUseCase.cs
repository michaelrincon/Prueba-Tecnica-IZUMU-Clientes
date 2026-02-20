using IZUMU_Clientes.Application.DTOs;
using IZUMU_Clientes.Application.Interfaces;
using IZUMU_Clientes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZUMU_Clientes.Application.Features.CRUD
{
    public  class PostClienteUseCase
    {
        private readonly IClientesRepository _clientesRepository;

        public PostClienteUseCase(IClientesRepository clientes)
        {
            _clientesRepository = clientes;
        }

        public async Task<Cliente> CrearClientes(ClienteCreateUpdateDTO dto, CancellationToken ct)
        {
            return await _clientesRepository.CrearCliente(dto,ct);
        }
    }
}
