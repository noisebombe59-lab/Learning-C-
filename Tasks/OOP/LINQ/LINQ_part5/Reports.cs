namespace LINQ_part5
{
    public class MercenaryConditionReport : ILimits
    {
        public IEnumerable<Mercenary> SquadCondition(IEnumerable<Mercenary> units, ILimits limit)
        {
            var currentCondition = units
                .Where(w => (decimal)w.CurrentHp / w.BasicHp >= limit.LimitForBattle() && w.CurrentLevel > 10)
                .OrderByDescending(o => o.CurrentLevel);

            return currentCondition;
        }
    }

    public class SquadAnalyticsReport
    {
        public IEnumerable<SquadAnalytics> ClassInformation(IEnumerable<Mercenary> units)
        {
            var className = units
                .GroupBy(g => g.MercenaryClass)
                .Select(group => new SquadAnalytics(
                    group.Key,
                    group.Sum(s => s.Gold),
                    group.Average(a => a.Mana)
                ));

            return className;
        }
    }

    public class InventoryOfJunkReport
    {
        public IEnumerable<Item> GetJunkNames(IEnumerable<Bag> bags)
        {
            var itemNames = bags
                .SelectMany(s => s.Items)
                .Where(w => w.ItemRarity == "Common" && w.ItemCost < 10)
                .GroupBy(g => g.ItemName)
                .Select(s => s.First());
            return itemNames;
        }
    }

    public class CharacterReadinessReport
    {
        public bool IsReadyForRaid(IEnumerable<Mercenary> units, IEnumerable<Bag> bags)
        {
            var hasScroll = units
                .GroupJoin(
                bags,
                mercId => mercId.Id,
                bagId => bagId.OwnerId,
                (mercId, bagGroup) => new { mercId, bagGroup });

            var isReady = hasScroll
                .Any(w => w.mercId.MercenaryClass == "Healler" && w.bagGroup
                .Any(a => a.Items
                .Any(a => a.ItemName == "Свиток воскрешения")));

            return isReady;
        }
    }

    public class BagAnaliticsReport
    {
        public IEnumerable<BagAnalitics> BagAnalyzer(IEnumerable<Mercenary> units, IEnumerable<Bag> bags)
        {
            var analasisResult = units
                .GroupJoin(
                bags,
                mercId => mercId.Id,
                bagId => bagId.OwnerId,
                (mercId, bagGroup) => new BagAnalitics(

                    mercId.Name,
                    bagGroup.Sum(s => Math.Max(0, s.Items.Sum(i => i.ItemWeight) - s.Weight
                ))));

            return analasisResult;
        }
    }
}
