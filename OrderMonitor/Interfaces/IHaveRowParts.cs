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
