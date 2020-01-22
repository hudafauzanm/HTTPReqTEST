using System;
using System.Net.Http;
using Newtonsoft.Json;
using Employess;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace soal2
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,"https://mul14.github.io/data/employees.json");
            HttpResponseMessage response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();

            
            var list = JsonConvert.DeserializeObject<List<Employee>>(json);

            Console.WriteLine("==========Find employees which have salary more than Rp15.000.000============");
            var salary = from l in list where (l.salary > 15000000) select new{l.first_name,l.last_name};

            foreach(var s in salary)
            {
                Console.WriteLine("Nama : "+s.first_name + " " + s.last_name);
            }

            Console.WriteLine("==========Find employees which life in Jakarta============");
            var jak = from l in list from x in l.Addresses where (x.city == "DKI Jakarta") select new{l.first_name,l.last_name};

            foreach(var j in jak.Distinct())
            {
                Console.WriteLine("Nama : "+j.first_name + " " + j.last_name);
            }

            Console.WriteLine("==========Find employees which birthday on March============");
            var birth = from l in list where ((l.birthday).Month == 3) select new{l.first_name,l.last_name};

            foreach(var b in birth)
            {
                Console.WriteLine("Nama : "+b.first_name + " " + b.last_name);
            }

            Console.WriteLine("==========Find employees in Research and Development departement============");
            var rd = from l in list where (l.Department.name == "Research and development") select new{l.first_name,l.last_name};

            foreach(var r in rd)
            {
                Console.WriteLine("Nama : "+r.first_name + " " + r.last_name);
            }

            Console.WriteLine("==========Find how many each employee absences in October 2019============");
            
            var oct = from l in list from x in l.presence_list where (x.Contains("2019-10"))  select l.first_name;
            
            Dictionary<string,int> bulan = oct.GroupBy(bulan => bulan).ToDictionary(i => i.Key,i => i.Count());

            foreach(var b in bulan)
            {
                Console.WriteLine("Nama : "+b.Key +" " +"Jumlah : " + b.Value);
            } 
        }
    }
}
