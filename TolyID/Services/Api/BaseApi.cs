using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TolyID.Services.Api
{
    public class BaseApi
    {
        public string UrlBaseApi { get; private set; } = "http://172.20.10.6";
        public string EmailBaseApi { get; private set; } = "guilherme@toly.com";
        public string SenhaBaseApi { get; private set; } = "123456";
    }
}
