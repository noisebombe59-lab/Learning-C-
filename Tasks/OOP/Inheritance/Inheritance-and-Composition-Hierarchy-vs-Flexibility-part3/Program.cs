using System.Text.Json;

namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility_part3
{
    public class Program
    {
        static void Main()
        {
            var fileName = "book.json";
            var folderName = "BookLibrary";
            
            var path = Path.Combine(folderName, fileName);

            var book = new Book("Стивен Хоккинг", "Краткая история времени");

            var options = new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(book, options);

            Directory.CreateDirectory(folderName);
            File.WriteAllText(path, json);

            if (File.Exists(path))
            {
                var readJson = File.ReadAllText(path);
                var readBook = JsonSerializer.Deserialize<Book>(readJson, options);
            }
        }
    }
}