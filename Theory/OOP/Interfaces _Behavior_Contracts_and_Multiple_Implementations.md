1. Комбинация: Явная реализация + Полиморфизм
Это способ сделать класс «скромным». Класс может иметь сотни методов, но через интерфейс мы видим только те, что нужны для конкретной роли.

Теория: Если метод реализован явно (void IInterface.Method), он не принадлежит объекту класса напрямую. Он принадлежит только «роли» этого объекта.

Пример:

    C#
    public interface ICleaner { void Clean(); }
    public interface IManager { void Clean(); } // Одинаковые имена!
    
    public class UniversalRobot : ICleaner, IManager
    {
        // Явная реализация решает конфликт имен и разделяет логику
        void ICleaner.Clean() => Console.WriteLine("Робот чистит пол (режим уборки)");
        void IManager.Clean() => Console.WriteLine("Робот чистит кэш данных (режим админа)");
    }
    
    // Использование:
    UniversalRobot bot = new();
    // bot.Clean(); // Ошибка! Робот "не знает", какую чистку делать.
    
    ((ICleaner)bot).Clean(); // Вызвали роль уборщика
    ((IManager)bot).Clean(); // Вызвали роль админа
    
2. Комбинация: IEnumerable + Фильтрация (Защита инкапсуляции)
Это архитектурный стандарт. Ты никогда не отдаешь свой «внутренний склад» (List) наружу в сыром виде.

Теория: Используя IEnumerable<T>, ты создаешь односторонний шлюз. Данные выходят наружу для чтения (и для LINQ!), но попытка изменить их пресекается на уровне компиляции.

Пример:

    C#
    public class Vault
    {
        private List<string> _secrets = new List<string> { "Код 1", "Код 2" };
    
        // Мы отдаем интерфейс, а не сам список
        public IEnumerable<string> GetSecrets() => _secrets; 
    }
    
    // В другом месте программы:
    var vault = new Vault();
    var data = vault.GetSecrets(); 
    
    // data.Add("Взлом"); // Ошибка! У IEnumerable нет метода Add.
    // Зато LINQ работает идеально:
    var fastCheck = data.Any(s => s.Contains("1")); 
    
3. Комбинация: DI + Интерфейсы (Гибкость системы)
Это то, что позволяет программе не «рассыпаться» при изменениях.

Теория: Метод должен просить минимально необходимый навык, а не конкретного исполнителя. Если тебе нужно просто «сохранить текст», не проси Database, проси IStorage.

Пример:

    C#
    public interface ILogger { void Log(string msg); }
    
    public class FileLogger : ILogger { public void Log(string msg) => /* пишем в файл */ ; }
    public class CloudLogger : ILogger { public void Log(string msg) => /* шлем в облако */ ; }
    
    public class OrderService
    {
        // Мы не знаем, КУДА пишется лог. Нам прислали "что-то", что умеет Log()
        public void PlaceOrder(ILogger logger) 
        {
            // ...логика заказа...
            logger.Log("Заказ создан"); 
        }
    }
    
4. Методы по умолчанию (Default Interface Methods)
Это способ добавить новую кнопку на «пульт», не заставляя всех владельцев старых телевизоров бежать в сервис.

Теория: Раньше, если ты добавлял метод в интерфейс, тебе приходилось переписывать все классы, которые его используют. Теперь ты можешь написать реализацию прямо в интерфейсе.

Пример:

    C#
    public interface INotifier
    {
        void Send(string message);
        
        // Новый метод с готовым кодом. Старые классы не сломаются!
        void SendUrgent(string message) => Send("СРОЧНО: " + message);
    }
    
    public class EmailNotifier : INotifier
    {
        public void Send(string message) => Console.WriteLine($"Email: {message}");
        // SendUrgent использовать можно, но реализовывать не обязательно.
    }
    
Итоговая шпаргалка архитектора:
Нужен доступ только для чтения? Используй IEnumerable<T>.

Хочешь скрыть метод от "лишних глаз"? Используй Явную реализацию.

Хочешь, чтобы код не зависел от деталей? Используй DI (интерфейс в параметрах).

Нужно добавить общую логику для всех? Используй Default Methods.
