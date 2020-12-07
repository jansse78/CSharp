using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Scraper
    {

        public string html { get; set; }
        public HtmlDocument htmlDoc { get; set; }
        private String[] arrStocks;

        public String[] ArrStocks
        {
            get { return arrStocks; }
            set { arrStocks = value; }
        }


        public void scrapeData()
        {
            getHtml();
            
        }

        private void parseHtml()
        {
            HtmlNode startlevel = htmlDoc.DocumentNode.SelectSingleNode(@"//body/main/section");
            HtmlNode colDiv = startlevel.SelectSingleNode("//ul[@class='module-body wsod most-popular-stocks']");
            HtmlNodeCollection rows = colDiv.SelectNodes("//a[@class='stock']");
            this.arrStocks = new String[rows.Count];
            int i = 0;
            foreach (HtmlNode rivi in rows)
            {
                HtmlNode[] spans = rivi.ChildNodes.ToArray();
                this.arrStocks[i] = $"{spans[1].InnerText},{spans[3].InnerText},{spans[5].InnerText}";
                i++;
            }
        }

        public async void getHtml()
        {
            string url = "https://money.cnn.com/data/markets/";
            HttpClient httpClient = new HttpClient();
            html = await httpClient.GetStringAsync(url);

            htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            parseHtml();

            Console.ReadLine();
        }
    }
}
