using ConsoleTolyID;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TolyID.MVVM.Models;

namespace TolyID.Services.Api
{
    public class CadastrarCapturaApi
    {
        public async void CadastrarCaptura(Captura captura) 
        {
            //string json = JsonConvert.SerializeObject(captura, Formatting.Indented);

            try
            {
                string url = "http://172.20.10.6:8080/captura/cadastrar";
                string token = await GerarToken.Gerar();

                if (string.IsNullOrEmpty(token))
                {
                    Debug.WriteLine("Token inválido.");
                    return;
                }

                var content = new StringContent(JsonConvert.SerializeObject(captura), Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        captura.FoiEnviadoParaApi = true;
                        var banco = new CapturaService();
                        await banco.AtualizaCaptura(captura);
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine($"Erro: {response.StatusCode} - {errorMessage}");
                    }
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
