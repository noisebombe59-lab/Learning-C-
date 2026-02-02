/*using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Files_project;

string? configNameFile = "config.json";

try
{
    BackupConfig? backupConfig = new BackupConfig
    {
        SourceDirectory = "SourceFiles",
        FilesToInclude = { "document.txt", "report.docx" },
        TargetDirectory = "Backups"
    };

    var options = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    string? json = JsonSerializer.Serialize(backupConfig, options);

    Directory.CreateDirectory(backupConfig.SourceDirectory);

    File.WriteAllText(configNameFile, json);

    if (File.Exists(configNameFile))
    {
        string? loadData = File.ReadAllText(configNameFile);
        backupConfig = JsonSerializer.Deserialize<BackupConfig>(loadData, options);
    }
    else
    {
        Console.WriteLine("Файл не существует");
        return;
    }



    string? fullPath = Path.Combine(backupConfig.TargetDirectory, $"{DateTime.Now.ToString("yyyy-MM-dd")}");
    Directory.CreateDirectory(fullPath);

    int testCount = 1;
    foreach (var data in backupConfig.FilesToInclude)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            Console.WriteLine("Файл для записи в исходную папку пуст!");
            continue;
        }

        string? targetCreationPath = Path.Combine(backupConfig.SourceDirectory, data);
        File.WriteAllText(targetCreationPath, $"Данные для тестов {testCount}");
        testCount++;
    }

    foreach (var file in backupConfig.FilesToInclude)
    {
        if (string.IsNullOrWhiteSpace(file))
        {
            Console.WriteLine("Файл для копирования в целевую папку пуст!");
            continue;
        }

        string? sourceDirectory = Path.Combine(backupConfig.SourceDirectory, file);
        string? destDirectory = Path.Combine(fullPath, file);
        File.Copy(sourceDirectory, destDirectory, true);
    }
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"Нет прав доступа к файлу или папке!: {ex.Message}");
}
catch (NullReferenceException ex)
{
    Console.WriteLine($"Ссылка не содержит данные {ex.Message}");
}
catch (IOException ex)
{
    Console.WriteLine($"Непредвиденная ошибка работы с файлами: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Непредвиденная ошибка общей работы программы: {ex.Message}");
}*/

