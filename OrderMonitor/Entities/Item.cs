using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderMonitor.RowPart;
using System.Xml;

namespace OrderMonitor
{
    public class Item : IOutputXML
    {
        public string Description { get; set; }
        public double Value { get; set; }
        public float Weight { get; set; }
        public string Currency { get; set; }
        public int Quantity { get; set; }

        public void CreateNode(XmlWriter writer)
        {
            writer.WriteStartElement("ParcelItem");
            writer.WriteElementString("Description", Description);
            writer.WriteElementString("Value", Value.ToString());
            writer.WriteElementString("Weight", Weight.ToString());
            writer.WriteElementString("Currency", string.IsNullOrEmpty(Currency) ? "GBP" : Currency);
            writer.WriteElementString("Quantity", Quantity.ToString());
            writer.WriteEndElement();
        }
    }
}
