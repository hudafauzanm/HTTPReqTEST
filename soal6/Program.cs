using System;
using PuppeteerSharp;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace soal6
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true
                });
            var page = await browser.NewPageAsync();
            await page.GoToAsync("https://www.cgv.id/en/movies/now_playing");
            
            var movie = await page.QuerySelectorAllHandleAsync(".movie-list-body > ul > li > a").EvaluateFunctionAsync<string[]>("elements => elements.map(a => a.href)");
            await page.CloseAsync();

            for(int i = 1 ; i <= movie.Length;i++)
            {
                var html = $"{movie[i-1]}";
                HtmlWeb web = new HtmlWeb();
                var htmlDoc = web.Load(html);
                var node = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'movie-info-title')]");
                var konten = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'movie-add-info left')]/ul/li");
                var trailer = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'trailer-btn-wrapper')]/img");
                var sinopsis = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'movie-synopsis right')]");
                Console.WriteLine("=======================================================================BATAS FILM TERBARU==============================================================");
                foreach(var x in node)
                {
                    Console.WriteLine(x.InnerText.Trim().ToUpper()+"\n");
                }
                foreach(var y in konten)
                {
                    Console.WriteLine(y.InnerText.Trim());
                }
                foreach(var z in trailer)
                {
                    var hasil = z.Attributes["onclick"].Value;
                   //Console.WriteLine(hasil.Length);
                   Console.WriteLine( "TRAILER : "+hasil.Replace("'","").Replace("(","").Replace(")","").Replace("playTrailer","").Replace("<","").Replace("=","").Replace("iframe","").Replace("src","").Replace("width",""));
                }
                foreach(var b in sinopsis)
                {
                    Console.WriteLine("SINOPSIS " +"\n"+b.InnerText.Trim());
                }
            }
            
        }
    }
}
