Модификаторы доступа
public — доступ откуда угодно.
private — только внутри того же класса (это будет ваш основной модификатор для полей!).
protected — внутри класса и в наследниках.
internal — внутри той же сборки (проекта).
protected internal и private protected — комбинации (пока просто знать, что существуют).
Зачем это нужно: инкапсуляция — скрываем внутреннюю реализацию, чтобы внешний код не ломал объект напрямую.

    public class BankAccount
    {
        // private: никто снаружи не может изменить баланс напрямую
        private decimal _balance; 
    
        // public: доступен всем для чтения
        public string OwnerName; 
    
        // protected: наследники (например, VIPAccount) смогут работать с этим полем
        protected string AccountType; 
    
        // internal: доступно только внутри этого проекта (сборки)
        internal string BranchCode;
    
        public void Deposit(decimal amount)
        {
            if (amount > 0) _balance += amount;
        }
    }

Статические члены
static поле/свойство/метод принадлежит классу, а не конкретному объекту.
Создаётся один раз на всю программу.
Доступ через имя класса: ClassName.StaticMethod().
Статический конструктор — выполняется один раз перед первым использованием класса.
Когда использовать: для утилит, констант, кэшей, логгеров, фабрик — всего, что не зависит от состояния конкретного экземпляра.
Когда НЕ использовать: если нужна разная логика/данные для разных объектов.

    public class Calculator
    {
        // Статическое поле — общее для всех
        public static double Pi = 3.14159;
        public static int UsageCount = 0;
    
        // Статический конструктор — вызывается один раз
        static Calculator()
        {
            Console.WriteLine("Калькулятор готов к работе");
        }
    
        // Статический метод — вызывается через имя класса
        public static double Square(double x)
        {
            UsageCount++;
            return x * x;
        }
    }
    
    // Использование:
    var result = Calculator.Square(5); // Объект создавать не нужно
    Console.WriteLine(Calculator.Pi);

Record-типы (основы)
record class (C# 9+) — класс, ориентированный на хранение данных (immutable по умолчанию).
Автоматически генерирует:
Equals, GetHashCode (по значению всех свойств).
ToString().
Деконструкор.
with-выражение для создания копии с изменёнными свойствами.

    // Краткая запись (Positional Record)
    public record User(string FirstName, string LastName, int Age);
    
    // Использование:
    var user1 = new User("Иван", "Иванов", 25);
    var user2 = new User("Иван", "Иванов", 25);
    
    // 1. Сравнение по значению (выдаст True, у обычных классов было бы False)
    Console.WriteLine(user1 == user2); 
    
    // 2. Встроенный ToString (выведет: User { FirstName = Иван, LastName = Иванов, Age = 25 })
    Console.WriteLine(user1); 
    
    // 3. Создание копии с изменением одного поля (with-выражение)
    var user3 = user1 with { Age = 26 }; 
    
    // 4. Деконструкция
    var (name, surname, age) = user1;

Основное отличие от обычного класса: сравнение по значению, а не по ссылке.
Можно делать mutable, но лучше immutable.
