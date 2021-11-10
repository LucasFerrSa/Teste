using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace TestePresentation.Api
{
    public class MovimentoManual : Api.IMovimentoManual
    {
        private readonly HttpClient _httpClient;
        //private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public MovimentoManual(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Models.baseModel> GetMovimentos()
        {
            Models.baseModel result = new Models.baseModel();

            var produtos = await _httpClient.GetStringAsync(ConfigurationManager.AppSettings["ApiURL"] + "Produto");
            result.Produto = JsonConvert.DeserializeObject<List<Models.Produto>>(produtos);

            var produtosCosifs = await _httpClient.GetStringAsync(ConfigurationManager.AppSettings["ApiURL"] + "ProdutoCosif");
            result.ProdutoCosif = JsonConvert.DeserializeObject<List<Models.ProdutoCosif>>(produtosCosifs);

            var moviManual = await _httpClient.GetStringAsync(ConfigurationManager.AppSettings["ApiURL"] + "MovimentoManual");
            result.MovimentoManual = JsonConvert.DeserializeObject<List<Models.MovimentoManual>>(moviManual);

            return result;
        }

        public async Task PostMovimentos(Models.MovimentoManual movimento)
        {
            string json = JsonConvert.SerializeObject(movimento);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var produtos = await _httpClient.PostAsync(ConfigurationManager.AppSettings["ApiURL"] + "MovimentoManual", httpContent);
        }

    }
}