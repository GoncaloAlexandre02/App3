using System;
using System.Collections.Generic;
using System.Text;

using System.Net.Http;

namespace App3.Services
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetInsecureHandler();
    }
}
