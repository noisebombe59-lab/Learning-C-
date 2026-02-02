namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility_part2
{
    public class FileLogger : Logger
    {
        private string _filePath = "log.txt";

        public FileLogger(string? name) : base(name) { }
        public override void DoRealWork(string? message)
        {
            string? fullMessage = $"[{DateTime.Now}], Имя: {Name}, Сообщение: {message}";
            File.AppendAllText(_filePath, fullMessage);
        }
    }
}
