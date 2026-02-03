1. Делегаты: Основы

Делегат — это «указатель» на метод. Это тип данных, который говорит: «Я могу хранить любой метод, который принимает [эти аргументы] и возвращает [этот тип]».

Custom Delegates: Как объявить свой delegate.

Multicast Delegates: Как один делегат может вызывать цепочку методов (операторы += и -=).

    // Объявление типа делегата (редко, но нужно знать синтаксис)
    public delegate void LogHandler(string message);

    public class Logger
    {
        public void ToConsole(string msg) => Console.WriteLine($"[LOG]: {msg}");
    }

    // Использование:
    var logger = new Logger();
    LogHandler handler = logger.ToConsole; // Привязываем метод к делегату
    handler("Система запущена"); // Вызов

2. Встроенные делегаты (Action, Func, Predicate)

В современном C# редко пишут свои делегаты. В 99% случаев используют готовые:

Action — если метод ничего не возвращает (void).

Func — если метод возвращает значение.

Predicate — если метод возвращает bool (часто используется для поиска/фильтрации).

    // Action — для методов void
    Action<string> print = (message) => Console.WriteLine(message);
    print("Hello!");

    // Func — для методов с возвращаемым значением. 
    // Последний тип в списке — это всегда возвращаемый тип.
    Func<int, int, int> multiply = (a, b) => a * b;
    int result = multiply(5, 5); // 25

    // Predicate — аналог Func<T, bool>
    Predicate<int> isPositive = (n) => n > 0;

3. События (Events)

События — это «обертка» над делегатами, которая реализует инкапсуляцию.

Зачем? Чтобы внешний код мог только подписываться (+=) или отписываться (-=), но не мог затереть все подписки или вызвать событие напрямую.

Ключевое слово event.

Стандартный паттерн .NET: EventHandler и EventArgs.

public class TemperatureSensor
{
    // Используем стандартный EventHandler. 
    // event запрещает делать sensor.TemperatureChanged = null извне.
    public event Action<double>? TemperatureChanged;

    public void Measure(double currentTemp)
    {
        // Логика валидации внутри метода
        if (currentTemp > 100) return; 

        // Вызов (?.Invoke проверяет, есть ли подписчики)
        TemperatureChanged?.Invoke(currentTemp);
    }
}

4. Паттерн Наблюдатель (Observer)


        public class Display
        {
            public void ShowTemperature(double temp) => Console.WriteLine($"На экране: {temp}°C");
            }

            // Подписчик 2
            public class Alarm
            {
            public void CheckAlert(double temp)
          {
            if (temp > 40) Console.WriteLine("ТРЕВОГА! Перегрев!");
          }
         }

            // В Main или стартовом классе:
            var sensor = new TemperatureSensor();
            var display = new Display();
            var alarm = new Alarm();

            // Подписываем методы на событие
            sensor.TemperatureChanged += display.ShowTemperature;
            sensor.TemperatureChanged += alarm.CheckAlert;

            // Работа системы
            sensor.Measure(25.5); // Выведет только температуру
            sensor.Measure(45.0); // Выведет температуру И тревогу
 
Это архитектурная цель недели. Представь систему уведомлений:

Издатель (Publisher): Класс StockMarket (Рынок акций).

Подписчики (Subscribers): Классы Trader, EmailBot, Logger. Когда цена меняется, Издатель уведомляет всех Подписчиков.