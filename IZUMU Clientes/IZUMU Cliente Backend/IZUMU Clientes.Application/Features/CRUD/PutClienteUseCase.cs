using IZUMU_Clientes.Application.DTOs;
using IZUMU_Clientes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZUMU_Clientes.Application.Features.CRUD
{
    public class PutClienteUseCase
    {

        private readonly IClientesRepository _clientesRepository;

        public PutClienteUseCase(IClientesRepository clientes)
        {
            _clientesRepository = clientes;
        }
        public async Task ActualizarCliente(int idCliente, ClienteCreateUpdateDTO cliente, CancellationToken ct)
        {
            await _clientesRepository.ActualizarCliente(idCliente, cliente, ct);
        }
    }
}
