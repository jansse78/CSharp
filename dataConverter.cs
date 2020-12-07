using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace dataMiner
{
    public class DataConverter
    {
        public DataRow[] arrData;

        public DataConverter(DataRow[] arrData)
        {
            this.arrData = arrData;
        }

        public void doSingle()
        {
            Stream stream = File.Open(@"C:\Users\jansse\Desktop\repos\data\dataRow.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, arrData[0]);
            stream.Close();
        }
        public void doMulti()
        {
            using (Stream fs = new FileStream(@"C:\Users\jansse\Desktop\repos\data\dataRow.dat", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, arrData);
            }
        }

        public void doMultiJson()
        {
            using (Stream fs = new FileStream(@"C:\Users\jansse\Desktop\repos\data\dataRows.json", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    using (JsonWriter jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Formatting.Indented;
                        JsonSerializer jsonSer = new JsonSerializer();
                        jsonSer.Serialize(jw, arrData);
                    }
                }
            }
        }

        public void doSingleXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataRow));

            using (TextWriter tw = new StreamWriter(@"C:\Users\jansse\Desktop\repos\data\dataRow.xml"))
            {
                serializer.Serialize(tw, arrData[0]);
            }
        }

        public void doMultiXML()
        {
            using (Stream fs = new FileStream(@"C:\Users\jansse\Desktop\repos\data\dataRows.xml", FileMode.Create))
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(DataRow[]));
                xmlSer.Serialize(fs, arrData);
            }
        }


    }
}
}
