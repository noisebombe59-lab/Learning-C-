Что такое работа с файлами и JSON в C#
Работа с файлами — чтение/запись текстовых и бинарных файлов, управление путями и папками.

JSON — сериализация/десериализация объектов в/из строки или файла (System.Text.Json — современный стандарт).

Пример кода

string path = Path.Combine("data", "config.json");
File.WriteAllText(path, "{\"Username\":\"Admin\"}");
string json = File.ReadAllText(path);
──────────────────────────────────────────────────────────────────────
Подключение

using System.IO;                              // Path, File, Directory, StreamReader/Writer
using System.Text.Json;                       // JsonSerializer
using System.Text.Json.Serialization;         // [JsonIgnore] и др.
──────────────────────────────────────────────────────────────────────
Path — безопасная работа с путями (всегда используй!)
string path = Path.Combine("папка", "подпапка", "file.json");

Path.GetFileName(path);               // "file.json"
Path.GetDirectoryName(path);          // путь к папке
Path.GetExtension(path);              // ".json"
Path.GetFileNameWithoutExtension(path); // "file"
Path.GetTempPath();                   // временная папка
Path.GetTempFileName();               // уникальное имя временного файла
──────────────────────────────────────────────────────────────────────
File — быстрые операции с небольшими файлами
File.Exists("path.txt");              // true/false

string text = File.ReadAllText("path.txt");
string[] lines = File.ReadAllLines("path.txt");
byte[] bytes = File.ReadAllBytes("path.bin");

File.WriteAllText("path.txt", "текст");     // создаёт/перезаписывает
File.AppendAllText("log.txt", "новая строка\n");

File.Copy("откуда.txt", "куда.txt", overwrite: true);
File.Move("старый.txt", "новый.txt");
File.Delete("path.txt");
──────────────────────────────────────────────────────────────────────
Directory — работа с папками
Directory.CreateDirectory("папка/подпапка"); // создаёт все по пути

Directory.Exists("папка");            // true/false

string[] files = Directory.GetFiles("папка", "*.json");

Directory.Delete("папка", recursive: true); // с содержимым
──────────────────────────────────────────────────────────────────────
StreamReader / StreamWriter — для больших файлов
using var reader = new StreamReader("huge.txt");
string? line;
while ((line = await reader.ReadLineAsync()) != null)
{
    // обработка по строкам — память не растёт
}

using var writer = new StreamWriter("log.txt", append: true);
await writer.WriteLineAsync("2025-12-17 | INFO | start");
──────────────────────────────────────────────────────────────────────
JSON — сериализация/десериализация (System.Text.Json)

public class User
{
    public string Username { get; set; } = "";
    public int Level { get; set; }
    public List<string>? Roles { get; set; }
}

var options = new JsonSerializerOptions
{
    WriteIndented = true,                     // красивый JSON
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};
──────────────────────────────────────────────────────────────────────
Сохранить объект → JSON → файл

var user = new User { Username = "Admin", Level = 99 };

string json = JsonSerializer.Serialize(user, options);

string path = Path.Combine("config", "user.json");
Directory.CreateDirectory(Path.GetDirectoryName(path)!);
File.WriteAllText(path, json);
──────────────────────────────────────────────────────────────────────
Загрузить из файла → JSON → объект

if (File.Exists(path))
{
    string json = File.ReadAllText(path);
    var user = JsonSerializer.Deserialize<User>(json, options);
}
──────────────────────────────────────────────────────────────────────
Полезные расширения (упрощают жизнь)

public static class JsonHelper
{
    private static readonly JsonSerializerOptions opts = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static void SaveJson<T>(this T obj, string path) where T : class
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, JsonSerializer.Serialize(obj, opts));
    }

    public static T? LoadJson<T>(string path) where T : class
        => File.Exists(path) ? JsonSerializer.Deserialize<T>(File.ReadAllText(path), opts) : null;
}

// Использование
user.SaveJson(@"data\user.json");
var loaded = @"data\user.json".LoadJson<User>();
──────────────────────────────────────────────────────────────────────
Важные правила

• Всегда используй using или await using — иначе файл останется заблокированным.
• Всегда Path.Combine — никогда не склеивай пути строками вручную.
• Проверяй File.Exists() / Directory.Exists() перед операциями.
• Оборачивай в try-catch (IOException, UnauthorizedAccessException).
──────────────────────────────────────────────────────────────────────