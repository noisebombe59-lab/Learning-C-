namespace LINQ_part5
{
    public class Program
    {
        static void Main()
        {
            var gameControlSystem = new GameControlSystem();
            var telegrammSender = new Telegramm();

            var mercenaryConditionReport = new MercenaryConditionReport();
            var conditionMessage = new MessageSendingSystem<IEnumerable<Mercenary>>();

            var squadAnaliticsReport = new SquadAnalyticsReport();
            var analisisMessage = new MessageSendingSystem<IEnumerable<SquadAnalytics>>();

            var junkReport = new InventoryOfJunkReport();
            var junkMessage = new MessageSendingSystem<IEnumerable<Item>>();

            var readinessReport = new CharacterReadinessReport();
            var readyMessage = new MessageSendingSystem<bool>();

            var bagContaminationReport = new BagAnaliticsReport();
            var bagContaminationMessage = new MessageSendingSystem<IEnumerable<BagAnalitics>>();

            var mercenaries = new List<Mercenary>()
            {
                new Mercenary(1, 3, 88, 4000, 230, "Archer", "Melinda"),
                new Mercenary(2, 4, 22, 5000, 192, "Mage", "Sheron"),
                new Mercenary(3, 10, 19, 1000, 170, "Archer", "John"),
                new Mercenary(4, 11, 99, 2000, 150, "Mage", "Tom"),
                new Mercenary(5, 12, 89, 3000, 200, "Warrior", "Jekson"),
                new Mercenary(6, 13, 79, 7000, 220, "Healler", "Dakota")
            };

            List<Item> items = new List<Item>()
            {
                new Weapon(1, 8, 5, "Рассекатель", "Sword", "Common"),
                new Weapon(2, 6, 2, "Крушитель", "knuckles", "Common"),
                new Weapon(3, 4, 23, "Гибкий лук Гелоса", "Bow", "Uncommon"),
                new Weapon(4, 5, 6, "Топор викингов", "Axe", "Rare"),
                new Weapon(5, 3, 10, "Острый секачь", "sickle", "Mythical"),
                new Weapon(5, 3, 10, "Острый секачь", "sickle", "Mythical"),

                new Scrolls(6, 2, 5, 2, "Свиток воскрешения", "resurrection", "Common"),
                new Scrolls(2, 2, 2, 3, "Свиток телепортации", "Teleportation", "Common"),
                new Scrolls(3, 2, 23, 5, "Свиток скорости", "buffs", "Common"),
                new Scrolls(4, 2, 6, 1, "Свиток ловкости", "buffs", "Common"),
                new Scrolls(5, 2, 10, 8, "Свиток атаки", "buffs", "Common"),
                new Scrolls(1, 2, 10, 8, "Свиток силы", "buffs", "Common"),
            };

            var bags = new List<Bag>()
            {
                new Bag(1, 20),
                new Bag(2, 35),
                new Bag(3, 18),
                new Bag(4, 42),
                new Bag(5, 52),
                new Bag(6, 25),
            };

            gameControlSystem.AddMercenaries(mercenaries);
            gameControlSystem.AddBags(bags);
            gameControlSystem.AddItems(items);
            gameControlSystem.AddItemsToBags(1, items);
            gameControlSystem.AddItemsToBags(2, items);
            gameControlSystem.AddItemsToBags(3, items);
            gameControlSystem.AddItemsToBags(4, items);
            gameControlSystem.AddItemsToBags(5, items);
            gameControlSystem.AddItemsToBags(6, items);

            var readyUnits = mercenaryConditionReport.SquadCondition(mercenaries, mercenaryConditionReport);
            conditionMessage.SendReport(telegrammSender, readyUnits);

            var classInformation = squadAnaliticsReport.ClassInformation(mercenaries);
            analisisMessage.SendReport(telegrammSender, classInformation);

            var lowRankItems = junkReport.GetJunkNames(bags);
            junkMessage.SendReport(telegrammSender, lowRankItems);

            var characterIsReady = readinessReport.IsReadyForRaid(mercenaries, bags);
            readyMessage.SendReport(telegrammSender, characterIsReady);

            var fullBags = bagContaminationReport.BagAnalyzer(mercenaries, bags);
            bagContaminationMessage.SendReport(telegrammSender, fullBags);
        }
    }
}