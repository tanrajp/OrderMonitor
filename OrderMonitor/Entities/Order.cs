using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using OrderMonitor.RowPart;

namespace OrderMonitor
{
    public class Order
    {
        public string OrderNo { get; set; }
        public IList<Consignment> Consignments { get; set; }
        public double TotalValue
        {
            get
            {
                double ret = 0;
                foreach(var consignment in Consignments)
                {
                    foreach (var parcel in consignment.Parcels)
                    {
                        foreach(var item in parcel.Items)
                        {
                            ret += (item.Value * (double)item.Quantity);
                        }
                    }
                }

                return ret;
            }
        }

        public float TotalWeight
        {
            get
            {
                float ret = 0;
                foreach (var consignment in Consignments)
                {
                    foreach (var parcel in consignment.Parcels)
                    {
                        foreach (var item in parcel.Items)
                        {
                            ret += (item.Weight * (float)item.Quantity);
                        }
                    }
                }

                return ret;
            }
        }

        public Order()
        {
            Consignments = new List<Consignment>();
        }
    }

    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Map(x => x.OrderNo).Name("Order No");
            Map(x => x.Consignments).Ignore();
        }
    }
}
