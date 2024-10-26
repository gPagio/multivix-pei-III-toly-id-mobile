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
        //formato "192.168.1.111"
        public string UrlBaseApi { get; private set; } = "192.168.1.111";
        public string EmailBaseApi { get; private set; } = "guilherme@toly.com";
        public string SenhaBaseApi { get; private set; } = "123456";
    }
}
