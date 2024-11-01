using FrontClinicaMedica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FrontClinicaMedica.DALs
{
    public static class ConsultasDAL
    {
        public static string EnderecoAPI = "http://localhost:5141/api/";

        public async static Task<List<String>> BuscarMedicos()
        {
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(EnderecoAPI + "doctor");
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                List<Doctor> doctors = JsonSerializer.Deserialize<List<Doctor>>(jsonResponse);

                return (from p in doctors select p.Name).ToList();
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }
    }
}
