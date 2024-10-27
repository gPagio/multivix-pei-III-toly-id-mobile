

using System.Text;
using TolyID.Services.Api.Gerar;

namespace TolyID.Services.Api;

public class TokenApiService:BaseApi
{
    public async static Task<string> Gerar()
    {
        var token = new GerarTokenApiService();
        return await token.Gerar();
    }
}
