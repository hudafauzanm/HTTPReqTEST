using System;
using HtmlAgilityPack;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace soal5
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var html = @"https://www.kompas.com//";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var node = htmlDoc.DocumentNode.SelectNodes("//a[contains(@class, 'headline__thumb__link')]");
            foreach (var cek in node)
            {  
               var att = cek.Attributes["href"].Value;
               Console.WriteLine(" Title : "+cek.InnerText.Trim()+" \n" +" URL : " + att);
            }
        }
    }
}
