using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Задачи на Практику

/*Задача 1: Проверка Прав Доступа (Надмножество)
Напишите код, который проверяет, имеет ли текущий пользователь все требуемые права.
Используйте метод IsSupersetOf.

HashSet<string> userPermissions = new HashSet<string> { 
    "Чтение",
    "Запись",
    "Администрирование",
    "Создание_Отчета" };
List<string> requiredPermissions = new List<string> { 
    "Администрирование",
    "Создание_Отчета" };

bool hasAllRights = userPermissions.IsSupersetOf(requiredPermissions);

Console.WriteLine($"У пользователя есть все необходимые права: {hasAllRights}");

//************************************************************************************************************


Задача 2: Быстрая Фильтрация(Перекрытие)
Вам нужно быстро определить, является ли пакет данных "интересным".
Пакет интересен, если он содержит хотя бы один из отслеживаемых маркеров.
Используйте метод Overlaps

HashSet<int> trackedMarkers = new HashSet<int> { 10, 20, 30, 50 };
List<int> currentPacketMarkers = new List<int> { 5, 8, 20, 45, 60 };

bool isInteresting = trackedMarkers.Overlaps(currentPacketMarkers);

Console.WriteLine($"Содердит ли пакет хоть один маркер?: {isInteresting}");

//************************************************************************************************************

*/


