using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Fetchers;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace soal1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var jsonData = @"
                            {
                                ""id"": 30,
                                ""name"": ""Someone""
                            }
                            ";
            var data = JsonConvert.SerializeObject(jsonData);
           
            var getJsonResponse = await Fetcher.Get("https://httpbin.org/get");
            var deleteJsonResponse = await Fetcher.Delete("https://httpbin.org/delete");
            var postJsonResponse = await Fetcher.Post("https://httpbin.org/post", data);
            var putJsonResponse = await Fetcher.Put("https://httpbin.org/put", data);
            var patchJsonResponse = await Fetcher.Patch("https://httpbin.org/put", data);
            
            
            
            Console.WriteLine("==========PRINT GET=============");
            Console.WriteLine(getJsonResponse);
            Console.WriteLine("==========PRINT DELETE=============");
            Console.WriteLine(deleteJsonResponse);
            Console.WriteLine("==========PRINT POST=============");
            Console.WriteLine(postJsonResponse);
            Console.WriteLine("==========PRINT PUT=============");
            Console.WriteLine(putJsonResponse);
            Console.WriteLine("==========PRINT PATCH=============");
            Console.WriteLine(patchJsonResponse);

        }
    }
}
