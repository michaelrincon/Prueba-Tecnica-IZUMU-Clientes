using IZUMU_Clientes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZUMU_Clientes.Application.Features.CRUD
{
    public class DeleteClienteUseCase
    {
        private readonly IClientesRepository _clientesRepository;

        public DeleteClienteUseCase(IClientesRepository clientes)
        {
            _clientesRepository = clientes;
        }

        public async Task EliminarCliente(int idCliente, CancellationToken ct)
        {
            await _clientesRepository.EliminarCliente(idCliente, ct);
        }
    }
}
