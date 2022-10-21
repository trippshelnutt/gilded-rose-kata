using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        private const string BackstagePassesName = "Backstage passes to a TAFKAL80ETC concert";
        private const string AgedBrieName = "Aged Brie";
        private const string SulfurasName = "Sulfuras, Hand of Ragnaros";

        public IList<Item> Items { get; set; }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItem(item);
            }
        }

        private static void UpdateItem(Item item)
        {
            if (item.Name != AgedBrieName && item.Name != BackstagePassesName)
            {
                if (item.Quality > 0)
                {
                    if (item.Name != SulfurasName)
                    {
                        item.Quality -= 1;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;

                    if (item.Name == BackstagePassesName)
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality += 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality += 1;
                            }
                        }
                    }
                }
            }

            if (item.Name != SulfurasName)
            {
                item.SellIn -= 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != AgedBrieName)
                {
                    if (item.Name != BackstagePassesName)
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != SulfurasName)
                            {
                                item.Quality -= 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality -= item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
