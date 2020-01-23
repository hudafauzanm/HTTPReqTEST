using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Profiles;
using Items;
using Users;

namespace soal3
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,"https://jsonplaceholder.typicode.com/posts");
            HttpRequestMessage request2 = new HttpRequestMessage(HttpMethod.Get,"https://jsonplaceholder.typicode.com/users");
            HttpResponseMessage response = await client.SendAsync(request);
            HttpResponseMessage response2 = await client.SendAsync(request2);

            var json = await response.Content.ReadAsStringAsync();
            var json2 = await response2.Content.ReadAsStringAsync();

            var list = JsonConvert.DeserializeObject<List<Posts>>(json);
            var list2 = JsonConvert.DeserializeObject<List<User>>(json2);

            List<Data> data = new List<Data>();
            foreach(var x in list)
            {
                foreach(var y in list2)
                {
                 if(x.userId == y.id)
                 {
                  
                  data.Add(new Data()
                  {
                    userID = x.userId,
                    id = x.id,
                    title = x.title,
                    body = x.body,
                    User = y,
                  });
                //   foreach(var d in data)
                //    {
                //      Console.WriteLine(d.User);
                //     }
                 }
                }
            }

            var hasil = JsonConvert.SerializeObject(data,Formatting.Indented);
            Console.WriteLine(hasil);

        }
    }
}
