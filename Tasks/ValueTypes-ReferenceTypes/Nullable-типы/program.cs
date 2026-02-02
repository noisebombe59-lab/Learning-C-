/*using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTypes_ReferenceTypes.Nullable_типы
{
    Задание 2: Nullable типы

    public class Program
    {
        static void Main(string[] args)
        {
            int getValue = GetValueOrDefault(5);
            string correctDate = FormatDate(DateTime.Now);

            Console.WriteLine($"Данные значения: {getValue}");
            Console.WriteLine($"Данные о дате: {correctDate}");
        }

        public static int GetValueOrDefault(int? number)
        {

            return number ?? 0;
        }

        public static string FormatDate(DateTime? date)
        {

            return date?.ToString("dd.MM.yyyy") ?? "Not Set" ;
        }
    }
}*/
