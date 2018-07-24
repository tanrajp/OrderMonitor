using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using OrderMonitor.RowPart;

namespace OrderMonitor
{
    public class Consignment
    {
        public string ConsignmentNo { get; set; }
        public string ConsigneeName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }
        public IList<Parcel> Parcels { get; set; }

        public Consignment()
        {
            Parcels = new List<Parcel>();
        }
    }

    public class ConsignmentMap : ClassMap<Consignment>
    {
        public ConsignmentMap()
        {
            Map(x => x.ConsignmentNo).Name("Consignment No");
            Map(x => x.ConsigneeName).Name("Consignee Name");
            Map(x => x.Address1).Name("Address 1");
            Map(x => x.Address2).Name("Address 2");
            Map(x => x.City).Name("City");
            Map(x => x.State).Name("State");
            Map(x => x.CountryCode).Name("Country Code");
        }
    }
}
