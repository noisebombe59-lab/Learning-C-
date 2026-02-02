using System.Threading;
using Dictionary_project;

Dictionary<int, TaskItem2> taskRepository  = new Dictionary<int, TaskItem2>();

taskRepository.Add(101, new TaskItem2
{
    Id = 101,
    Description = "Завершить финальный проект",
    IsCompleted = false,
});
taskRepository.Add(102, new TaskItem2
{
    Id = 102,
    Description = "Подготовить отчет",
    IsCompleted = false,
});

if (taskRepository.TryGetValue(101, out var isCompleted))
{
    isCompleted.IsCompleted = true;
    Console.WriteLine($"ID: {isCompleted.Id}, Описание: {isCompleted.Description}, Статус: {isCompleted.IsCompleted}");
}
else
{
    Console.WriteLine("Ключ не существует!");
}

Console.WriteLine();

foreach (KeyValuePair<int, TaskItem2> item in taskRepository)
{ 
    Console.WriteLine($"ID: {item.Key}, Описание: {item.Value.Description}, Статус: {item.Value.IsCompleted}");
}
