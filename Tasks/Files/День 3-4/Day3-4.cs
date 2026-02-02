using System;
using System.Collections.Generic;
using System.Text;

/****************************************************************************************************************************
Комбинирование
****************************************************************************************************************************

string path1 = "data";
string path2 = "setting";
string path3 = "config.init";

string fullPath = Path.Combine(path1, path2, path3);

Console.WriteLine(fullPath);

****************************************************************************************************************************
Существование каталога
**************************************************************************************************************************

try
{
    Directory.CreateDirectory("temp_data");
**************************************************************************************************************************
Имя Файла
**************************************************************************************************************************

    string fullPath = "C:/Project/Reports/final_report.docx";
    string getFileName = Path.GetFileName(fullPath);
    string getExtension = Path.GetExtension(fullPath);

    Console.WriteLine(getFileName);
    Console.WriteLine(getExtension);
**************************************************************************************************************************
Удаление
**************************************************************************************************************************
    Directory.Delete("temp_data");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Файл не существует {ex.Message}");
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"Нет прав доступа к файлу или папке {ex.Message}");
}
catch (IOException ex)
{
    Console.WriteLine($"Непредвиденная ошибка [{ex.Message}]");
}

**************************************************************************************************************************
 Задача 1: Создание структуры Логирования
**************************************************************************************************************************

try
{
    string mainFolder = "application_logs";
    string logFileName = "log_file.txt";
    string nestedPathFolder = DateTime.Now.ToString("yyyy-MM-dd");

    string fullFolderPath = Path.Combine(mainFolder, nestedPathFolder);
    Directory.CreateDirectory(fullFolderPath);

    string fullPath = Path.Combine(fullFolderPath, logFileName);

    string sestemMessage = "Тест логгирования, все ОК.";
    File.AppendAllText(fullPath, sestemMessage);

    Console.WriteLine($"Записано в файл: {sestemMessage}");
    Console.WriteLine($"[ПУТЬ] Файл создан по адресу: {fullPath}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Файл не найден {ex.Message}");
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"Нет прав доступа к файлу или папке {ex.Message}");
}
catch (IOException ex)
{
    Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
}


**************************************************************************************************************************
 Задача 2: Копирование и Перемещение с Валидацией
**************************************************************************************************************************

try
{
    string fileName = "source.txt";
    File.WriteAllText(fileName, "Это исходный файл.");

    Console.Write("Введите имя папки назначения (например, Archive): ");
    string? folderName = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(folderName))
    {
        Console.WriteLine("Ошибка: название папки не может быть пустым!");
        return;
    }
    Directory.CreateDirectory(folderName);

    string fullPath = Path.Combine(folderName, fileName);

    bool fileExist = File.Exists(fileName);

    if (!fileExist)
    {
        return;
    }

    Console.Write("Копировать (C) или Переместить (M)?: ");
    string? copyOrMove = Console.ReadLine().ToLower();

    if (string.IsNullOrWhiteSpace(copyOrMove))
    {
        Console.WriteLine("Некорректный ввод, введите (C)/(M)");
        return;
    }

    if (copyOrMove == "m")
    {
        File.Move(fileName, fullPath, true);
    }
    else if (copyOrMove == "c")
    {
        File.Copy(fileName, fullPath, true); 
    }

    Console.WriteLine(fullPath);
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"Нет прав доступа к файлу или папке: {ex.Message}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Файл не найден: {ex.Message}");
}
catch (IOException ex)
{
    Console.WriteLine($"Непредвиденная ошибка работы с файлами: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Непредвиденная ошибка работы с данными: {ex.Message}");
}

**************************************************************************************************************************
    Задача 3: Анализатор Метаданных Файла
*************************************************************************************************************************

try
{
    Console.Write("Введите путь к файлу (например, source.txt): ");
    string? filePath = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(filePath))
    {
        Console.WriteLine("Строка не может быть пустой или null!");
        return;
    }
    else if (!File.Exists(filePath))
    {
        Console.WriteLine("Файл не найден");
        return;
    }
    else
    {
        FileInfo fileInfo = new FileInfo(filePath);

        string fileName = fileInfo.Name;
        string extension = fileInfo.Extension;
        double fileSize = fileInfo.Length / 1024.0;
        DateTime lastChange = fileInfo.LastWriteTime;

        Console.WriteLine($"Имя файла: {fileName}, Расширение: {extension}, Размер файла: {fileSize:F2}КБ,  Дата последнего изменения: {lastChange}");
    }
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"Нет прав доступа к файлу или папке {ex.Message}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}
catch (IOException ex)
{
    Console.WriteLine($"Непредвиденная ошибка {ex.Message}");
}*/

