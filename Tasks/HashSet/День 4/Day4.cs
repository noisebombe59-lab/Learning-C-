using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Кейс-Задачи на Комбинацию Коллекций
Задача 1: Фильтрация Дубликатов с Сохранением Порядка
У вас есть длинный список логов действий пользователя (logEntries),
и вам нужно получить уникальный список ID пользователей, сохранив порядок их первого появления в логе.
Проблема: HashSet<T> не сохраняет порядок. List<T> сохраняет, но поиск дубликатов в нем медленный.
Решение (Гибрид): Используйте HashSet<T> как быстрый фильтр, а List<T> — для сбора и сохранения порядка.

List<int> logEntries = new List<int> { 50, 10, 20, 50, 30, 10, 40, 20 };
List<int> uniqueOrderedUsers = new List<int>(); // Хранит результат с порядком
HashSet<int> users = new HashSet<int>();

foreach( int userID in logEntries)
{
    if (users.Add(userID))
    {
        uniqueOrderedUsers.Add(userID);
    }
}

Console.WriteLine("Уникальные ID в порядке первого появления:");
Console.WriteLine(String.Join(", ", uniqueOrderedUsers));

//********************************************************************************************************

Задача 2: Быстрая Проверка Доступа к Упорядоченному Списку
У вас есть List<Product>, содержащий все 100 000 товаров магазина.
Вам нужно быстро проверить, находится ли каждый из 500 ID товаров в черном списке (BannedIds).
Проблема: Каждый раз, когда мы проверяем product.BannedIds.Contains(product.Id),
мы рискуем получить $O(N)$ для List<T>.Решение: Преобразуйте меньший, 
но часто используемый список для поиска (BannedIds) в HashSet<T>. 

// 100 000 товаров, для простоты берем 5
List<int> productIdsToCheck = new List<int> { 101, 505, 990, 505, 101 };
// Черный список, который часто проверяется.
List<int> bannedIdsList = new List<int> { 505, 999, 1000 };
HashSet<int> chechID = new HashSet<int>(bannedIdsList);

foreach(int id in productIdsToCheck)
{
    if (chechID.Contains(id))
    {
        Console.WriteLine($"- ID {id}: Запрещен!");
    }
}

//********************************************************************************************************

Задача 3: Найти Общие Элементы (Слияние Коллекций)
У вас есть:
List<string> databaseEntries (1000 элементов) — список ID, полученных из одной системы.
List<string> externalIds (500 элементов) — список ID, полученных из внешней системы.
Вам нужно создать новый, уникальный список ID, которые присутствуют в ОБЕИХ коллекциях,
и отфильтровать все остальные элементы из databaseEntries.
Шаги:
Создайте HashSet<string> из одной из коллекций (например, databaseEntries).
Используйте метод IntersectWith для нахождения общих элементов.
Выведите результат.

List<string> databaseEntries = new List<string> { "A1", "B2", "C3", "D4", "E5" };
List<string> externalIds = new List<string> { "C3", "D4", "F6", "G7", "A1" };
HashSet<string> uniqueCollection = new HashSet<string>(databaseEntries);

uniqueCollection.IntersectWith(externalIds);


Console.WriteLine($"Cписок databaseEntries: {String.Join(", ", databaseEntries)}");
Console.WriteLine($"Cписок externalIds: {String.Join(", ", externalIds)}");
Console.WriteLine($"Общий уникальный список: {String.Join(", ", uniqueCollection)}");*/



