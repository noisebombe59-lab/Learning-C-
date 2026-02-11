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


       C#
        using System;
        
        // 1. Класс-издатель (Источник события)
        public class TemperatureSensor
        {
            // Объявляем делегат (сигнатуру метода) и само событие
            public delegate void TemperatureHandler(double temp);
            public event TemperatureHandler TemperatureChanged;

        public void Measure(double temp)
        {
            Console.WriteLine($"\nСенсор замерил температуру: {temp}°C");
        
        // Если на событие кто-то подписан — уведомляем их
        TemperatureChanged?.Invoke(temp);
       }
       }

        // 2. Подписчик 1: Экран
        public class Display
        {
            public void ShowTemperature(double temp) => 
                Console.WriteLine($"[Экран]: Текущее значение {temp}°C");
        }
        
        // 3. Подписчик 2: Сигнализация
        public class Alarm
        {
            public void CheckAlert(double temp)
            {
                if (temp > 40) 
                    Console.WriteLine("[ТРЕВОГА]: Обнаружен перегрев!");
            }
        }
    
        // Точка входа
        class Program
        {
            static void Main()
            {
                var sensor = new TemperatureSensor();
                var display = new Display();
                var alarm = new Alarm();

            // ПОДПИСКА (Связываем издателя с методами подписчиков)
            sensor.TemperatureChanged += display.ShowTemperature;
            sensor.TemperatureChanged += alarm.CheckAlert;
    
            // Эмуляция работы
            sensor.Measure(25.5); // Отработает только Display
            sensor.Measure(45.0); // Отработают Display и Alarm
            }
        }
 
5. Лямбда-выражение
— это анонимный метод (метод без имени), который можно использовать для создания делегатов или деревьев выражений.

Главная цель: Сократить написание кода, когда метод нужен «здесь и сейчас» и не будет использоваться повторно в других местах.

1. Анатомия синтаксиса
Любая лямбда делится на три части: (входные_параметры) => { тело_метода }

Параметры: То, что метод принимает (как аргументы в обычных скобках).

Оператор =>: Читается как «переходит в» или «выполняет».

Тело: Код, который выполняется.

2. Правила сокращения (От сложного к простому)
C# позволяет максимально упрощать запись, если контекст понятен:

Удаление типов: Если компилятор знает типы (из делегата или события), их можно не писать.

    Было: (int x, int y) => { return x + y; }
    
    Стало: (x, y) => { return x + y; }

Удаление скобок (для одного параметра):    

    Было: (x) => { return x * x; }
    
    Стало: x => { return x * x; }

Удаление скобок и return (однострочники): Если код занимает одну строку, {} и return не нужны.

    Было: x => { return x * x; }
    
    Стало: x => x * x
    
3. Замыкание (Closures)
Это уникальная фишка лямбд. Лямбда «видит» и может использовать переменные, которые были объявлены в том же методе, где и сама лямбда.

        C#
        int factor = 10;
        Func<int, int> multiplier = n => n * factor; // factor захвачен извне
Обычный метод так не умеет — ему пришлось бы передавать factor как аргумент.
