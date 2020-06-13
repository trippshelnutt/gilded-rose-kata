using System.Linq;
using GildedRose;
using NUnit.Framework;

namespace GildedRoseTests
{
    public class ProgramTests
    {
        [Test]
        public void ItemNameDoesNotChange()
        {
            var item = new Item("foo", 0, 0);
            var app = new Program { Items = new[] { item } };

            app.UpdateQuality();

            Assert.AreEqual("foo", item.Name);
        }

        [TestCase("foo", 1, 50, 49, Description = "Quality degrades for normal items")]
        [TestCase("foo", 0, 50, 48, Description = "Quality degrades at twice normal rate after SellIn passes")]
        [TestCase("foo", 0, Quality.MinQuality, Quality.MinQuality, Description = "Quality does not decrease below min quality")]
        [TestCase(ItemNames.AgedBrie, 1, 0, 1, Description = "Quality increases for Aged Brie")]
        [TestCase(ItemNames.AgedBrie, 0, 0, 2, Description = "Quality increases by 2 for Aged Brie when past SellIn")]
        [TestCase(ItemNames.AgedBrie, 0, Quality.MaxQuality, Quality.MaxQuality, Description = "Quality does not increase above max quality")]
        [TestCase(ItemNames.Sulfuras, 0, Quality.Sulfuras, Quality.Sulfuras, Description = "Quality does not change for Sulfuras")]
        [TestCase(ItemNames.BackstagePasses, 11, 30, 31, Description = "Quality increases for Backstage Passes")]
        [TestCase(ItemNames.BackstagePasses, 10, 30, 32, Description = "Quality increases by 2 for Backstage Passes when 10 days to SellIn")]
        [TestCase(ItemNames.BackstagePasses, 6, 30, 32, Description = "Quality increases by 2 for Backstage Passes when 10 days to SellIn")]
        [TestCase(ItemNames.BackstagePasses, 5, 30, 33, Description = "Quality increases by 3 for Backstage Passes when 5 days to SellIn")]
        [TestCase(ItemNames.BackstagePasses, 1, 30, 33, Description = "Quality increases by 3 for Backstage Passes when 5 days to SellIn")]
        [TestCase(ItemNames.BackstagePasses, 0, 30, 0, Description = "Quality drops to zero after the event for Backstage Passes")]
        public void QualityDegradesAsExpected(string name, int sellIn, int quality, int expectedQuality)
        {
            var item = new Item(name, sellIn, quality);
            var app = new Program { Items = new[] { item } };

            app.UpdateQuality();

            Assert.AreEqual(expectedQuality, app.Items.First().Quality);
        }

        [TestCase("foo", 1, 50, 0, Description = "SellIn decreases for normal items")]
        [TestCase("foo", 0, 50, -1, Description = "SellIn should decrease below zero")]
        [TestCase(ItemNames.Sulfuras, 1, 75, 1, Description = "SellIn does not decrease for Sulfuras")]
        public void SellInDecreasesAsExpected(string name, int sellIn, int quality, int expectedSellIn)
        {
            var item = new Item(name, sellIn, quality);
            var app = new Program { Items = new[] { item } };

            app.UpdateQuality();

            Assert.AreEqual(expectedSellIn, app.Items.First().SellIn);
        }
    }
}