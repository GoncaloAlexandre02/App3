using App3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            clientFora = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
#if DEBUG
            client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
            clientFora = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
#else
            client = new HttpClient();
#endif
            client = new HttpClient();
        }

        public async Task<User> PostLogin(string data, string email, string pass)
        {
            try
            {
                string url = "http://tze.ddns.net:8070/api/Users/Login?email=" + email + "&password=" + pass;
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await clientFora.PostAsync(url, content);
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
                string url = "http://tze.ddns.net:8070/api/AddUser/";
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                //string data2 = @"{""nome"":""nome"", ""apelido"":""apelido"", ""email"":""email"", ""password"":"" password"",""morada"":"" "", ""telefone"":""tele"", ""emailativo"":""nao"", ""dtnasc"":""dtnasc"", ""tipouser"":2}";

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await clientFora.PostAsync(url, content);
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
        public async Task<HttpResponseMessage> UpdatePlano(string data, string id)
        {
            try
            {
                string url = "http://tze.ddns.net:8070/api/Plano/" + id;
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                //string data2 = @"{""nome"":""nome"", ""apelido"":""apelido"", ""email"":""email"", ""password"":"" password"",""morada"":"" "", ""telefone"":""tele"", ""emailativo"":""nao"", ""dtnasc"":""dtnasc"", ""tipouser"":2}";
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await clientFora.PutAsync(url, content);
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
                string url = "http://tze.ddns.net:8070/api/Users/" + id + "?data1=" + data1.ToString("yyyy/MM/dd HH:mm:ss");
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                //string data2 = @"{""nome"":""nome"", ""apelido"":""apelido"", ""email"":""email"", ""password"":"" password"",""morada"":"" "", ""telefone"":""tele"", ""emailativo"":""nao"", ""dtnasc"":""dtnasc"", ""tipouser"":2}";
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await clientFora.PutAsync(url, content);
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
                string url = "http://tze.ddns.net:8070/api/Pessoasevento/" + id;
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                //string data2 = @"{""nome"":""nome"", ""apelido"":""apelido"", ""email"":""email"", ""password"":"" password"",""morada"":"" "", ""telefone"":""tele"", ""emailativo"":""nao"", ""dtnasc"":""dtnasc"", ""tipouser"":2}";
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

                var content = JsonConvert.SerializeObject(pessoaevento);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await clientFora.PutAsync(url, byteContent);
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
        public async Task<HttpResponseMessage> UpdateFavIgreja(string data, string id)
        {
            try
            {
                string url = "http://tze.ddns.net:8070/api/Favigrejas/" + id;
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                //string data2 = @"{""nome"":""nome"", ""apelido"":""apelido"", ""email"":""email"", ""password"":"" password"",""morada"":"" "", ""telefone"":""tele"", ""emailativo"":""nao"", ""dtnasc"":""dtnasc"", ""tipouser"":2}";
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

                var content = new StringContent(data, Encoding.UTF8, "application/json");

                var response = await clientFora.PutAsync(url, content);
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
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Pessoasevento/" + id + "?iduser=" + iduser;
                Console.WriteLine(url);
                var response = await clientFora.GetStringAsync(url);
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
        public async Task<SocialRoot> GetSocialItemsAsync(string tipo)
        {
            try
            {
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Social?tipo=" + tipo;
                Console.WriteLine(url);
                var response = await clientFora.GetStringAsync(url);
                Console.WriteLine(response);
                var produtos = JsonConvert.DeserializeObject<SocialRoot>(response);

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
        public async Task<HttpResponseMessage> UpdateSocial(Social2 social, string id)
        {
            try
            {
                string url = "http://tze.ddns.net:8070/api/Social/" + id;
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                //string data2 = @"{""nome"":""nome"", ""apelido"":""apelido"", ""email"":""email"", ""password"":"" password"",""morada"":"" "", ""telefone"":""tele"", ""emailativo"":""nao"", ""dtnasc"":""dtnasc"", ""tipouser"":2}";
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

                var content = JsonConvert.SerializeObject(social);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await clientFora.PutAsync(url, byteContent);

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

        public async Task<SocialimgRoot> GetSocialImgAsync(string id)
        {
            try
            {
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Social/" + id;
                Console.WriteLine(url);
                var response = await clientFora.GetStringAsync(url);
                Console.WriteLine(response);
                var produtos = JsonConvert.DeserializeObject<SocialimgRoot>(response);

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

        public async Task<Social> PostSocial(string social)
        {
            try
            {
                string url = "http://tze.ddns.net:8070/api/AddSocial/";
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                //string data2 = @"{""nome"":""nome"", ""apelido"":""apelido"", ""email"":""email"", ""password"":"" password"",""morada"":"" "", ""telefone"":""tele"", ""emailativo"":""nao"", ""dtnasc"":""dtnasc"", ""tipouser"":2}";
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

                var content = new StringContent(social, Encoding.UTF8, "application/json");

                var response = await clientFora.PostAsync(url, content);
                var social2 = JsonConvert.DeserializeObject<Social>(await response.Content.ReadAsStringAsync());

                if (response.IsSuccessStatusCode)
                {
                    //var user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
                    return social2;
                }
                else
                {
                    return social2;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<HttpResponseMessage> PostSocialReserva(string social)
        {
            try
            {
                string url = "http://tze.ddns.net:8070/api/AddSocialReserva/";
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                //string data2 = @"{""nome"":""nome"", ""apelido"":""apelido"", ""email"":""email"", ""password"":"" password"",""morada"":"" "", ""telefone"":""tele"", ""emailativo"":""nao"", ""dtnasc"":""dtnasc"", ""tipouser"":2}";
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

                var content = new StringContent(social, Encoding.UTF8, "application/json");

                var response = await clientFora.PostAsync(url, content);

                Console.WriteLine(response);
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
        public async Task<RootIgreja> GetIgrejasAsync()
        {
            try
            {
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Igrejas";
                var response = await clientFora.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<RootIgreja>(response);
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
        public async Task<RootFavigreja> GetIgrejasFavAsync(string id)
        {
            try
            {
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Favigrejas/" + id;
                var response = await clientFora.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<RootFavigreja>(response);
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
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Hinario";
                var response = await clientFora.GetStringAsync(url);
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
        public async Task<RootPlano> GetPlanosAsync(string id)
        {
            try
            {
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Plano/" + id;
                var response = await clientFora.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<RootPlano>(response);
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
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/DescHinario/" + nome;
                var response = await clientFora.GetStringAsync(url);
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
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Mural";
                var response = await clientFora.GetStringAsync(url);
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
        public async Task<HttpResponseMessage> AddBatismo(string data)
        {
            try
            {
                string url = "http://tze.ddns.net:8070/api/AddBatismo/";
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                //string data2 = @"{""nome"":""nome"", ""apelido"":""apelido"", ""email"":""email"", ""password"":"" password"",""morada"":"" "", ""telefone"":""tele"", ""emailativo"":""nao"", ""dtnasc"":""dtnasc"", ""tipouser"":2}";
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await clientFora.PostAsync(url, content);
                Console.WriteLine(response);
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
        public async Task<HttpResponseMessage> AddMurais(string data)
        {
            try
            {
                string url = "http://tze.ddns.net:8070/api/AddMural/";
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                //string data2 = @"{""nome"":""nome"", ""apelido"":""apelido"", ""email"":""email"", ""password"":"" password"",""morada"":"" "", ""telefone"":""tele"", ""emailativo"":""nao"", ""dtnasc"":""dtnasc"", ""tipouser"":2}";
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await clientFora.PostAsync(url, content);
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
        public async Task<HttpResponseMessage> AddPlano(string data)
        {
            try
            {
                string url = "http://tze.ddns.net:8070/api/AddPlano/";
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                //string data2 = @"{""nome"":""nome"", ""apelido"":""apelido"", ""email"":""email"", ""password"":"" password"",""morada"":"" "", ""telefone"":""tele"", ""emailativo"":""nao"", ""dtnasc"":""dtnasc"", ""tipouser"":2}";
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));

                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await clientFora.PostAsync(url, content);
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

        public async Task<RootMsg> GetMensagensUserAsync(string idemissor, string idrecetor)
        {
            try
            {
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Mensagens/User/" + idemissor + "?idrecetor=" + idrecetor;
                Console.WriteLine(url);
                var response = await clientFora.GetStringAsync(url);
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

        public async Task<RootMsg> GetMensagensEventoAsync(string idevento)
        {
            try
            {
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Mensagens/Evento/" + idevento;
                Console.WriteLine(url);
                var response = await clientFora.GetStringAsync(url);
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

        public async Task<RootMsg> GetMensagensSocialAsync(string idsocial)
        {
            try
            {
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Mensagens/Social/" + idsocial;
                Console.WriteLine(url);
                var response = await clientFora.GetStringAsync(url);
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
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Mensagens/StatsUser/" + idrecetor;
                Console.WriteLine(url);
                var response = await clientFora.GetStringAsync(url);
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
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/EnviarMensagem/";
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await clientFora.PostAsync(url, content);
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
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Users/" + await SecureStorage.GetAsync("iduser");
                var response = await clientFora.GetStringAsync(url);
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
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Users/" + id;
                var response = await clientFora.GetStringAsync(url);
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
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<Root>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                //throw ex;
                Verses newVer = new Verses();
                newVer.text = ex.InnerException.ToString();
                newVer.book_id = "gen";
                newVer.verse = 1;
                newVer.chapter = 1;

                return new Root() { verses = new List<Verses>() { newVer }, text = ex.Message };
            }
        }

        public async Task<Versiculo> GetVersiculo()
        {
            try
            {
                string url = "http://tze.ddns.net:8070/api/Vesiculo/";
                var response = await clientFora.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<Versiculo>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ImageSource> GetImagemServer(string img)
        {
            try
            {
                var response = await clientFora.GetAsync("http://tze.ddns.net:8070/api/getImage?img=" + img);
                byte[] image = await response.Content.ReadAsByteArrayAsync();
                var imageSource = ImageSource.FromStream(() => new MemoryStream(image));
                return imageSource;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public async Task<RootNoticia> GetNoticiasAsync()
        {
            try
            {
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Noticias";
                var response = await clientFora.GetStringAsync(url);
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
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Noticias/" + id;
                var response = await clientFora.GetStringAsync(url);
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
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Eventos";
                var response = await clientFora.GetStringAsync(url);
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
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Departamentos";
                var response = await clientFora.GetStringAsync(url);
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
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Departamentos/" + id;
                var response = await clientFora.GetStringAsync(url);
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
                clientFora.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("tokenuser"));
                string url = "http://tze.ddns.net:8070/api/Responsaveis/" + iddepart.ToString();
                var response = await clientFora.GetStringAsync(url);

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

