using System.Text;

using System.Diagnostics;

/*Console.WriteLine("string");

Console.WriteLine("*****************************************************************************");



string name = "Alice";

string greeting  = "Hello " + name;



Console.WriteLine(greeting);

Console.WriteLine(name);

Console.WriteLine();



****************************************************************************************



Console.WriteLine("*****StringBulider");

Console.WriteLine("****************************************************************************************");



StringBuilder sb = new StringBuilder("Initial Message ");

sb.Append("Added text ").AppendLine("New Line");

string result = sb.ToString();



Console.WriteLine(result);
static void CreateLogString(int count)
{
    string test = "";
    Stopwatch sw = Stopwatch.StartNew();

    for (int i = 1; i < count; i++)
    {
        test += $"[{i}] Log Entry.\n";
    }
    Console.WriteLine(test);

    sw.Stop();

    Console.WriteLine($"Время string: {sw.ElapsedMilliseconds} мс");
    Console.WriteLine($"Точнее: {sw.Elapsed.TotalSeconds} сек");
    Console.WriteLine($"Ещё точнее: {sw.ElapsedTicks} тиков");
}

static void CreateLogStringBuilder(int count)
{
    Stopwatch sw = Stopwatch.StartNew();
    StringBuilder test = new StringBuilder("");

    for (int i = 1; i < count; i++)
    {
        test.AppendLine($"[{i}] Log Entry.");
    }

    string result = test.ToString();

    Console.WriteLine(result);
    sw.Stop();

    Console.WriteLine($"Время StringBuilder: {sw.ElapsedMilliseconds} мс");
    Console.WriteLine($"Точнее: {sw.Elapsed.TotalSeconds} сек");
    Console.WriteLine($"Ещё точнее: {sw.ElapsedTicks} тиков");
}
CreateLogStringBuilder(50000);
CreateLogString(50000);

****************************************************************************************

Интерполяция строк: Объяви переменные level (int) и player (string). 
Используй интерполяцию строк ($"") для создания сообщения: "Игрок [ИМЯ] достиг [УРОВЕНЬ] уровня!".

string player = "Иван";
int level = 12;

Console.WriteLine($"Игрок {player} достиг {level} уровня!");

****************************************************************************************

Валидация: Запроси у пользователя ввод "секретного кода" и сохрани его в переменной input.
Используй метод string.IsNullOrWhiteSpace() в условии if, чтобы проверить,
не пустой ли ввод или состоит из одних пробелов. Выведи соответствующее сообщение.

Console.Write("Введите секретный код: ");
string? input = Console.ReadLine();

if (string.IsNullOrWhiteSpace(input))
{
    // Строка НЕвалидна
    Console.WriteLine("Строка не может быть пустой или состоять только из пробелов!");
}
else
{
    // Строка валидна
    Console.WriteLine($"Секретный код '{input}' принят.");
}


****************************************************************************************


Задача: Нормализация Имени Пользователя
Напиши метод NormalizeName(string input):
Метод должен сначала использовать .Trim() для удаления лишних пробелов по краям.
Затем используй string.IsNullOrWhiteSpace() для проверки:
если строка пуста после обрезки, верни ошибку "Имя не может быть пустым.".
Далее, используй цикл foreach и класс Char для проверки:
если имя содержит хотя бы одну цифру (Char.IsDigit), верни ошибку
"Имя не должно содержать цифр.".
Если все проверки пройдены, верни очищенное и проверенное имя.

static string NormalizeName(string input)
{
    input = input.Trim();
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Имя не может быть пустым.");
        return "";
    }

    foreach (char c in input)
    {
        if (char.IsDigit(c))
        {
            Console.WriteLine("Имя не должно содержать цифр.");
            return "";
        }
    }
    return input;
}

string input = NormalizeName("Кристина ");
Console.WriteLine(input); */