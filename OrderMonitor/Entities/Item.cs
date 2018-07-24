using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderMonitor.RowPart;

namespace OrderMonitor
{
    public class Item
    {
        public string Description { get; set; }
        public double Value { get; set; }
        public float Weight { get; set; }
        public string Currency { get; set; }
        public int Quantity { get; set; }
    }
}
