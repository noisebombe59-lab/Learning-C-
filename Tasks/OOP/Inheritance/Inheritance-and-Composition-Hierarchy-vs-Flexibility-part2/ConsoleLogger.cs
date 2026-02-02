namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility_part2
{
    public class ConsoleLogger : Logger
    {
        public ConsoleLogger(string? name) : base(name) { }

        public override void DoRealWork(string? message)
        {
            Console.WriteLine($"Имя: {Name}, Сообщение: {message}");
        }
    }
}
