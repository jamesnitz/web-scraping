using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            GetHtmlAsync();
            Console.ReadLine();
            
        }
        private static async void GetHtmlAsync()
        {
             var url = "https://www.ebay.com/sch/i.html?_from=R40&_trksid=p2380057.m570.l1313.TR12.TRC2.A0.H0.Xxbox+one.TRS0&_nkw=xbox+one&_sacat=0";
            
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var Products = htmlDocument.DocumentNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("ListViewInner")).ToList();
            var ProductListItems = Products[0].Descendants("li")
                .Where(node => node.GetAttributeValue("id", "")
                .Contains("item")).ToList();


            //var ProductList = Products[0].Descendents();
            Console.WriteLine();
             
        }

        }
    }