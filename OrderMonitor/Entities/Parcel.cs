using System.Collections.Generic;
using OrderMonitor.RowPart;
using System.Xml;

namespace OrderMonitor
{
    public class Parcel : IOutputXML
    {
        public string ParcelCode { get; set; }
        public IList<Item> Items { get; set; }

        public Parcel()
        {
            Items = new List<Item>();
        }

        public void CreateNode(XmlWriter writer)
        {
            writer.WriteStartElement("Parcel");
            writer.WriteElementString("ParcelCode", ParcelCode);

            writer.WriteStartElement("ParcelItems");
            foreach(var item in Items)
            {
                item.CreateNode(writer);
            }
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
    }
}
