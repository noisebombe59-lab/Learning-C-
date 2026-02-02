─────────────────────────────────────────────────────────────────────
Что такое исключения в C#

Исключение (Exception) — объект, который «выбрасывается» (throw), когда в коде происходит ошибка.
Если не поймать — программа аварийно завершится.
try-catch-finally — единственный правильный способ обработать ошибку и продолжить работу.

Пример кода
try
{
    int x = int.Parse("не число");
}
catch (FormatException)
{
    Console.WriteLine("Неверный формат числа");
}
──────────────────────────────────────────────────────────────────────
Основные блоки
try
{
    // код, который может бросить исключение
}
catch
{
    // выполняется только если было исключение
}
finally
{
    // выполняется ВСЕГДА (было исключение или нет)
}
──────────────────────────────────────────────────────────────────────
Правильный порядок catch (очень важно!)

Конкретные исключения — ПЕРВЫМИ, общий Exception — ПОСЛЕДНИМ.
C#try { /* код */ }
catch (FileNotFoundException ex) { /* конкретное */ }
catch (ArgumentException ex) { /* конкретное */ }
catch (Exception ex) { /* общий — последний! */ }
finally { /* очистка */ }
──────────────────────────────────────────────────────────────────────
Основная иерархия исключений (запомни главные)

Exception
└─ SystemException
   ├─ NullReferenceException          // №1 у начинающих
   ├─ ArgumentException
   │   ├─ ArgumentNullException
   │   └─ ArgumentOutOfRangeException
   ├─ IOException
   │   ├─ FileNotFoundException
   │   └─ DirectoryNotFoundException
   ├─ InvalidOperationException
   ├─ ObjectDisposedException         // использовали после Dispose
   └─ DivideByZeroException
──────────────────────────────────────────────────────────────────────
Полный пример обработки

try
{
    string json = File.ReadAllText("config.json");
    var config = JsonSerializer.Deserialize<Config>(json);
}
catch (FileNotFoundException)
{
    Console.WriteLine("Конфиг не найден — используем значения по умолчанию");
}
catch (JsonException ex)
{
    Console.WriteLine("Ошибка в JSON");
    Log.Error(ex);
}
catch (Exception ex)
{
    Log.Fatal("Неизвестная ошибка", ex);
}
finally
{
    Console.WriteLine("Загрузка конфигурации завершена");
}
──────────────────────────────────────────────────────────────────────
finally и using — для освобождения ресурсов

// C# 8+ — лучший способ
await using var reader = new StreamReader("file.txt");
// автоматически вызовет Dispose в finally

// Или обычный using
using var writer = new StreamWriter("log.txt");
──────────────────────────────────────────────────────────────────────
Важные правила

• catch (Exception) всегда ПОСЛЕДНИМ.
• Никогда не оставляй пустой catch {} — ошибка «проглатывается».
• Логируй все исключения (особенно в catch (Exception)).
• throw; — перебросить текущее исключение (сохраняет StackTrace).
• throw ex; — плохо, сбрасывает StackTrace.
• Не бросай new Exception("сообщение") — используй конкретный тип.
──────────────────────────────────────────────────────────────────────
Правильно vs Неправильно

// Плохо
catch (Exception ex) { }               // первым или пустой

// Хорошо
catch (SpecificException ex) { /* обработка */ }
catch (Exception ex)
{
    Log.Error("Критическая ошибка", ex);
    throw; // если нужно пробросить выше
}
──────────────────────────────────────────────────────────────────────