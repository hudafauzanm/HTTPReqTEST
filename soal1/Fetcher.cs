using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Newtonsoft;

namespace Fetchers
{
    public class Fetcher
    {

        public static async Task<string> Req(string url)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,url);
            HttpResponseMessage response = await client.SendAsync(request);
            
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> Get(string url)
        {
            return Req(url).Result;
        } 

        public static async Task<string> Delete(string url)
        {
            return Req(url).Result;
        }

        
        public static async Task<string> Put(string url,string data)
        {
            var stringContent = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,url);
            HttpResponseMessage response = await client.PutAsync(url,stringContent);
            HttpResponseMessage responses = await client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> Post(string url,string data)
        {
            var stringContent = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,url);
            HttpResponseMessage response = await client.PostAsync(url,stringContent);
            HttpResponseMessage responses = await client.SendAsync(request);
            
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> Patch(string url,string data)
        {
            var stringContent = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,url);
            HttpResponseMessage response = await client.PatchAsync(url,stringContent);
            HttpResponseMessage responses = await client.SendAsync(request);
            
            return await response.Content.ReadAsStringAsync();
        }
    }
}