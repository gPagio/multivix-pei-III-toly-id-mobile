using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TolyID.MVVM.Models;

namespace TolyID.Services.Api.Ler
{
    public class LerTatuApiService : BaseApi
    {
        public async Task<List<Tatu>> Ler(string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"http://{UrlBaseApi}:8080/tatus/listar";
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var contentArray = JObject.Parse(jsonResponse)["content"].ToString();
                        List<Tatu> res = JsonConvert.DeserializeObject<List<Tatu>>(contentArray);
                        return res;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
