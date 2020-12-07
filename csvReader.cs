using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace dataMiner
{
    public class CsvReader
    {
        private string fileUrl;
        private DataContainer varasto;
        private StreamReader sr;
        public CsvReader(string file_Url)
        {
            this.fileUrl = file_Url;
            sr = new StreamReader(this.fileUrl);
        }

        public int getRowCount()
        {
            int rowsCount = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                rowsCount++;
            }

            return rowsCount - 1;
        }

        public void uploadData(DataContainer varasto)
        {
            sr.DiscardBufferedData();
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            CultureInfo provider = new CultureInfo("en-US");
            while (!sr.EndOfStream)
            {
                string[] entries = sr.ReadLine().Split(',');
                if (!entries[0].Equals("Region"))
                {
                    DataRow dataEntry = new DataRow(entries[0], entries[1]);
                    //checkArr(entries);
                    dataEntry.region = entries[0];
                    dataEntry.country = entries[1];
                    dataEntry.itemType = entries[2];
                    dataEntry.salesChannel = entries[3];
                    dataEntry.orderPrio = entries[4];
                    dataEntry.orderDate = DateTime.Parse(entries[5], provider.DateTimeFormat);
                    dataEntry.orderId = Double.Parse(entries[6]);
                    dataEntry.shipDate = DateTime.Parse(entries[7], provider.DateTimeFormat);
                    dataEntry.unitsSold = Double.Parse(entries[8]);
                    dataEntry.unitPrice = float.Parse(entries[9], provider);
                    dataEntry.unitCost = float.Parse(entries[10], provider);
                    dataEntry.totalRevenue = float.Parse(entries[11], provider);
                    dataEntry.totalCost = float.Parse(entries[12], provider);
                    dataEntry.totalProfit = float.Parse(entries[13], provider);
                    varasto.addToContainer(dataEntry);
                }
            }
        }

        private void checkArr(string[] arrVal)
        {
            for (int i = 0; i < arrVal.Length; i++)
            {
                Console.WriteLine($"paikka{i}:{arrVal[i]}");
            }
        }
    }
}
