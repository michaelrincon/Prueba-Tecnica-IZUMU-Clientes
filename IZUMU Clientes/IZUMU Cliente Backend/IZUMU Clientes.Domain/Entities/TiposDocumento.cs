using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZUMU_Clientes.Domain.Entities
{
    public class TiposDocumento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public List<Cliente> Clientes { get; set; } = new();
    }
}
