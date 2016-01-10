using System;
using System.Net.Http;

namespace FourthWall.Server.Test.Acceptance
{
    public class TestClient
    {
        public HttpClient HttpClient { get; set; }

        public TestClient(string baseUrl)
        {
            HttpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public HttpResponseMessage Get(string url)
        {
            return HttpClient.GetAsync(url).Result;
        }

        public string GetString(string url)
        {
            return HttpClient.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }

        public byte[] GetBytes(string url)
        {
            return HttpClient.GetAsync(url).Result.Content.ReadAsByteArrayAsync().Result;
        }
    }
}