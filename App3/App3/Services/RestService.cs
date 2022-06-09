using App3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App3.Services
{
    public class RestService
    {

        HttpClient client;

        public RestService()
        {
#if false   
            client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
#else
            client = new HttpClient();
#endif
        }
    

    public async Task<List<Igreja>> GetIgrejasAsync()
        {
            try
            {
                string url = "https://10.0.2.2:7004/api/Igrejas";
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<List<Igreja>>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Root> GetVerses(string chapter, string book)
        {
            try
            {
                string url = "https://bible-api.com/"+book+"%20"+chapter+"?verse_numbers=true&translation=almeida";
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<Root>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<RootHinario> GetHinariosAsync()
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/Hinario";
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<RootHinario>(response);
                return produtos;
            }
            catch (HttpRequestException ex)
            {
                await Shell.Current.GoToAsync("//MainPage");
                return null;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<RootHinario> GetDescHinarioAsync(string nome)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/DescHinario/" + nome;
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<RootHinario>(response);
                return produtos;
            }
            catch (HttpRequestException ex)
            {
                await Shell.Current.GoToAsync("//MainPage");
                return null;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}

