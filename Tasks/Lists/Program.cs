
using Lists_Tasks;

List<TaskItem> tasks = new List<TaskItem>();
while (true)
{
    Console.Clear();
    Console.WriteLine("Список команд: ");
    Console.WriteLine("------------------------\"n\"");
    Console.WriteLine("1. Добавить задачу");
    Console.WriteLine("2. Показать все");
    Console.WriteLine("3. Отметить выполненной");
    Console.WriteLine("4. Удалить завершенные");
    Console.WriteLine("5. Выход");
    Console.Write("Выбирите команду: ");

    string? userInput = Console.ReadLine();

    if (!int.TryParse(userInput, out int selectCommand))
    {
        Console.WriteLine("Ошибка, введите целое число!");
        Console.ReadKey();
        continue;
    }
    if (selectCommand != 1 && selectCommand != 2 && selectCommand != 3 && selectCommand != 4 && selectCommand != 5)
    {
        Console.WriteLine("Неверная команда!");
        Console.ReadKey();
        continue;
    }

    switch (selectCommand)
    {
        case 1:
            AddTasks(tasks);
            break;
        case 2:
            ShowAllTasks(tasks);
            break;
        case 3:
            MarkTaskDone(tasks);
            break;
        case 4:
            RemoveCompletedTasks(tasks);
            break;
        case 5:
            return;
    }
}
static void AddTasks(List<TaskItem> tasks)
{
    Console.Write("Введите описание задачи: ");
    string? description = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(description))
    {
        Console.WriteLine("Ошибка: Строка не может быть пустой или null!");
        Console.ReadKey();
        return;
    }

    TaskItem task = new TaskItem { Description = description };
    tasks.Add(task);
    Console.WriteLine($"[Успех] Задача '{description}' добавлена.");
    Console.WriteLine("Нажмите Enter, чтобы продолжить");
    Console.ReadKey();
}

static void ShowAllTasks(List<TaskItem> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("Список задач пуст!");
        Console.ReadKey();
        return;
    }
    foreach (var task in tasks)
    {
        if (task.IsDone == true)
        {
            Console.WriteLine($"[X] {task.Description}");
        }
        else
        {
            Console.WriteLine($"[ ] {task.Description}");
        }
    }
    Console.WriteLine("Нажмите Enter, чтобы продолжить");
    Console.ReadKey();
}

static void MarkTaskDone(List<TaskItem> tasks)
{
    Console.Write("Введите описание задачи для отметки выполненной: ");
    string? searchDescription = Console.ReadLine();

    TaskItem? foundTask = tasks.Find(n => n.Description == searchDescription);

    if (foundTask != null)
    {
        foundTask.IsDone = true;
        Console.WriteLine("Статус задачи: [Выполнено!]");
        Console.WriteLine("Нажмите Enter, чтобы продолжить");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Не найдено");
        Console.WriteLine("Нажмите Enter, чтобы продолжить");
        Console.ReadKey();
    }
}

static void RemoveCompletedTasks(List<TaskItem> tasks)
{
    int removed = tasks.RemoveAll(n => n.IsDone == true);
    Console.WriteLine($"Удалено {removed} объектов");
    Console.WriteLine("Нажмите Enter, чтобы продолжить");
    Console.ReadKey();
}