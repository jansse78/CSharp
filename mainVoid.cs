using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrStock;
            
            CsvReader lukija = new CsvReader(@"C:\Users\jansse\Desktop\repos\testSalesRecord.csv");
            DataContainer varasto = new DataContainer(lukija.getRowCount());
            lukija.uploadData(varasto);
            Array.Sort(varasto.container);
            DataConverter dc = new DataConverter(varasto.container);
            dc.doSingle();
            Thread tBinary = new Thread(new ThreadStart(dc.doMulti));
            tBinary.Start();
            dc.doSingleXml();
            Thread tXml = new Thread(new ThreadStart(dc.doMultiXML));
            tXml.Start();

            Thread tJson = new Thread(new ThreadStart(dc.doMultiJson));
            tJson.Start();

            ExcelHandler xlApp = new ExcelHandler();
            for (int i = 0; i < 11; i++)
            {
                Double[] arrOrderIds = varasto.getRandomOrderIds(1000);
                string[,] dArr = varasto.populateArrVals(arrOrderIds);

                xlApp.addWorkBook($"randomData{i}.xlsx");
                xlApp.renameSheet("data");
                xlApp.writeStrArray(dArr, 1000, 14);
                xlApp.saveXlWb($"C:\\Users\\jansse\\Desktop\\repos\\data\\xlResult{i}.xlsx");
            }
            xlApp.closeXlApp();

            //scraping some data from the internet but didnt get up anything that Id like to do with it...
            Scraper webScraper = new Scraper();
            webScraper.scrapeData();
            Console.WriteLine($"Valmis:{string.Format("{0:HH:mm:ss tt}", DateTime.Now)}");
            Console.ReadLine();
        }
    }
}
