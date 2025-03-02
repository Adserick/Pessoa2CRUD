﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using webPessoa.Models;

namespace webPessoa.Services
{
    public class apiPessoaService
    {
        private readonly HttpClient _httpClient;

        public apiPessoaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Pessoa>?> GetPessoasAsync()
        {
            var response = await _httpClient.GetAsync("api/pessoa");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Pessoa>>(content);
        }

        public async Task<Pessoa?> GetPessoaAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/pessoa{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Pessoa>(content);
        }

        public async Task CreateAsync(Pessoa pessoa) 
        {
            var json = JsonConvert.SerializeObject(pessoa);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/pessoa", content);
            response .EnsureSuccessStatusCode();   
        }

        public async Task UpdateAsync(Pessoa pessoa) 
        {
            var json = JsonConvert.SerializeObject(pessoa);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/pessoa/{pessoa.Id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id) 
        {
            var response = await _httpClient.DeleteAsync($"api/pessoa/{id}");
        }

        internal async Task CreateAsync(apipessoa2.Models.Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        internal async Task UpdateAsync(apipessoa2.Models.Pessoa pessoa)
        {
            throw new NotImplementedException();
        }
    }
}
