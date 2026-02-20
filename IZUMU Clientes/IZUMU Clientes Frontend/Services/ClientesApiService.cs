using IZUMU_Clientes_Frontend.Models;

namespace IZUMU_Clientes_Frontend.Services
{
    public class ClientesApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientesApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient CreateClient() =>
            _httpClientFactory.CreateClient("ApiClient");

        public async Task<List<ClientesDTO>> GetClientes()
        {
            var client = CreateClient();
            return await client.GetFromJsonAsync<List<ClientesDTO>>("/api/clientes")
                   ?? new List<ClientesDTO>();
        }

        public async Task<ClientesDTO?> GetClienteById(int id)
        {
            var client = CreateClient();
            return await client.GetFromJsonAsync<ClientesDTO>($"/api/clientes/{id}");
        }

        public async Task<bool> CreateCliente(ClienteCreateUpdateDTO dto)
        {
            var client = CreateClient();
            var response = await client.PostAsJsonAsync("/api/clientes", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCliente(int id, ClienteCreateUpdateDTO dto)
        {
            var client = CreateClient();
            var response = await client.PutAsJsonAsync($"/api/clientes/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCliente(int id)
        {
            var client = CreateClient();
            var response = await client.DeleteAsync($"/api/clientes/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
