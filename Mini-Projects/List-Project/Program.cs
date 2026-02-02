using System;
using System.Collections.Generic;

namespace ListsBasics
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("=== List<T> демо ===");
                Console.WriteLine("1. Работа с числами (сумма, максимум, фильтр <5)");
                Console.WriteLine("2. Очистка строк (RemoveAll IsNullOrWhiteSpace)");
                Console.WriteLine("3. Поиск первого > 100");
                Console.WriteLine("4. Методы: Find/FindAll/RemoveAll/Sort");
                Console.WriteLine("5. Индексы: IndexOf/LastIndexOf/FindIndex/FindLastIndex");
                Console.WriteLine("6. Фильтрация и статистика (диапазон, среднее, топ-3)");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                var key = Console.ReadLine();
                Console.WriteLine();

                switch (key)
                {
                    case "1": NumbersWorkDemo(); break;
                    case "2": CleanStringsDemo(); break;
                    case "3": SearchValuesDemo(); break;
                    case "4": ListMethodsDemo(); break;
                    case "5": ProductsIndexDemo(); break;
                    case "6": FilteringStatsDemo(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Неизвестная команда.\n");
                        break;
                }
            }
        }

        static void NumbersWorkDemo()
        {
            var numbers = new List<int> { 5, 2, 8, 1, 9 };
            int sum = 0;
            int maxNum = numbers[0];

            foreach (var num in numbers) sum += num;
            foreach (var num in numbers) if (num > maxNum) maxNum = num;

            // Важно: не удаляем в foreach; используем RemoveAll
            numbers.RemoveAll(x => x < 5);

            numbers.Sort();
            Console.WriteLine("Сумма: " + sum);
            Console.WriteLine("Максимум: " + maxNum);
            Console.WriteLine("Отфильтровано и отсортировано: " + string.Join(", ", numbers));
            Console.WriteLine();
        }

        static void CleanStringsDemo()
        {
            var strings = new List<string> { "hello", "", "world", null, "!" };
            var trimmed = new List<string>(strings);
            int removed = trimmed.RemoveAll(s => string.IsNullOrWhiteSpace(s));

            Console.WriteLine("Удалено пустых/пробельных: " + removed);
            Console.WriteLine("Исходный список (для сравнения): " + string.Join(", ", strings));
            Console.WriteLine("Очищенный: " + string.Join(", ", trimmed));
            Console.WriteLine();
        }

        static void SearchValuesDemo()
        {
            var values = new List<int> { 45, 120, 78, 200, 15 };
            int firstOver100 = values.Find(n => n > 100);
            Console.WriteLine($"Первый объект > 100: {firstOver100}");
            Console.WriteLine();
        }

        static void ListMethodsDemo()
        {
            var numbers = new List<int> { 5, 2, 8, 1, 9, 3, 5, 2 };
            int firstGreaterThanFive = numbers.Find(n => n > 5);
            var lessThanFour = numbers.FindAll(n => n < 4);

            numbers.RemoveAll(n => n == 5);
            numbers.Sort();

            Console.WriteLine("Первое число > 5: " + firstGreaterThanFive);
            Console.WriteLine("Числа < 4: " + string.Join(", ", lessThanFour));
            Console.WriteLine("Отсортированный список (без 5): " + string.Join(", ", numbers));
            Console.WriteLine();
        }

        static void ProductsIndexDemo()
        {
            var products = new List<string> { "apple", "banana", "cherry", "banana", "date" };
            int firstBanana = products.IndexOf("banana");
            int lastBanana = products.LastIndexOf("banana");
            int firstLenOver5 = products.FindIndex(p => p.Length > 5);
            int lastStartsWithB = products.FindLastIndex(p => p.StartsWith("b"));

            Console.WriteLine("Индекс первого \"banana\": " + firstBanana);
            Console.WriteLine("Индекс последнего \"banana\": " + lastBanana);
            Console.WriteLine("Индекс первого продукта длинее 5: " + firstLenOver5);
            Console.WriteLine("Индекс последнего продукта на 'b': " + lastStartsWithB);
            Console.WriteLine();
        }

        static void FilteringStatsDemo()
        {
            var numbers = new List<int> { 12, 5, 8, 130, 44, 1, 0, 89 };

            var between10and100 = numbers.FindAll(x => x > 10 && x < 100);
            Console.WriteLine("Диапазон 10..100: " + string.Join(", ", between10and100));

            numbers.RemoveAll(x => x <= 0);
            Console.WriteLine("После удаления <=0: " + string.Join(", ", numbers));

            double average = numbers.Count > 0 ? (double)Sum(numbers) / numbers.Count : 0;
            Console.WriteLine("Среднее значение: " + average.ToString("0.##"));

            var top3 = new List<int>(numbers);
            top3.Sort();
            top3.Reverse();

            Console.Write("Топ-3: ");
            for (int i = 0; i < 3 && i < top3.Count; i++)
                Console.Write(top3[i] + (i < 2 ? " " : ""));
            Console.WriteLine("\n");
        }

        static int Sum(List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++) sum += list[i];
            return sum;
        }
    }
}