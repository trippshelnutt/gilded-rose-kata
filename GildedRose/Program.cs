using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class Program
    {
        public IEnumerable<Item> Items { get; set; }

        public void UpdateQuality() =>
            Items = Items.Select(i => i.UpdateItem());
    }
}