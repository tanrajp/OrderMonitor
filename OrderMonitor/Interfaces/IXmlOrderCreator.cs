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
        void CreateDocument(IList<Order> orders);
    }

    public class XmlOrderOutputter : IOrderOutputter
    {
        private string directory;
        private string fileName;

        public XmlOrderOutputter(string directory, string fileName)
        {
            this.directory = directory;
            this.fileName = fileName;
        }

        public void CreateDocument(IList<Order> orders)
        {
            using (XmlWriter writer = XmlWriter.Create($"{directory}\\{fileName}.xml"))
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
