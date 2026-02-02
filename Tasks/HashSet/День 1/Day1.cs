using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/*Упражнения (Синтаксис и Базовые Операции)
Задача 1: Создание и Добавление Создайте HashSet<string> с названием planets.
Добавьте в него: "Марс", "Земля", "Юпитер".
Затем попробуйте еще раз добавить "Марс".
Выведите количество элементов в итоге.

HashSet<string> planets = new HashSet<string>();
planets.Add("Марс");
planets.Add("Земля");
planets.Add("Юпитер");

bool isAdded = planets.Add("Марс");

Console.WriteLine($"Попытка добавить Марс: {isAdded}");
Console.WriteLine($"Всего планет: {planets.Count}");
//**************************************************************************************************************
//Задача 2: Проверка Наличия Используя тот же набор planets, напишите код,
//который проверяет, есть ли в нем "Земля" и "Плутон". Выведите результат проверки.

bool hasEarth = planets.Contains("Земля");
bool hasPluto = planets.Contains("Плутон");

Console.WriteLine($"Проверка наличия Земли: {hasEarth}");
Console.WriteLine($"Проверка наличия Плутона: {hasPluto}");*/

//**************************************************************************************************************
//Задача 3: Инициализация из Списка У вас есть List<int> с числами 1, 5, 2, 5, 3, 1, 4.
//Создайте HashSet<int>, используя этот список в конструкторе, и выведите количество элементов в HashSet<int>.

/*List<int> numbers = new List<int> { 1, 5, 2, 5, 3, 1, 4 };
HashSet<int> withoutDublicates = new HashSet<int>(numbers);

Console.WriteLine($"Исходный список: {numbers.Count} элементов");
Console.WriteLine($"Список без дубликатов: {withoutDublicates.Count} элементов");*/

//**************************************************************************************************************


/*Задачи(Применение)
 * 
Задача 4: Уникальные Слова в Предложении
Напишите программу, которая принимает строку-предложение, разбивает его на слова
(игнорируя регистр, например, "Привет" и "привет" — это одно и то же слово)
и использует HashSet<T>, чтобы найти и вывести количество уникальных слов в этом предложении.

string userInput = Console.ReadLine().ToLower();

if (string.IsNullOrWhiteSpace(userInput))
{
    Console.WriteLine("Строка не может быть пустой или null!");
}

string[] splited = userInput.Split(' ');
HashSet<string> countUniqueWords = new HashSet<string>(splited);

Console.WriteLine($"Количество уникальных слов: {countUniqueWords.Count}");*/

//**************************************************************************************************************

/*Задача 5: Операция Пересечения(Общие элементы)
У вас есть два списка пользователей (например, покупатели в "Черную пятницу" и покупатели в "Киберпонедельник").
Используйте операцию IntersectWith, чтобы быстро найти и вывести ID пользователей,
которые совершили покупки в оба дня.

HashSet<int> blackFridayBuyers = new HashSet<int> { 101, 105, 102, 108 };
List<int> cyberMondayBuyers = new List<int> { 102, 106, 101, 107 };

blackFridayBuyers.IntersectWith(cyberMondayBuyers);

Console.WriteLine("Покупатели в оба дня (Пересечение):");
foreach (var buy in blackFridayBuyers)
{
    Console.WriteLine($"ID: {buy}");
}*/

//**************************************************************************************************************

//Корректная Работа с Пользовательскими Классами


// Проверочный код:
// Создаем два товара с одинаковым Артикулом, но разным Именем.
// Они должны считаться ОДИНАКОВЫМИ для HashSet<T>.

/*HashSet<Товар> каталог = new HashSet<Товар>();

Товар a = new Товар { Артикул = 100, Имя = "Телефон A" };
Товар b = new Товар { Артикул = 100, Имя = "Телефон Б (дубликат)" };
Товар c = new Товар { Артикул = 101, Имя = "Ноутбук" };

каталог.Add(a);
bool addedDuplicate = каталог.Add(b); // Попытка добавить дубликат (по Артикулу)
каталог.Add(c);

Console.WriteLine($"Удалось добавить 'Товар Б' (Артикул 100)? {addedDuplicate}");
Console.WriteLine($"Итого уникальных товаров в каталоге: {каталог.Count}");*/







