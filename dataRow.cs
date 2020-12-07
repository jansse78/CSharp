using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace ConsoleApp1
{
    [Serializable()]
    public class DataRow: IComparable<DataRow>, ISerializable
    {
        public Location location { get; set; }
        public string itemType { get; set; }
        public string salesChannel { get; set; }
        public string orderPrio { get; set; }
        public DateTime orderDate { get; set; }
        public double orderId { get; set; }
        public DateTime shipDate { get; set; }
        public double unitsSold { get; set; }
        public float unitPrice { get; set; }
        public float unitCost { get; set; }
        public float totalRevenue { get; set; }
        public float totalCost { get; set; }
        public float totalProfit { get; set; }

        public DataRow()
        {
        }
        public DataRow(string country, string region)
        {
            location = new Location(region, country);
        }
        public DataRow(string reg, string countr, string item_type, string sale_Channel, string order_prio, DateTime order_date, double order_id, DateTime ship_date, double units_sold, float unit_price, float unit_cost, float total_revenue, float total_cost, float total_profit)
        {
            location = new Location(reg,countr);
            itemType = item_type;
            salesChannel = sale_Channel;
            orderPrio = order_prio;
            orderDate = order_date;
            orderId = order_id;
            shipDate = ship_date;
            unitsSold = units_sold;
            unitPrice = unit_price;
            unitCost = unit_cost;
            totalRevenue = total_revenue;
            totalCost = total_cost;
            totalProfit = total_profit;
        }

        public int CompareTo(DataRow otherData)
        {   
            if (otherData != null)
            {

            }
            return this.orderId.CompareTo(otherData.orderId);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Location", location);
            info.AddValue("ItemType", itemType);
            info.AddValue("SalesChannel", salesChannel);
            info.AddValue("OrderPrio", orderPrio);
            info.AddValue("OrderDate", orderDate);
            info.AddValue("OrderId", orderId);
            info.AddValue("shipDate", shipDate);
            info.AddValue("unitsSold", unitsSold);
            info.AddValue("unitPrice", unitPrice);
            info.AddValue("unitCost", unitCost);
            info.AddValue("totalRevenue", totalRevenue);
            info.AddValue("totalCost", totalCost);
            info.AddValue("totalProfit", totalProfit);
        }
        public DataRow(SerializationInfo info, StreamingContext context)
        {
            location = (Location)info.GetValue("Location", typeof(Location));
            itemType = (string)info.GetValue("ItemType", typeof(string));
            salesChannel = (string)info.GetValue("SalesChannel", typeof(string));
            orderPrio = (string)info.GetValue("OrderPrio", typeof(string));
            orderDate = (DateTime)info.GetValue("region", typeof(DateTime));
            orderId = (double)info.GetValue("region", typeof(double));
        }

        public void addRow(int x, string[,] dArr)
        {
            dArr[x, 0] = location.country;
            dArr[x, 1] = location.region;
            dArr[x, 2] = itemType;
            dArr[x, 3] = salesChannel;
            dArr[x, 4] = orderPrio;
            dArr[x, 5] = orderDate.ToString("dd.MM.yyyy");
            dArr[x, 6] = orderId.ToString();
            dArr[x, 7] = shipDate.ToString("dd.MM.yyyy");
            dArr[x, 8] = unitsSold.ToString();
            dArr[x, 9] = unitPrice.ToString();
            dArr[x, 10] = unitCost.ToString();
            dArr[x, 11] = totalRevenue.ToString();
            dArr[x, 12] = totalCost.ToString();
            dArr[x, 13] = totalProfit.ToString();
        }

    }
}
