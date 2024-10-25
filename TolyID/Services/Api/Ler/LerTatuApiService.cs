using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TolyID.MVVM.Models;
using static System.Net.WebRequestMethods;

namespace TolyID.Services.Api.Ler
{
    public class LerTatuApiService:BaseApi
    {
        private async Task<List<Tatu>> ReceberTatus(string token)
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
                        List<Tatu> res = JsonConvert.DeserializeObject<List<Tatu>>(jsonResponse);
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
