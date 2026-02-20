namespace IZUMU_Clientes_Frontend.Models
{
    public class ClientesDTO
    {
        public int ClienteId { get; set; }

        public int TipoDocumentoId { get; set; }
        public string TipoDocumentoNombre { get; set; } = string.Empty;

        public string NumeroDocumento { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }

        public string Direccion { get; set; }
        public string NumeroCelular { get; set; }

        public string Email { get; set; }

        public int PlanId { get; set; }
        public string PlanNombre { get; set; } = string.Empty;
    }
}
