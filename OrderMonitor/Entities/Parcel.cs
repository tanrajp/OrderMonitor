using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderMonitor.RowPart;

namespace OrderMonitor
{
    public class Parcel
    {
        public string ParcelCode { get; set; }
        public IList<Item> Items { get; set; }

        public Parcel()
        {
            Items = new List<Item>();
        }
    }
}
