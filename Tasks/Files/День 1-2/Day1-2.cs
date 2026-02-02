using System.IO;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using static System.IO.File;

/*****************************************************************************************************************************
Простые упражнения
****************************************************************************************************************************

string fileContent = "Мой первый шаг к работе с файлами";
string fileName  = "hello.txt";

File.WriteAllText(fileName, fileContent);
string readFileContent = File.ReadAllText(fileName);

Console.WriteLine($"Прочитанный текст: {readFileContent}");

string newFileContent = "\nЭто добавлено вторым действием.";
File.AppendAllText(fileName, newFileContent);
string finalContent = File.ReadAllText(fileName);

Console.WriteLine(finalContent);

****************************************************************************************************************************
Задачи на применение
***************************************************************************************************************************

Задача 1: Анализатор Чётных Строк (Чтение)

try
{
    Console.WriteLine("Введите имя файла, например, numbers.txt: ");
    string fileName = Console.ReadLine();

    using (StreamReader reader = new StreamReader(fileName))
    {
        string line;
        int lineNumber = 0;
        while ((line = reader.ReadLine()) != null)
        {
            lineNumber++;
            if (lineNumber % 2 == 0)
            {
                Console.WriteLine($"Чётная строка {lineNumber}: {line}");
            }
        }
    }
}
catch (FileNotFoundException)
{
    Console.WriteLine($"Файл не найден");
}

****************************************************************************************************************************
Задача 2: Генератор Лога Сбоев (Запись)
****************************************************************************************************************************

string fileName = "app_log.txt";
try
{
    while (true)
    {
        Console.Write("Введите ошибку, например, Ошибка парсинга даты: ");
        string inputError = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(inputError))
        {
            break;
        }

        string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] - {inputError}";

        File.AppendAllText(fileName, logEntry);

        Console.WriteLine($"Записано: {logEntry}");
    }
}
catch (IOException ex)
{
    Console.WriteLine($"Ошибка: Непредвиденная ошибка {ex.Message}");
}
Console.WriteLine($"Логирование завершено. Проверьте app_log.txt");

****************************************************************************************************************************
Задача 3: Валидатор Паролей (Чтение и Коллекции)
****************************************************************************************************************************

try
{
    Console.Write("Введите имя файла с чёрным списком паролей (например, blacklist.txt): ");
    string? userInput = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(userInput))
    {
        Console.WriteLine("Строка не может быть пустой или null");
        return;
    }

    string[] lines = File.ReadAllLines(userInput);
    List<string> blackList = lines.ToList();

    Console.Write("Введите пароль для проверки ");
    string? checkpassword = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(checkpassword))
    {
        Console.WriteLine("Пароль не может быть пустой или null");
        return;
    }

    bool isInBlackList = blackList.Contains(checkpassword);

    Console.WriteLine($"Пароль в черном списке: {(isInBlackList ? "ДА" : "НЕТ")}");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Ошибка: файл не найден.");
}
catch (IOException ex)
{
    Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
}

****************************************************************************************************************************
ТЗ: Мини - программа "Дневник тренировок"
****************************************************************************************************************************

string fileName = "training_log.txt";
int userChoise = 0;
do
{
    try
    {
        Console.Clear();
        Console.WriteLine("Главное меню");
        Console.WriteLine("1 - Добавить запись");
        Console.WriteLine("2 - Показать весь дневник");
        Console.WriteLine("3 - Выход");
        Console.Write("Выбирите действие: ");

        if (!int.TryParse(Console.ReadLine(), out userChoise))
        {
            Console.WriteLine("Ошибка: введите число!");
            Console.ReadKey();
            continue;
        }
        if (userChoise != 3 && userChoise != 2 && userChoise != 1)
        {
            Console.WriteLine("Ошибка: выберите 1, 2, 3");
            Console.ReadKey();
            continue;
        }

        switch (userChoise)
        {
            case 1:
                string continueWord = "";
                do
                {
                    Console.Write("Введите название тренировки, например, \"Бег 5 км\" или \"Силовая\": ");
                    string userInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(userInput))
                    {
                        Console.WriteLine("Строка не может быть пустой или null!");
                        Console.ReadKey();
                        continue;
                    }

                    string fullRecordInfo = $"\n[{$"{DateTime.Now:dd.MM.yyyy HH:mm}"}] - {userInput}";
                    File.AppendAllText(fileName, fullRecordInfo);

                    Console.Write("Хотите продолжить? y/n: ");
                    continueWord = Console.ReadLine().ToLower();

                    if (string.IsNullOrWhiteSpace(continueWord))
                    {
                        Console.WriteLine("Ошибка: введите y/n");
                        Console.ReadKey();
                        continue;
                    }
                } while (continueWord != "n");
                break;
            case 2:
                bool isExistFile = File.Exists(fileName);

                if (isExistFile)
                {
                    using (var reader = new StreamReader(fileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Дневник пуст. Начните с добавления записи.");
                    Console.ReadKey();
                }

                Console.Write("Нажмите Enter чтобы вернуться в меню");
                Console.ReadKey();
                Console.WriteLine();
                break;
            case 3:
                break;
        }
    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine($"Ошибка: файл не найден! {ex.Message}");
        Console.ReadKey();
    }
    catch (UnauthorizedAccessException ex)
    {
        Console.WriteLine($"Нет права доступа! {ex.Message}");
        Console.ReadKey();
    }
    catch (IOException ex)
    {
        Console.WriteLine($"Непредвиденная ошибка {ex.Message}");
        Console.ReadKey();
    }
} while (userChoise != 3);*/    

