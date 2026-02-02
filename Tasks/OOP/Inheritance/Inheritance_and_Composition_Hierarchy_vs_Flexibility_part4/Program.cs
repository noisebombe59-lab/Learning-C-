using System.Text.Json;

namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility_part4
{
    public class Program
    {
        static void Main()
        {
            Processor processor = new Processor("Intel", 4);
            Computer computer = new Computer("Asus", processor);

            var fileName = "Computers.json";
            var folderName = "Computers";

            var path = Path.Combine(folderName, fileName);

            var options = new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(computer, options);

            Directory.CreateDirectory(folderName);
            File.WriteAllText(path, json);

            if (File.Exists(path))
            {
                var readJson = File.ReadAllText(path);
                var readComputer = JsonSerializer.Deserialize<Computer>(readJson, options);
            }
        }
    }
}