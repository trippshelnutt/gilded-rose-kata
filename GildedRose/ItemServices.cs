using System;

namespace GildedRose
{
    public static class ItemServices
    {
        public static Item UpdateItem(this Item item) =>
            item.Name switch
            {
                ItemNames.Sulfuras => item,
                ItemNames.AgedBrie => item.UpdateAgedBrie(),
                ItemNames.BackstagePasses => item.UpdateBackstagePasses(),
                _ => item.UpdateItemQuality()
            };

        private static Item UpdateAgedBrie(this Item item) =>
            item.DecrementSellIn()
                .IncrementQuality()
                .IfSellInLessThan(0, IncrementQuality);

        private static Item UpdateBackstagePasses(this Item item) =>
            item.DecrementSellIn()
                .IncrementQuality()
                .IfSellInLessThan(10, IncrementQuality)
                .IfSellInLessThan(5, IncrementQuality)
                .IfSellInLessThan(0, SetQualityToZero);

        private static Item UpdateItemQuality(this Item item) =>
            item.DecrementSellIn()
                .DecrementQuality()
                .IfSellInLessThan(0, DecrementQuality);

        private static Item IncrementQuality(this Item item) =>
            item.IfBelowMaximumQuality(UnprotectedIncrementQuality);

        private static Item UnprotectedIncrementQuality(this Item item) =>
            item.With(quality: item.Quality + 1);

        private static Item DecrementQuality(this Item item) =>
            item.IfAboveMinimumQuality(UnprotectedDecrementQuality);

        private static Item UnprotectedDecrementQuality(this Item item) =>
            item.With(quality: item.Quality - 1);

        private static Item DecrementSellIn(this Item item) =>
            item.With(sellIn: item.SellIn - 1);

        private static Item SetQualityToZero(this Item item) =>
            item.With(quality: 0);

        private static Item IfSellInLessThan(this Item item, int days, Func<Item, Item> func) =>
            item.SellIn < days ? func(item) : item;

        private static Item IfAboveMinimumQuality(this Item item, Func<Item, Item> func) =>
            item.Quality > Quality.MinQuality ? func(item) : item;

        private static Item IfBelowMaximumQuality(this Item item, Func<Item, Item> func) =>
            item.Quality < Quality.MaxQuality ? func(item) : item;
    }
}