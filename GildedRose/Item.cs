namespace GildedRose
{
    public readonly struct Item
    {
        public string Name { get; }
        public int SellIn { get; }
        public int Quality { get; }

        public Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public Item With(string name = null, int? sellIn = null, int? quality = null) =>
            new Item(name ?? this.Name, sellIn ?? this.SellIn, quality ?? this.Quality);
    }
}