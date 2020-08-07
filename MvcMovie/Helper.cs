using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MvcMovie.Web.Helper
{
    public class MovieApi
    {
        private const string ApiBaseUri = "http://localhost:42407";

        public static HttpClient InitializeClient()
        {
            var client = new HttpClient { BaseAddress = new Uri(ApiBaseUri) };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
