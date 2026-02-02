/*using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ValueTypes_ReferenceTypes.Combine_Operators
{
    public class Programm
    {
        static void Main(string[] args)
        {

            Order fullOrder = new Order
            {
                ID = 1,
                Castomer = new Castomer
                {
                    Name = "NoiseBombe",
                    Email = "sadfsdfrrr33@gmail.com"
                },
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductName = "Книга", Price = 25.50m },
                    new OrderItem { ProductName = "Ручка", Price = 5.00m }
                }
            };

            Order partialOrder = new Order
            {
                ID = 2,
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductName = "Карандаш", Price = 45.50m },
                    new OrderItem { ProductName = "Пика", Price = 66.00m }
                }
            };

            Order? nullOrder = null;

            Console.WriteLine("=== Проверка GetCastomerEmail ===");

            // Сценарий A: Email присутствует
            string? emailOk = GetCastomerEmail(fullOrder);
            Console.WriteLine($"Email (OK): {emailOk}"); // Вывод: sadfsdfrrr33@gmail.com

            // Сценарий B: Castomer равен null (должен вернуть "unknown")
            string? emailNull = GetCastomerEmail(partialOrder);
            Console.WriteLine($"Email (Null): {emailNull}"); // Вывод: unknown

            // Сценарий C: Сам Order равен null (должен вернуть "unknown")
            string? emailOrderNull = GetCastomerEmail(nullOrder);
            Console.WriteLine($"Email (Order Null): {emailOrderNull}"); // Вывод: unknown

            Console.WriteLine("\n=== Проверка GetOrderPrice ===");

            // Сценарий D: Цена присутствует
            decimal? priceOk = GetOrderPrice(fullOrder.Items[0]);
            Console.WriteLine($"Цена (OK): {priceOk}"); // Вывод: 25.50

            // Сценарий E: Объект OrderItem равен null (должен вернуть 0)
            OrderItem? nullItem = null;
            decimal? priceNull = GetOrderPrice(nullItem);
            Console.WriteLine($"Цена (Item Null): {priceNull}"); // Вывод: 0

            Console.WriteLine("\n=== Проверка GetItemList ===");

            // Сценарий F: Список существует и содержит элементы
            List<OrderItem>? listOk = GetItemList(fullOrder);
            Console.WriteLine($"Список (OK), кол-во: {listOk?.Count}"); // Вывод: 2

            // Сценарий G: Items равен null (должен вернуть новый пустой список, count = 0)
            List<OrderItem>? listNull = GetItemList(partialOrder);
            Console.WriteLine($"Список (Null Items), кол-во: {listNull?.Count}"); // Вывод: 0

            // Сценарий H: Сам Order равен null (должен вернуть новый пустой список, count = 0)
            List<OrderItem>? listOrderNull = GetItemList(nullOrder);
            Console.WriteLine($"Список (Order Null), кол-во: {listOrderNull}");
        }

        public static string? GetCastomerEmail(Order? email)
        {
            return email?.Castomer?.Email ?? "unknown";
        }

        public static decimal? GetOrderPrice(OrderItem? price)
        {
            return price?.Price ?? 0;
        }

        public static List<OrderItem>? GetItemList(Order? orderList)
        {
            return orderList?.Items ?? new List<OrderItem>();
        }
    }

    public class Order
    {
        public int ID { get; set; }
        public Castomer? Castomer { get; set; }
        public List<OrderItem>? Items { get; set; }
    }

    public class Castomer
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }

    public class OrderItem
    {
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
    }
}*/
