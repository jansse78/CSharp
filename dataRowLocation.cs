using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp1
{
    [Serializable()]
    public class Location : ISerializable
    {
        public string region { get; set; }
        public string country { get; set; }

        public Location()
        {

        }
        public Location(string region, string country)
        {
            this.region = region;
            this.country = country;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Region", this.region);
            info.AddValue("Country", this.country);
        }
    }
}
