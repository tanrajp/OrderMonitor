using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderMonitor;
using NUnit.Framework;

namespace OrderMonitorTests
{
    [TestFixture]
    public class OrderTests
    {
        private Order order;
        private Item item;

        [SetUp]
        public void SetUp()
        {
            order = new Order();
        }

        [Test]
        public void SingleItem_ReturnsCorrectCost()
        {
            var item = new Item();
            var parcel = new Parcel();
            var consignment = new Consignment();

            item.Quantity = 1;
            item.Value = 1.1;

            parcel.Items.Add(item);
            consignment.Parcels.Add(parcel);
            order.Consignments.Add(consignment);

            Assert.AreEqual(1.1, order.TotalValue);
        }

        [Test]
        public void MultipleItems_ReturnsCorrectCost()
        {
            var item = new Item();
            var item2 = new Item();

            var parcel = new Parcel();
            var consignment = new Consignment();

            item.Quantity = 1;
            item.Value = 1.1;

            item2.Quantity = 2;
            item2.Value = 3.4;            


            parcel.Items.Add(item);
            parcel.Items.Add(item2);

            consignment.Parcels.Add(parcel);
            order.Consignments.Add(consignment);

            Assert.AreEqual(7.9, order.TotalValue);
        }
    }
}
