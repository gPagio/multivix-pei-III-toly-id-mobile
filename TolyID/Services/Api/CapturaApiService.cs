using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TolyID.MVVM.Models;
using TolyID.Services.Api.Cadastrar;

namespace TolyID.Services.Api
{
    public static class CapturaApiService
    {
        public static async Task Cadastrar()
        {
            try
            {
                var bancoCaptura = new CapturaService();
                var apiCaptura = new CadastrarCapturaApiService();
                var token = await TokenApiService.Gerar();

                List<Captura> listaCaptura = await bancoCaptura.GetCapturaNaoCadastrados();

                foreach (var captura in listaCaptura)
                {
                    if (captura.FoiEnviadoParaApi == false)
                    {
                        await apiCaptura.Cadastrar( captura, token);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
