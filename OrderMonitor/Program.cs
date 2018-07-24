﻿using System;
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

namespace OrderMonitor
{
    public class Row : IHaveRowParts
    {
        public string OrderNo { get; set; }
        public string ConsignmentNo { get; set; }
        public string ConsigneeName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }
        public string ParcelCode { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public float Weight { get; set; }
        public string Currency { get; set; }
        public int Quantity { get; set; }

        public Order CreateOrder()
        {
            return new Order
            {
                OrderNo = OrderNo
            };
        }

        public Consignment CreateConsignment()
        {
            return new Consignment
            {
                ConsignmentNo = ConsignmentNo,
                ConsigneeName = ConsigneeName,
                Address1 = Address1,
                Address2 = Address2,
                City = City,
                State = State,
                CountryCode = CountryCode
            };
        }

        public Parcel CreateParcel()
        {
            return new Parcel
            {
                ParcelCode = ParcelCode
            };
        }

        public Item CreateItem()
        {
            return new Item
            {
                Description = Description,
                Value = Value,
                Weight = Weight,
                Currency = Currency,
                Quantity = Quantity
            };
        }
    }

    public class RowMap : ClassMap<Row>
    {
        public RowMap()
        {
            Map(x => x.OrderNo).Name("Order No");
            Map(x => x.ConsignmentNo).Name("Consignment No");
            Map(x => x.ConsigneeName).Name("Consignee Name");
            Map(x => x.Address1).Name("Address 1");
            Map(x => x.Address2).Name("Address 2");
            Map(x => x.City).Name("City");
            Map(x => x.State).Name("State");
            Map(x => x.CountryCode).Name("Country Code");
            Map(x => x.ParcelCode).Name("Parcel Code");
            Map(x => x.Description).Name("Item Description");
            Map(x => x.Value).Name("Item Value");
            Map(x => x.Weight).Name("Item Weight");
            Map(x => x.Currency).Name("Item Currency");
            Map(x => x.Quantity).Name("Item Quantity");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {


            Console.Read();
        }
    }
}
