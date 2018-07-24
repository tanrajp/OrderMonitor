using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Globalization;
using System.Xml;
using CsvHelper;
using CsvHelper.Configuration;
using OrderMonitor.RowPart;

namespace OrderMonitor.Interfaces
{
    public interface IOrderParser
    {
        IList<Order> ReadOrders(string fileName);
    }


    public class CSVOrderParser : IOrderParser
    {
        public IList<Order> ReadOrders(string fileName)
        {
            var orders = new List<Order>();

            using (StreamReader streamReader = File.OpenText(fileName))
            {
                var config = new Configuration();
                config.HasHeaderRecord = true;
                config.PrepareHeaderForMatch = header => header?.Trim();
                config.RegisterClassMap<RowMap>();

                var csv = new CsvReader(streamReader, config);

                var currentRow = new Row();
                var currentOrder = new Order();

                while (csv.Read())
                {
                    var row = csv.GetRecord<Row>();
                    if (currentRow == null || currentRow.OrderNo != row.OrderNo)
                    {
                        var order = row.CreateOrder();
                        var consignment = row.CreateConsignment();
                        var parcel = row.CreateParcel();
                        var item = row.CreateItem();

                        parcel.Items.Add(item);
                        consignment.Parcels.Add(parcel);
                        order.Consignments.Add(consignment);

                        currentRow = row;
                        currentOrder = order;
                        orders.Add(order);
                    }
                    else
                    {
                        if (currentRow.ConsignmentNo != row.ConsignmentNo)
                        {
                            var consignment = row.CreateConsignment();
                            var parcel = row.CreateParcel();
                            var item = row.CreateItem();

                            parcel.Items.Add(item);
                            consignment.Parcels.Add(parcel);

                            currentOrder.Consignments.Add(consignment);
                        }
                        else
                        {
                            var parcel = row.CreateParcel();
                            var item = row.CreateItem();

                            parcel.Items.Add(item);

                            var toupdate = currentOrder.Consignments.Where(x => x.ConsignmentNo == row.ConsignmentNo).Single();
                            toupdate.Parcels.Add(parcel);
                        }
                    }
                }

            }

            return orders;
        }
    }
}
