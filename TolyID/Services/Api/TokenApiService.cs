using TolyID.Services.Api.Gerar;

namespace TolyID.Services.Api;

public class TokenApiService : BaseApi
{
    public async Task<string> Gerar()
    {
        var token = new GerarTokenApiService();
        return await token.Gerar();
    }
}
