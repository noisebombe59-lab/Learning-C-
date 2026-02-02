/*Задание 1: Найти Общие Теги (Пересечение)
Цель: Создать статический метод, который возвращает теги,
присутствующие в обоих наборах (SystemTags SystemTags UserTags).


HashSet<string> SystemTags = new HashSet<string> { "C#", "SQL", "OOP", "CSS" };
List<string> UserTags = new List<string> { "C#", "Java", "SQL", "Java", "HTML" };

HashSet<string> matchingTags = new HashSet<string>();
Console.Write("Тэги, которые присутствуют в обоих наборах: ");
Console.WriteLine(String.Join(", ", GetMatchingTags(SystemTags, UserTags)));

HashSet<string> missingTags = new HashSet<string>();
Console.Write("Новые (Отсутствующие) Теги: ");
Console.WriteLine(String.Join(", ", GetMissingTags(SystemTags, UserTags)));

static HashSet<string> GetMatchingTags(HashSet<string> systemTags, List<string> userTags)
{
    systemTags.IntersectWith(userTags);
    return systemTags;
}

//Задание 2: Найти Новые Теги(Разность)
//Цель:
//Создать статический метод, который возвращает теги, присутствующие только у пользователя,
//но отсутствующие в системе(UserTags SystemTags)
static HashSet<string> GetMissingTags(HashSet<string> systemTags, List<string> userTags)
{
    HashSet<string> copyUserTags = new HashSet<string>(userTags);

    copyUserTags.ExceptWith(systemTags);
    return copyUserTags;
}*/


