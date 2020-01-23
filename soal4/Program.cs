using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace soal4
{
    class Program
    {
        public static async Task<string> Movies()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,"https://api.themoviedb.org/3/search/movie?api_key=8ade8bea9d0c658c52b0c7e7e2991de9&language=id&query=Indonesia&page=1&include_adult=true&region=id-ID");
            HttpResponseMessage response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

        public static async Task<string> Keanu()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,"https://api.themoviedb.org/3/search/person?api_key=8ade8bea9d0c658c52b0c7e7e2991de9&language=en-US&query=Keanu&page=1&include_adult=false");
            HttpResponseMessage response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return json;   
        }
        public static async Task<string> Robert()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,"https://api.themoviedb.org/3/discover/movie?api_key=8ade8bea9d0c658c52b0c7e7e2991de9&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&with_cast=1136406%2C3223");
            HttpResponseMessage response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return json;   
        }
        public static async Task<string> List()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,"https://api.themoviedb.org/3/discover/movie?api_key=8ade8bea9d0c658c52b0c7e7e2991de9&language=en-US&sort_by=vote_count.desc&include_adult=false&include_video=false&page=1&primary_release_year=2016&vote_count.lte=7.5");
            HttpResponseMessage response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            return json;   
        }
        public static async Task Main(string[] args)
        {
           Console.WriteLine("==============Get 10+ titles of Indonesian movies================");
           Console.WriteLine(await Movies()); 
           Console.WriteLine("===============Get movie list played by Keanu Reeves=============");
           Console.WriteLine(await Keanu());
           Console.WriteLine("===============Get movie list played by Robert Downey Jr. and Tom Holland=============");
           Console.WriteLine(await Robert());
           Console.WriteLine("===============Get popular movie list that released on 2016 and the votes above 7.5=============");
           Console.WriteLine(await List());
           
           
            
        }
    }
}
