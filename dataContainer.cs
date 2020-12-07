using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace dataMiner
{
    public class DataContainer
    {
        public DataRow[] container;
        private int arrPosition;
        public int nulVals;

        public DataContainer(int containerSize)
        {
            arrPosition = 0;
            container = new DataRow[containerSize];
        }

        //public DataRow[] Container { get; set; }

        public void addToContainer(DataRow dataRow)
        {
            container[this.arrPosition] = dataRow;
            arrPosition++;
        }

        public void orderByOrderID()
        {
            Array.Sort(container);
        }
        public void findNulls()
        {
            for (int i = 0; i < container.Length; i++)
            {
                if (container[i] == null)
                {
                    nulVals++;
                }
            }
            Console.ReadLine();
        }

        public DataRow[] populateArr(Double[] dArr)
        {
            DataRow[] retArr = new DataRow[dArr.Length];
            int b;

            for (int i = 0; i < dArr.Length; i++)
            {
                retArr[i] = binSearch(dArr[i]);
                b = 1;
            }

            return retArr;
        }

        public string[,] populateArrVals(Double[] dArr)
        {
            String[,] retArr = new String[dArr.Length, 14];

            for (int i = 0; i < dArr.Length; i++)
            {
                DataRow dRow = binSearch(dArr[i]);
                dRow.addRow(i, retArr);
            }

            return retArr;
        }

        public DataRow binSearch(double valToSearch)
        {
            int midPos;
            int startPos = 0;
            int endPos = container.Length - 1;

            while (startPos <= endPos)
            {
                midPos = (startPos + endPos) / 2;

                if (valToSearch == container[midPos].orderId)
                {
                    return container[midPos];
                }
                else if (valToSearch < container[midPos].orderId)
                {
                    endPos = midPos - 1;
                }
                else
                {
                    startPos = midPos + 1;
                }
            }
            return null;
        }

        public Double[] getRandomOrderIds(int valAmmount)
        {
            Random rand = new Random();
            Double[] arrReturn = new Double[valAmmount];
            int fillRate = 0;

            while (fillRate < arrReturn.Length)
            {
                arrReturn[fillRate] = container[rand.Next(0, 1499999)].orderId;
                fillRate++;
            }

            return arrReturn;
        }

    }
}
