namespace TolyID.Services.Api;

public class BaseApi
{
    public string UrlBaseApi { get; private set; } 
    public string EmailBaseApi { get; private set; } = "guilherme@toly.com";
    public string SenhaBaseApi { get; private set; } = "123456";

    public BaseApi() 
    {
        ReceberRota();
    }

    public void ReceberRota()
    {
        UrlBaseApi = Preferences.Get("endereco_ip_api", "");
    }
}
