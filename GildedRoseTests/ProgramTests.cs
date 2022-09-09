using NUnit.Framework;
using System.Collections.Generic;
using GildedRose;

namespace GildedRoseTests
{
    public class ProgramTests 
    {
        [Test]
        public void UpdateQualityDoesNotChangeItemName()
        {
            var items = new List<Item>{
                new Item
                {
                    Name = "foo",
                    SellIn = 0,
                    Quality = 0
                }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            Assert.AreEqual("foo", app.Items[0].Name);
        }

        [Test]
        public void UpdateQualityLowersSellIn()
        {
            var items = new List<Item>{
                new Item
                {
                    Name = "foo",
                    SellIn = 1,
                    Quality = 0
                }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            Assert.AreEqual(0, app.Items[0].SellIn);
        }

        [Test]
        public void UpdateQualityLowersByQualityBy1WhenSellInGreaterThan0()
        {
            const int originalQuality = 50;
            var items = new List<Item>{
                new Item
                {
                    Name = "foo",
                    SellIn = 1,
                    Quality = originalQuality
                }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            const int expectedQuality = originalQuality - 1;
            Assert.AreEqual(expectedQuality, app.Items[0].Quality);
        }

        [Test]
        public void UpdateQualityLowersByQualityBy2WhenSellInLessThanOrEqualTo0()
        {
            const int originalQuality = 50;
            var items = new List<Item>{
                new Item
                {
                    Name = "foo",
                    SellIn = 0,
                    Quality = originalQuality
                }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            const int expectedQuality = originalQuality - 2;
            Assert.AreEqual(expectedQuality, app.Items[0].Quality);
        }

        [Test]
        public void UpdateQualityDoesNotLowerQualityBelow0()
        {
            const int originalQuality = 0;
            var items = new List<Item>{
                new Item
                {
                    Name = "foo",
                    SellIn = 1,
                    Quality = originalQuality
                }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            const int expectedQuality = originalQuality;
            Assert.AreEqual(expectedQuality, app.Items[0].Quality);
        }

        [Test]
        public void UpdateQualityIncreasesQualityOfAgedBrieBy1WhenSellInGreaterThan0()
        {
            const int originalQuality = 25;
            var items = new List<Item>{
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 1,
                    Quality = originalQuality
                }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            const int expectedQuality = originalQuality + 1;
            Assert.AreEqual(expectedQuality, app.Items[0].Quality);
        }

        [Test]
        public void UpdateQualityIncreasesQualityOfAgedBrieBy2WhenSellInLessThan1()
        {
            const int originalQuality = 25;
            var items = new List<Item>{
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 0,
                    Quality = originalQuality
                }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            const int expectedQuality = originalQuality + 2;
            Assert.AreEqual(expectedQuality, app.Items[0].Quality);
        }

        [Test]
        public void UpdateQualityIncreasesQualityOfBackstagePassesWhenSellInGreaterThan10()
        {
            const int originalQuality = 25;
            var items = new List<Item>{
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 11,
                    Quality = originalQuality
                }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            const int expectedQuality = originalQuality + 1;
            Assert.AreEqual(expectedQuality, app.Items[0].Quality);
        }

        [Test]
        public void UpdateQualityIncreasesQualityOfBackstagePassesBy2WhenSellInGreaterThan5()
        {
            const int originalQuality = 25;
            var items = new List<Item>{
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 6,
                    Quality = originalQuality
                }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            const int expectedQuality = originalQuality + 2;
            Assert.AreEqual(expectedQuality, app.Items[0].Quality);
        }

        [Test]
        public void UpdateQualityIncreasesQualityOfBackstagePassesBy3WhenSellInGreaterThan0()
        {
            const int originalQuality = 25;
            var items = new List<Item>{
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 1,
                    Quality = originalQuality
                }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            const int expectedQuality = originalQuality + 3;
            Assert.AreEqual(expectedQuality, app.Items[0].Quality);
        }

        [Test]
        public void UpdateQualitySetsQualityOfBackstagePassesTo0WhenSellInIs0()
        {
            const int originalQuality = 25;
            var items = new List<Item>{
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = originalQuality
                }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            const int expectedQuality = 0;
            Assert.AreEqual(expectedQuality, app.Items[0].Quality);
        }

        [Test]
        public void UpdateQualityDoesIncreasesQualityAbove50()
        {
            const int originalQuality = 50;
            var items = new List<Item>{
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 1,
                    Quality = originalQuality
                }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            const int expectedQuality = originalQuality;
            Assert.AreEqual(expectedQuality, app.Items[0].Quality);
        }

        [Test]
        public void UpdateQualityDoesNotChangeQualityForSulfuras()
        {
            const int originalQuality = 50;
            var items = new List<Item>{
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 1,
                    Quality = originalQuality
                }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            const int expectedQuality = originalQuality;
            Assert.AreEqual(expectedQuality, app.Items[0].Quality);
        }

        [Test]
        public void UpdateQualityDoesNotChangeSellInForSulfuras()
        {
            const int originalSellIn = 50;
            var items = new List<Item>{
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = originalSellIn,
                    Quality = 1
                }
            };

            var app = new Program { Items = items };

            app.UpdateQuality();

            const int expectedSellIn = originalSellIn;
            Assert.AreEqual(expectedSellIn, app.Items[0].SellIn);
        }

    }
}