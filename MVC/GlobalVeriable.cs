using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVC
{
    public static class GlobalVeriable
    {
        public static HttpClient webApiClient = new HttpClient();

        static GlobalVeriable()
        {
            webApiClient.BaseAddress = new Uri("https://localhost:44326/api/");
            webApiClient.DefaultRequestHeaders.Clear();

            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


    }
}