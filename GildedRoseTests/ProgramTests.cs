using NUnit.Framework;
using System.Collections.Generic;
using GildedRose;

namespace GildedRoseTests
{
    public class ProgramTests 
    {
        [Test]
        public void foo()
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
    }
}