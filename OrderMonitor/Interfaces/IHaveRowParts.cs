using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OrderMonitor.RowPart
{
    public interface IHaveRowParts
    {
        Order CreateOrder();
        Consignment CreateConsignment();
        Parcel CreateParcel();
        Item CreateItem();
    }

    public interface IOutputXML
    {
        void CreateNode(XmlWriter doc);
    }
}
