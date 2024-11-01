using FrontClinicaMedica.Models;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace FrontClinicaMedica
{
    public static class UsuarioDAL
    {
        public static string EnderecoAPI = "http://localhost:5141/api/";

        public async static Task<string> FazerLogin (UsuarioLogin usuario)
        {
            var json = JsonSerializer.Serialize(usuario);
            var end = EnderecoAPI + "account/login";

            var token = await PostDataToApi(end, json);

            return token;
        }


        private async static Task<string> PostDataToApi(string url, string jsonPayload)
        {
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode(); 

                string responseBody = await response.Content.ReadAsStringAsync();

                using (JsonDocument doc = JsonDocument.Parse(responseBody))
                {
                    return doc.RootElement.GetProperty("token").GetString();
                }
            }
            catch (HttpRequestException e)
            {
                return "Erro";
            }
        }
    }
}

