using System.Text.Json;

namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility
{
    public class JsonLogger : BankLogger
    {
        public JsonLogger(string name) : base(name) { }

        public override void DoRealWork(string message)
        {
            var entry = new LogEntry(
                timeStamp: DateTime.Now,
                level: "5",
                message: message
            );

            var folderName = "Logs";
            var fileName = "audit.json";
            var path = Path.Combine(folderName, fileName);

            var options = new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var jsonFile = JsonSerializer.Serialize(entry, options);

            Directory.CreateDirectory(folderName);
            File.WriteAllText(path, jsonFile);

            if (File.Exists(path))
            {
                var readJson = File.ReadAllText(path);
                var readJsonData = JsonSerializer.Deserialize<LogEntry>(readJson, options);
                Console.WriteLine(readJsonData.Message);
                Console.ReadKey();
            }
        }
    }
}
