﻿using FrontClinicaMedica.Models;
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
        public static string EnderecoAPI = "https://localhost:7226/api/";

        public async static Task<List<Doctor>> BuscarMedicosNome ()
        {
            HttpClient client = new HttpClient();

            try
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UsuarioInfo.JWTToken);

                HttpResponseMessage response = await client.GetAsync(EnderecoAPI + "doctor");
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                List<Doctor> doctors = JsonSerializer.Deserialize<List<Doctor>>(jsonResponse);

                return doctors;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }

        public async static Task<List<String>> BuscarMedicosEspecialidade ()
        {
            HttpClient client = new HttpClient();

            try
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UsuarioInfo.JWTToken);

                HttpResponseMessage response = await client.GetAsync(EnderecoAPI + "doctor");
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                List<Doctor> doctors = JsonSerializer.Deserialize<List<Doctor>>(jsonResponse);

                return (from p in doctors select p.specialty).ToList();
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }

        public async static Task<List<GetTimeSlot>> BuscarTimeSlotsDisponiveis (BuscaInfo info)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UsuarioInfo.JWTToken);
            var enderecoReq = EnderecoAPI + "timeslot";

            if (info.Tipo == "especialidade")
                enderecoReq += "?specialty=" + info.Value;
            else
                enderecoReq += "/doctor/" + info.Value;

            HttpResponseMessage response = await client.GetAsync(enderecoReq);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            List<GetTimeSlot> horarios = JsonSerializer.Deserialize<List<GetTimeSlot>>(jsonResponse);

            return horarios;
        }

        public async static Task<bool> MarcarConsulta (PostAppointment info)
        {
            try
            {
                var json = JsonSerializer.Serialize(info);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UsuarioInfo.JWTToken);
                var end = EnderecoAPI + "appointment";
                HttpResponseMessage response = await client.PostAsync(end, content);
                response.EnsureSuccessStatusCode();

                return true;
            } catch (Exception e)
            {
                var aaa = e;
                return false;
            }
        }

        public async static Task<List<GetAppointment>> BuscarAppointmentsPorUser () {
            HttpClient client = new HttpClient();

            try
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UsuarioInfo.JWTToken);

                HttpResponseMessage response = await client.GetAsync(EnderecoAPI + "appointment/patient?email=" + UsuarioInfo.Email);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                var results = JsonSerializer.Deserialize<List<GetAppointment>>(jsonResponse);

                return results;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }
    }
}
