using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace ConsoleApp1
{
    class ExcelHandler
    {
        private Application xlApp;
        private _Workbook xlWb;
        private _Worksheet xlWs;

        public ExcelHandler()
        {
            xlApp = new Application();
            xlApp.Visible = true;
        }

        public void addWorkBook(string strName)
        {
            xlWb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            string shtName = xlWb.Sheets[1].name;
            xlWs = (Worksheet)xlApp.Worksheets[shtName];
        }

        public void renameSheet(string strName)
        {
            xlWs.Name = strName;
        }

        public void writeToSheet(int x, int y, string strVal)
        {
            xlWs.Cells[x, y] = strVal;  
        }

        public void writeToCell(int x, DataRow val)
        {
            xlWs.Cells[x, 1].Value2 = val.location.country;
            xlWs.Cells[x, 2].Value2 = val.location.region;
            xlWs.Cells[x, 3].Value2 = val.itemType;
            xlWs.Cells[x, 4].Value2 = val.salesChannel;
            xlWs.Cells[x, 5].Value2 = val.orderPrio;
            xlWs.Cells[x, 6].Value2 = val.orderDate;
            xlWs.Cells[x, 7].Value2 = val.orderId;
            xlWs.Cells[x, 8].Value2 = val.shipDate;
            xlWs.Cells[x, 9].Value2 = val.unitsSold;
            xlWs.Cells[x, 10].Value2 = val.unitPrice;
            xlWs.Cells[x, 11].Value2 = val.unitCost;
            xlWs.Cells[x, 12].Value2 = val.totalRevenue;
            xlWs.Cells[x, 13].Value2 = val.totalCost;
            xlWs.Cells[x, 14].Value2 = val.totalProfit;
        }

        public void writeObjArray(DataRow[] dArr)
        {
            for (int i = 0; i < dArr.Length;i++)
            {
                writeToCell(i + 1, dArr[i]);
            }
        }
        public void writeStrArray(string[,] dArr, int rows, int cols)
        {
            Range startRng = (Range)xlWs.Cells[1, 1];
            Range endRng = (Range)xlWs.Cells[rows, cols];
            Range writeRng = xlWs.Range[startRng, endRng];

            writeRng.Value2 = dArr;
        }

        public void saveXlWb(string path)
        {
            xlWb.SaveAs(path);
            closeXlWb();
        }

        public void closeXlWb()
        {
            xlWb.Close();
        }

        public void closeXlApp()
        {
            xlApp.Quit();
        }
    }
}
