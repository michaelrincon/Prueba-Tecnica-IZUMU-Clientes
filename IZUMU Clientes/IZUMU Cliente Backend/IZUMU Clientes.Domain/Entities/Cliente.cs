using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IZUMU_Clientes.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public int TipoDocumentoId { get; set; }
        public TiposDocumento? TipoDocumento { get; set; }

        public string NumeroDocumento { get; set; } = string.Empty;

        public DateTime FechaNacimiento { get; set; }

        public string PrimerNombre { get; set; } = string.Empty;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = string.Empty;
        public string? SegundoApellido { get; set; }

        public string Direccion { get; set; } = string.Empty;
        public string NumeroCelular { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public int PlanId { get; set; }
        public Plan? Plan { get; set; }
    }
}
