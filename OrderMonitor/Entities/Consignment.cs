using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
