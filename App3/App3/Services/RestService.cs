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
        HttpClient clientFora;
        public RestService()
        {
            clientFora = new HttpClient();
#if DEBUG  
            client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
#else
            client = new HttpClient();
#endif
        }

        public async Task<User> PostLogin(string data, string email, string pass)
        {
            try
            {
                string url = "https://10.0.2.2:7004/api/Users/Login?email=" + email + "&password=" + pass;
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                    return user;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<HttpResponseMessage> PostRegister(string data)
        {
            try
            {
                string url = "https://10.0.2.2:7004/api/AddUser/";
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                //string data2 = @"{""nome"":""nome"", ""apelido"":""apelido"", ""email"":""email"", ""password"":"" password"",""morada"":"" "", ""telefone"":""tele"", ""emailativo"":""nao"", ""dtnasc"":""dtnasc"", ""tipouser"":2}";

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    //var user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                    return response;
                }
                else
                {
                    return response;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<HttpResponseMessage> UpdateUser(string data, string id, DateTime data1)
        {
            try
            {
                string url = "https://10.0.2.2:7004/api/Users/" + id + "?data1=" + data1;
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                //string data2 = @"{""nome"":""nome"", ""apelido"":""apelido"", ""email"":""email"", ""password"":"" password"",""morada"":"" "", ""telefone"":""tele"", ""emailativo"":""nao"", ""dtnasc"":""dtnasc"", ""tipouser"":2}";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    //var user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                    return response;
                }
                else
                {
                    return response;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<HttpResponseMessage> UpdatePessoaevento(Pessoaevento pessoaevento, string id)
        {
            try
            {
                string url = "https://10.0.2.2:7004/api/Pessoasevento/" + id;
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                //string data2 = @"{""nome"":""nome"", ""apelido"":""apelido"", ""email"":""email"", ""password"":"" password"",""morada"":"" "", ""telefone"":""tele"", ""emailativo"":""nao"", ""dtnasc"":""dtnasc"", ""tipouser"":2}";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

                var content = JsonConvert.SerializeObject(pessoaevento);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PutAsync(url, byteContent);
                if (response.IsSuccessStatusCode)
                {
                    //var user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                    return response;
                }
                else
                {
                    return response;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Pessoasevento2>> GetPessoaeventoAsync(string id, string iduser)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/Pessoasevento/" + id + "?iduser=" + iduser;
                Console.WriteLine(url);
                var response = await client.GetStringAsync(url);
                Console.WriteLine(response);
                var produtos = JsonConvert.DeserializeObject<List<Pessoasevento2>>(response);

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

        public async Task<List<Igreja>> GetIgrejasAsync()
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/Igrejas";
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<List<Igreja>>(response);
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
        public async Task<RootMural> GetMuraisAsync()
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/Mural";
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<RootMural>(response);
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
        public async Task<HttpResponseMessage> AddMurais(string data)
        {
            try
            {
                string url = "https://10.0.2.2:7004/api/AddMural/";
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                //string data2 = @"{""nome"":""nome"", ""apelido"":""apelido"", ""email"":""email"", ""password"":"" password"",""morada"":"" "", ""telefone"":""tele"", ""emailativo"":""nao"", ""dtnasc"":""dtnasc"", ""tipouser"":2}";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    //var user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                    return response;
                }
                else
                {
                    return response;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<RootMsg> GetMensagensAsync(string idemissor, string idrecetor)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/Mensagens/" + idemissor + "?idrecetor=" + idrecetor;
                Console.WriteLine(url);
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<RootMsg>(response);

                return produtos;
            }
            catch (HttpRequestException ex)
            {
                await Shell.Current.GoToAsync("//MainPage");
                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public async Task<RootMsg> GetMensagensListAsync(string idrecetor)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/Mensagens/StatsUser/" + idrecetor;
                Console.WriteLine(url);
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<RootMsg>(response);

                return produtos;
            }
            catch (HttpRequestException ex)
            {
                await Shell.Current.GoToAsync("//MainPage");
                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public async Task<HttpResponseMessage> SendMensagemAsync(string data)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/EnviarMensagem/";
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                return response;
            }
            catch (HttpRequestException ex)
            {
                await Shell.Current.GoToAsync("//MainPage");
                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public async Task<User> GetUserAsync()
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/Users/" + await SecureStorage.GetAsync("iduser");
                var response = await client.GetStringAsync(url);
                var user = JsonConvert.DeserializeObject<User>(response);
                return user;
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
        public async Task<User> GetUserChatAsync(string id)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/Users/" + id;
                var response = await client.GetStringAsync(url);
                var user = JsonConvert.DeserializeObject<User>(response);
                return user;
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

        public async Task<Root> GetVerses(string chapter, string book)
        {
            try
            {
                string url = "https://bible-api.com/" + book + "%20" + chapter + "?verse_numbers=true&translation=almeida";
                var response = await clientFora.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<Root>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Versiculo> GetVersiculo()
        {
            try
            {
                string url = "https://10.0.2.2:7004/api/Vesiculo/";
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<Versiculo>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*public async Task<ImageSource> GetImagemServer(string img)
        {
            try
            {
                var response = await client.GetAsync("https://10.0.2.2:7004/api/getImage?img=" + img);
                byte[] image = await response.Content.ReadAsByteArrayAsync();
                //var imageSource = ImageSource.FromStream(() => new MemoryStream(image));
               // return imageSource;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }*/
        public async Task<RootNoticia> GetNoticiasAsync()
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/Noticias";
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<RootNoticia>(response);
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
        public async Task<Noticia> GetNoticiaAsync(string id)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/Noticias/" + id;
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<Noticia>(response);
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
        public async Task<RootEvento> GetEventosAsync()
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/Eventos";
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<RootEvento>(response);
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
        public async Task<RootDepartamento> GetDepartamentosAsync()
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/Departamentos";
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<RootDepartamento>(response);
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
        public async Task<Departamento> GetDepartamentoAsync(string id)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/Departamentos/" + id;
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<Departamento>(response);
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
        public async Task<List<Responsavel>> GetResponsaveisAsync(int iddepart)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "https://10.0.2.2:7004/api/Responsaveis/" + iddepart.ToString();
                var response = await client.GetStringAsync(url);

                var produtos = JsonConvert.DeserializeObject<List<Responsavel>>(response);
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

