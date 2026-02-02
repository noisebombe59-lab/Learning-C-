using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Практика: Операции и Эффективность
 * Задача 1: Объединение (Union)
У вас есть список привилегированных ID пользователей (Admins) и ID пользователей, 
которые подписаны на рассылку (NewsletterSubscribers). Используйте UnionWith,
чтобы получить один уникальный список всех пользователей, которым нужно отправить важное сообщение.

HashSet<int> admins = new HashSet<int> { 101, 205, 303 };
HashSet<int> newsletterSubscribers = new HashSet<int> { 303, 407, 509, 101 };

newsletterSubscribers.UnionWith(admins);

Console.WriteLine($"Список пользователей, которым нужно отправить письмо: {String.Join(", ", newsletterSubscribers)}"); */

//***************************************************************************************************************

//Задача 2: Разность (Except)
/*У вас есть полный список сотрудников (AllStaff) и список сотрудников,
 * которые уже прошли ежегодное обучение
 * (TrainedStaff). Используйте ExceptWith, чтобы найти и вывести ID сотрудников,
 * которым все еще нужно пройти обучение.

HashSet<int> allStaff = new HashSet<int> { 10, 20, 30, 40, 50 };
HashSet<int> trainedStaff = new HashSet<int> { 10, 30, 40 };

allStaff.ExceptWith(trainedStaff);

Console.WriteLine($"ID: [{String.Join(", ", allStaff)}] кому осталось пройти обучение");

//***************************************************************************************************************

Задача 3: Условное Удаление (RemoveWhere)
У вас есть список ID продуктов.
Удалите из набора все ID, которые являются четными числами (имитируя удаление неактивных продуктов).

HashSet<int> productIds = new HashSet<int> { 1, 5, 12, 18, 23, 30, 41 };

productIds.RemoveWhere(x => x % 2 == 0);

Console.WriteLine($"ID после удаления: [{String.Join(", ", productIds)}]");

//***************************************************************************************************************

*/