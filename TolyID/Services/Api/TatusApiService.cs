using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TolyID.MVVM.Models;
using TolyID.Services.Api.Cadastrar;
using TolyID.Services.Api.Ler;

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
        public static async Task AtualizarTatus()
        {
            var token = await TokenApiService.Gerar();
            var lerTatu = new LerTatuApiService();
            var bancoTatu = new TatuService();

            var lista = await bancoTatu.GetTatus();
            var listaApi = await lerTatu.Ler(token);

            await DeletarTatus(listaApi);

            foreach (var tatu in listaApi)
            {
                bool existe = await bancoTatu.VerificarExistencia(tatu);

                if (existe)
                {
                    // O Tatu existe no banco de dados
                }
                else
                {
                    tatu.FoiEnviadoParaApi = true;
                    await bancoTatu.SalvaTatu(tatu);
                }
            }
        }
        private static async Task DeletarTatus(List<Tatu> tatusRecebidosPelaApi)
        {
            var bancoTatu = new TatuService();
            await bancoTatu.DeletarTatusForaDaApi(tatusRecebidosPelaApi); //deve-se enviar a lista de Tatus que estao na api
        }

    }
}
