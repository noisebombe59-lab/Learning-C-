─────────────────────────────────────────────────────────────────────
Что такое Value Types и Reference Types

Value Types (типы-значения): хранят само значение (обычно в стеке).
• Полная копия при присваивании
• Не могут быть null (если не Nullable<T>)
• Быстрее, нет нагрузки на GC

Reference Types (ссылочные типы): хранят ссылку на объект в куче.
• Копируется только ссылка
• Могут быть null

    Пример кода
    int a = 42;          // value type
    int b = a;
    b = 100;
    Console.WriteLine(a); // 42 — копия независимая

    Person p1 = new Person { Name = "Alex" }; // reference type
    Person p2 = p1;
    p2.Name = "Bob";
    Console.WriteLine(p1.Name); // Bob — одна и та же объект
──────────────────────────────────────────────────────────────────────
Value Types — примеры

• Примитивы: int, double, bool, char, decimal, DateTime и т.д.
• struct, enum

    Пример кода
    struct Point
    {
        public int X, Y;
        public Point(int x, int y) => (X, Y) = (x, y);
    }
    
    Point p1 = new Point(10, 20);
    Point p2 = p1;
    p2.X = 99;
    Console.WriteLine(p1.X); // 10 — копия независимая
──────────────────────────────────────────────────────────────────────
Reference Types — примеры

• class, interface, delegate
• string, object, array

    Пример кода
    class Person
    {
        public string Name;
    }
    
    var arr1 = new[] { 1, 2, 3 }; // массив — reference type
    var arr2 = arr1;
    arr2[0] = 99;
    Console.WriteLine(arr1[0]); // 99 — одна ссылка
──────────────────────────────────────────────────────────────────────
struct vs class — когда что использовать

struct — используй для:
• Маленьких неизменяемых данных (≤ 16–24 байт)
• Point, Guid, DateTime, маленькие DTO

class — используй для:
• Сущностей, сервисов, всего остального
• Когда нужно наследование или null

    Пример кода
    public readonly struct Money
    {
        public decimal Amount { get; }
        public string Currency { get; }
        public Money(decimal amount, string currency) => (Amount, Currency) = (amount, currency);
    }
──────────────────────────────────────────────────────────────────────
Nullability (C# 8+) — обязательно включай в проекте!

    Nullable value types
    int? nullableInt = null;   // можно null
    int regularInt = 5;        // нельзя null (компилятор предупредит при присваивании null)
    
    Nullable reference types
    string? maybeNull = null;     // явно допускает null
    string notNull = "text";      // компилятор предупредит, если присвоить null
──────────────────────────────────────────────────────────────────────
Полезные операторы для null

    user?.Profile?.Orders?.Count           // ?. — безопасный доступ (null-conditional)
    
    items?[0]?.Name                        // ?[] — безопасный индекс
    
    var count = list?.Count ?? 0;          // ?? — значение по умолчанию если null
    
    var config = settings ??= new Config(); // ??= — присвоить, если null
──────────────────────────────────────────────────────────────────────
Важные правила

• Value types копируются полностью — изменения в копии не влияют на оригинал.
• Reference types — изменения через любую ссылку влияют на общий объект.
• string — reference type, но ведёт себя как value (immutable).
• Включай <Nullable>enable</Nullable> в .csproj — компилятор поможет избежать NullReferenceException.
• readonly struct — лучший выбор для маленьких иммутабельных данных.
──────────────────────────────────────────────────────────────────────
