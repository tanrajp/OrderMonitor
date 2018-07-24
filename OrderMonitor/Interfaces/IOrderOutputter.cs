using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using OrderMonitor;

namespace OrderMonitor.Interfaces
{
    public interface IOrderOutputter
    {
        void CreateDocument(IList<Order> orders, string directory, string filename);
    }

    public class XmlOrderOutputter : IOrderOutputter
    {
        public void CreateDocument(IList<Order> orders, string directory, string filename)
        {
            using (XmlWriter writer = XmlWriter.Create($"{directory}\\{filename}.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Orders");

                foreach (var order in orders)
                {
                    order.CreateNode(writer);
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
