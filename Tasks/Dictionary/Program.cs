using System.Collections.Generic;

//Задание 1 (Неделя 5): Введение в Словари
/*Цель: Создать словарь "Страна -> Столица" и увидеть критическую ошибку.

Dictionary<string, string> capitals = new Dictionary<string, string> { { "Украина", "Киев" } };
capitals.Add("Россия", "Москва");
capitals.Add("Германия", "Берлин");
capitals.Add("Бразилия", "Бразилья");
capitals.Add("Буларусь", "Минск");
capitals.Add("Франция", "Париж");

int count = capitals.Count;
Console.WriteLine("Количество пар: " + count);

string capital = capitals["Москва"];
Console.WriteLine("Существующая столица: " + capital);*/

// ***********************************************************************************************************
//Задание 2: Безопасный Доступ и Итерация
//Цель: Научиться безопасно работать с ключами (ContainsKey) и выводить все содержимое словаря
/*(foreach с KeyValuePair).

Dictionary<string, string> capitals = new Dictionary<string, string> { { "Украина", "Киев" } };
capitals.Add("Россия", "Москва");
capitals.Add("Германия", "Берлин");
capitals.Add("Бразилия", "Бразилья");
capitals.Add("Буларусь", "Минск");
capitals.Add("Франция", "Париж");

if (!capitals.ContainsKey("Марс"))
{
    Console.WriteLine("Ключ \"Марс\" не найден!");
}
Console.WriteLine();

foreach (KeyValuePair<string, string> capital in capitals)
{
    Console.WriteLine($"Ключ: {capital.Key}, Значение: {capital.Value}");
}*/
// ***********************************************************************************************************

/*Задание 3: Изменение и Продвинутый Поиск (TryGetValue)
Цель: Самостоятельно применить безопасный метод .TryGetValue() и обновить значение.

Dictionary<string, string> capitals = new Dictionary<string, string> { { "Россия", "Москва" } };
Console.WriteLine($"Результат ДО: [Россия] " );

capitals["Россия"] = "Санкт-Питербург";

if (capitals.TryGetValue("Россия", out string? result))
{
    Console.WriteLine($"Результат после: [{result}]");
}
Console.WriteLine();
if (!capitals.TryGetValue("Италия", out string? keyNonFound))
{
    Console.WriteLine($"Ошибка: ключ не найден");
}*/
// ***********************************************************************************************************


//Задание 4: Словарь "Проект -> Список Участников"
//Цель: Овладеть управлением коллекцией(List), которая является Значением в Словаре,
//и закрыть пробел по методу .Remove().

/*Шаги (4 ключевых операции):
Инициализация: Создать словарь projectTeams и добавить три проекта: "Landing Page" ["Алиса", "Борис"],
"Backend API" ["Игорь", "Олег"], "Testing" ["Маша"].

Добавление в Значение: Добавить участника "Катя" в команду "Landing Page".
Удаление из Значения: Удалить участника "Игоря" из команды "Backend API".
Удаление Ключа: Удалить весь проект "Testing" из словаря (используя .Remove()).
Вывод: Вывести всю команду "Landing Page" и "Backend API", чтобы подтвердить изменения.

Dictionary<string, List<string>> projectTeams = new Dictionary<string, List<string>>();

projectTeams.Add("Landing Page", ["Алиса", "Борис"]);
projectTeams.Add("Backend API", ["Игорь", "Олег"]);
projectTeams.Add("Testing", ["Маша"]);

if (projectTeams.TryGetValue("Landing Page", out List<string>? teamLanding))
{
    teamLanding.Add("Катя");
}
if (projectTeams.TryGetValue("Backend API", out List<string>? removedMember))
{
    removedMember.Remove("Игорь");
}
if (projectTeams.TryGetValue("Testing", out List<string> removeAll))
{
    projectTeams.Remove("Testing");
    Console.WriteLine($"Проект Testing Удален");
}

foreach (KeyValuePair<string, List<string>> team in projectTeams)
{
    Console.WriteLine($"Ключ: {team.Key}, Значение: {String.Join(", ", team.Value)} ");
}*/
// ***********************************************************************************************************

/*Задание 5: Вложенные Словари (Сложная Навигация)
Цель: Научиться безопасно навигироваться по двухуровневой базе данных.
Шаги, которые должны быть в вашем коде (3 ключевых операции):
Инициализация: Создайте словарь WorldData.

Добавьте "Европа" -> (внутренний словарь: "Франция" -> 67, "Германия" -> 83).

Добавьте "Азия" -> (внутренний словарь: "Китай" -> 1400, "Индия" -> 1380).

Двухуровневый Безопасный Доступ: Безопасно получите население "Германии".
Используйте .TryGetValue() дважды (для Континента, а затем для Страны).

Итерация по Вложенной Структуре: Используйте два вложенных цикла foreach для вывода всех данных в формате:
Континент: [Имя] -> Страна: [Имя] -> Население: [Число].

Dictionary<string, Dictionary<string, int>> worldData = new Dictionary<string, Dictionary<string, int>>();
worldData.Add("Европа", new Dictionary<string, int> {
    { "Франция", 67 },
    { "Германия", 83 }
});
worldData.Add("Азия", new Dictionary<string, int>
{
    {"Китай", 1400 },
    {"Индия", 1380 }
});

if (worldData.TryGetValue("Европа", out var populationOfGerman))
{
    if (populationOfGerman.TryGetValue("Германия", out var getPopulationOfGerman))
    {
        foreach (KeyValuePair<string, Dictionary<string, int>> continent in worldData)
        {
            foreach (KeyValuePair<string, int> country in continent.Value)
            {
                Console.WriteLine($"Континент: {continent.Key}, Страна: {country.Key}, Население: {country.Value}");
            }
        }
    }
    else
    {
        Console.WriteLine("Данной страны нет в списке!");
    }
}
else
{
    Console.WriteLine("Данного континента нет списке!");
}*/
// ***********************************************************************************************************