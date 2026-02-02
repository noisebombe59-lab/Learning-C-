using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Практические Кейсы
Кейс 1: Поиск Уникальных Ошибок (Фильтрация и Счет)
Напишите код, который обрабатывает список сообщений об ошибках из логов. Вам нужно найти:
Общее количество сообщений.
Количество уникальных типов ошибок.
Вывести только уникальные типы ошибок.

List<string> errorLogs = new List<string>
{
    "Error 404: Page Not Found",
    "Warning: Low Memory",
    "Error 500: Server Timeout",
    "Error 404: Page Not Found",
    "Warning: Low Memory",
    "Error 500: Server Timeout",
    "Fatal: Database Connection Lost"
};
List<string> uniqueErrors = new List<string>();
HashSet<string> errors = new HashSet<string>();

foreach (var error in errorLogs)
{
    if (errors.Add(error))
    {
        uniqueErrors.Add(error);
    }
}

Console.WriteLine($"Общее количество сообщений: {errorLogs.Count}");
Console.WriteLine($"Количество уникальных ошибок: {uniqueErrors.Count}");

foreach (var error in uniqueErrors)
{
    Console.WriteLine($"Список уникальных типов ошибок: {error}");
}

****************************************************************************************************************

Кейс 2: Проверка на Идентичность (Сравнение)
У вас есть два списка ID настроек, полученных от двух разных серверов (ServerA и ServerB).
Вам нужно быстро определить:
Идентичны ли эти два набора настроек (содержат ли они в точности одинаковые ID, независимо от порядка)?
Если они не идентичны, найдите ID, которые есть только на Сервере A (разность).


HashSet<int> serverA_settings = new HashSet<int> { 1, 5, 8, 11, 15 };
List<int> serverB_settings = new List<int> { 1, 12, 5, 8, 15 };
List<int> serverC_settings = new List<int> { 1, 12, 5, 8, 16 };

bool isSame = serverA_settings.SetEquals(serverB_settings);

HashSet<int> copyServerA_settings = new HashSet<int> (serverA_settings);
if (!isSame)
{
    copyServerA_settings.ExceptWith(serverC_settings);
    Console.WriteLine(String.Join(", ", copyServerA_settings));
}
else
{
    Console.WriteLine($"Идентичность наборов: {isSame}");
}

****************************************************************************************************************

Кейс 3 Смешанная Фильтрация (Базовый C#)
У вас есть список студентов (List<Student>). 
Вам нужно получить уникальный список ID только активных студентов.
Инструменты: Циклы foreach, List<T>, HashSet<T>.
Вам нужно:
Пройтись циклом foreach по исходному списку students.
Проверить каждого студента на активность (IsActive == true).
Использовать HashSet<int> для сбора и автоматической фильтрации уникальных ID активных студентов.


List<Student> students = new List<Student>
{
    new Student { Id = 10, IsActive = true },
    new Student { Id = 20, IsActive = false },
    new Student { Id = 10, IsActive = true }, // Дубликат ID
    new Student { Id = 30, IsActive = true },
    new Student { Id = 40, IsActive = false }
};

HashSet<int> activeUniqueIds = new HashSet<int>();

foreach (Student student in students)
{
    if(student.IsActive == true)
    {
        activeUniqueIds.Add(student.Id);
    }
}

Console.WriteLine("Уникальные ID активных студентов:");
Console.WriteLine(String.Join(", ", activeUniqueIds));*/