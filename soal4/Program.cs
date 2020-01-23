using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using Results;
using System.Collections.Generic;
using System.Linq;

namespace soal4
{
    class Program
    {
        public static async Task Movies()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,"https://api.themoviedb.org/3/search/movie?api_key=8ade8bea9d0c658c52b0c7e7e2991de9&language=id&query=Indonesia&page=1&include_adult=true&region=id-ID");
            HttpResponseMessage response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<Data>(json);

            var movies = from l in list.results select l.original_title;

            foreach(var m in movies)
            {
                Console.WriteLine("Judul : "+m);
            }
        }

        public static async Task Keanu()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,"https://api.themoviedb.org/3/discover/movie?api_key=8ade8bea9d0c658c52b0c7e7e2991de9&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&with_cast=6384");
            HttpResponseMessage response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<Data>(json);

            var movies = from l in list.results select l.original_title;

            foreach(var m in movies)
            {
                Console.WriteLine("Judul : "+m);
            }   
        }
        public static async Task Robert()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,"https://api.themoviedb.org/3/discover/movie?api_key=8ade8bea9d0c658c52b0c7e7e2991de9&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&with_cast=1136406%2C3223");
            HttpResponseMessage response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<Data>(json);

            var movies = from l in list.results select l.original_title;

            foreach(var m in movies)
            {
                Console.WriteLine("Judul : "+m);
            }      
        }
        public static async Task List()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,"https://api.themoviedb.org/3/discover/movie?api_key=8ade8bea9d0c658c52b0c7e7e2991de9&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&primary_release_year=2016&vote_average.gte=7.5");
            HttpResponseMessage response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<Data>(json);

            var movies = from l in list.results select l.title;

            foreach(var m in movies)
            {
                Console.WriteLine("Judul : "+m);
            }   
        }
        public static async Task Main(string[] args)
        {
           Console.WriteLine("==============Get 10+ titles of Indonesian movies================");
           await Movies(); 
           Console.WriteLine("===============Get movie list played by Keanu Reeves=============");
           await Keanu();
           Console.WriteLine("===============Get movie list played by Robert Downey Jr. and Tom Holland=============");
           await Robert();
           Console.WriteLine("===============Get popular movie list that released on 2016 and the votes above 7.5=============");
           await List();
            
        }
    }
}
