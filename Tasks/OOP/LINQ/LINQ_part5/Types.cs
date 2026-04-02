namespace LINQ_part5
{
    public interface ILimits { decimal LimitForBattle() => 0.80m; }
    public interface ISendingReport<T> { void Send(T data); }

    public abstract record Item(int ItemId, double ItemWeight, double ItemCost, string ItemName, string ItemType, string ItemRarity);
    public record BagAnalitics(string Name, double OverWeight);
    public record SquadAnalytics(string ClassName, double TotalGold, double AverageMana);
    public record Weapon(int ItemId, double ItemWeight, double ItemCost, string ItemName, string ItemType, string ItemRarity)
        : Item(ItemId, ItemWeight, ItemCost, ItemName, ItemType, ItemRarity);
    public record Scrolls(int ItemId, int ScrollsCapacity, double ItemWeight, double ItemCost, string ItemName, string ItemType, string ItemRarity)
        : Item(ItemId, ItemWeight, ItemCost, ItemName, ItemType, ItemRarity);
    public record Mercenary(int Id, int CurrentLevel, int CurrentHp, int Gold, double Mana, string MercenaryClass, string Name, int BasicHp = 100);
    public record Bag(int OwnerId, int Weight)
    {
        public List<Item> Items { get; init; } = new List<Item>();
    }
}
