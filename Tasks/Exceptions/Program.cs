/*static void GetNumbers()
{
    while (true)
    {
        Console.Write("Введите первое число: ");
        if (!int.TryParse(Console.ReadLine(), out int first))
        {
            Console.WriteLine("Ошибка: первое не число!");
            continue;
        }
        Console.Write("Введите второе число: ");
        if (!int.TryParse(Console.ReadLine(), out int second))
        {
            Console.WriteLine("Ошибка: второе не число!");
            continue;
        }
        if (second == 0)
        {
            throw new DivideByZeroException("Ошибка: на ноль делить нельзя!");
        }
        Console.WriteLine($"Первое число: {first}, Второе число: {second}");
        break; // всё ок
    }
}
try
{
    while (true)
    {
        GetNumbers(); // ← ВЫЗЫВАЕМ МЕТОД!
    }
}
catch (DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
}

static void DemonstrateFinally()
{
    try
    {
        throw new Exception("Тестовая ошибка.");
    }
    finally
    {
        Console.WriteLine("Операция очистки завершена.");
    }
}

****************************************************************************************************

3. Задача (15-30 мин)
Задача: Валидатор ввода пользователя (Парсинг)
Напишите метод GetValidNumber(), который будет:
Использовать цикл do-while для повторного запроса ввода.
Внутри цикла запрашивать у пользователя ввод числа.
Оборачивать попытку преобразования (используя int.Parse()) в try-catch.
Если преобразование не удалось, перехвати FormatException.
Выведите: "Неверный формат ввода. Введите только число." и вернитесь к повторному запросу.
Если число успешно преобразовано, выйдите из цикла и верните его.
Используйте блок finally (внутри цикла), чтобы вывести "Попытка ввода завершена.".


static int GetValidNumber()
{
    do
    {
        try
        {
            Console.Write("Введите число: ");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                throw new FormatException("Неверный формат ввода. Введите только число.");
            }
            return number;
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Попытка ввода завершена.");
        }
    } while (true);
}

int result = GetValidNumber();
Console.WriteLine($"Введенное число: {result}");*/
