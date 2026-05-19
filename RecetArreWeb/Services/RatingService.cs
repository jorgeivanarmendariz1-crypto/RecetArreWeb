using System.Net.Http.Json;
using RecetArreWeb.DTOs;

namespace RecetArreWeb.Services
{
    public interface IRatingService
    {
        Task<RatingDto?> Votar(RatingCreacionDto dto);
        Task<RatingResumenDto?> ObtenerResumenReceta(int recetaId);
        Task<List<PowerRankingItemDto>> ObtenerPowerRanking();
    }

    public class RatingService : IRatingService
    {
        private readonly HttpClient httpClient;
        private const string endpoint = "api/Ratings";

        public RatingService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<RatingDto?> Votar(RatingCreacionDto dto)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync(endpoint, dto);
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<RatingDto>();
                Console.WriteLine($"Error al votar: {await response.Content.ReadAsStringAsync()}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al votar: {ex.Message}");
                return null;
            }
        }

        public async Task<RatingResumenDto?> ObtenerResumenReceta(int recetaId)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<RatingResumenDto>($"{endpoint}/receta/{recetaId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener resumen: {ex.Message}");
                return null;
            }
        }

        public async Task<List<PowerRankingItemDto>> ObtenerPowerRanking()
        {
            try
            {
                var resultado = await httpClient.GetFromJsonAsync<List<PowerRankingItemDto>>($"{endpoint}/powerranking");
                return resultado ?? new List<PowerRankingItemDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener power ranking: {ex.Message}");
                return new List<PowerRankingItemDto>();
            }
        }
    }
}