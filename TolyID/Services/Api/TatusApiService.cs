using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TolyID.MVVM.Models;
using TolyID.Services.Api.Cadastrar;

namespace TolyID.Services.Api
{
    public static class TatusApiService
    {
        public static async Task Cadastrar()
        {
            try
            {
                var bancoTatu = new TatuService();
                var apiTatu = new CadastrarTatuApiService();
                var token = await TokenApiService.Gerar();

                List<Tatu> listaTatu = await bancoTatu.GetTatusNaoCadastrados();
                foreach (var tatu in listaTatu)
                {
                    if (!tatu.FoiEnviadoParaApi)
                    {
                        await apiTatu.Cadastrar(tatu, token);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
        public static async Task Receber()
        {

        }

    }
}
