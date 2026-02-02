using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
/*using TrainFiles.День_5;

static void SaveConfig()
{
    AppConfig data = new AppConfig { Version = "1.0.0", MaxFileSizeMB = 100 };

    var options = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    string json = JsonSerializer.Serialize(data, options);
    File.WriteAllText("config.json", json);
}

static AppConfig? LoadConfig()
{
    string readText = "";
    if (File.Exists("config.json"))
    {
        readText = File.ReadAllText("config.json");
        return JsonSerializer.Deserialize<AppConfig>(readText);
    }
    else
    {
        return null;
    }
}

SaveConfig();
AppConfig? fromJson = LoadConfig();

Console.WriteLine($"Данные, которые вернулись обратно: Версия: {fromJson.Version}, Размер файла: {fromJson.MaxFileSizeMB}");*/
