namespace LINQ_part5
{
    public class Telegramm :
        ISendingReport<IEnumerable<Item>>,
        ISendingReport<IEnumerable<Mercenary>>,
        ISendingReport<IEnumerable<BagAnalitics>>,
        ISendingReport<IEnumerable<SquadAnalytics>>,
        ISendingReport<bool>
    {

        public void Send(IEnumerable<BagAnalitics> bagData)
        {
            Console.WriteLine("Список наемников с перегруженной сумкой:");

            foreach (var elem in bagData)
            {
                Console.WriteLine($"    *Имя наемника: {elem.Name} | Перегруз по весу: {elem.OverWeight}");
                Console.WriteLine(new string('-', 50));
            }
        }
        public void Send(bool isHasHealler)
        {
            Console.WriteLine("Проверка наличия в рейде Healler с свитком воскрешения:");
            Console.WriteLine(isHasHealler ? "    *Рейд готов! Есть Healler с свитком воскрешения" : "Рейд не готов! нет Healler или свитка воскрешения");
            Console.WriteLine(new string('-', 50));
        }
        public void Send(IEnumerable<Mercenary> units)
        {
            Console.WriteLine("Список здоровых наемников имеющих уровень > 10:");
            foreach (var unit in units)
            {
                Console.WriteLine($"-> {unit.Name} (Ур. {unit.CurrentLevel})");
            }
            Console.WriteLine(new string('-', 50));
        }

        public void Send(IEnumerable<SquadAnalytics> classData)
        {
            Console.WriteLine("Информация каждого класса наемника:");
            foreach (var unit in classData)
            {
                Console.WriteLine($"Класс -> {unit.ClassName}");
                Console.WriteLine($"    *Золото всего класса -> {unit.TotalGold}");
                Console.WriteLine($"    *Средний показатель маны класса {unit.ClassName} -> {unit.AverageMana}");
                Console.WriteLine(new string('-', 50));
            }
        }

        public void Send(IEnumerable<Item> items)
        {
            Console.WriteLine("Названия предметов с редкостью 'Common' и стоимостью < 10 золотых:");
            foreach (var item in items)
            {
                Console.WriteLine($"    *{item.ItemName}");
            }
            Console.WriteLine(new string('-', 50));
        }
    }
}
