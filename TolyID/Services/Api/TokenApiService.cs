using TolyID.Constants;
using TolyID.Services.Api.Gerar;

namespace TolyID.Services.Api;

public class TokenApiService : BaseApi
{
    private readonly GerarTokenApiService _gerarTokenApiService;

    public TokenApiService(GerarTokenApiService gerarTokenApiService)
    {
        _gerarTokenApiService = gerarTokenApiService;
    }

    public async Task GeraToken(string email, string senha)
    {
        string token = await _gerarTokenApiService.Gerar(email, senha);
        await SecureStorage.SetAsync(AppConstants.SECURE_STORAGE_API_TOKEN_KEY, token);
    }
}
