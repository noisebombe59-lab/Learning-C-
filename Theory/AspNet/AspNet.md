1. Архитектура запроса и Контроллеры (Web API)
Контроллер: Специальный класс (наследник ControllerBase), который «слушает» входящие HTTP-запросы.

        [ApiController] // Атрибут-маркер (Супервизор)
        [Route("api/stock")] // Главная дорога
        public class StockController : ControllerBase 
        {
            // Код методов здесь
        }

Маршрутизация (Routing): Процесс сопоставления URL из браузера с методом в коде через атрибуты:

[Route("api/stock")] — задает «главную дорогу» контроллера.


[HttpGet("{id}")] — создает «именную ячейку» в адресе (например, /api/stock/5).

Привязка (Binding): Атрибут [FromRoute] заставляет C# вытащить данные (например, id) прямо из адресной строки и положить их в переменную метода.

        [HttpGet("{id}")] // Создает ячейку в адресе: api/stock/5
        public IActionResult GetById([FromRoute] int id) // Вытаскивает '5' из URL в переменную 'id'
        {
             (url)](url)// ...
        }
Атрибуты-маркеры: Атрибут [ApiController] (Супервизор)

Авто-валидация: Самая важная функция — сам проверяет данные на ошибки до того, как они попадут в твой код.

Problem Details: Формирует стандартные JSON-ответы для ошибок (как на скрине), добавляя traceId для отладки.

Обязательный маршрут: Принуждает разработчика использовать [Route], чтобы API всегда имело четкие адреса.

2. HTTP Ответы и Статусы (Коммуникация)
API не просто отдает данные, он сообщает о результате через статус-коды:

200 OK: «Успех». Данные найдены, метод Ok(data) сработал.

404 Not Found: «Не найдено». Либо адрес неверный, либо твой код сделал проверку if (item == null) и вернул NotFound().

500 Internal Server Error: «Крах сервера». В коде произошло необработанное исключение (Exception). Ищи ошибку в консоли через Stack Trace.

    return Ok(stock);        // 200 OK — Отдаем данные
        return NotFound();       // 404 Not Found — Данных нет
        // 500 генерируется автоматически, если код «упал», например:
        // throw new Exception();

3. Базы данных и Модели (EF Core) — дополнено
DbContext в Контроллере: Мы не создаем его через new, а получаем через DI (конструктор).

LINQ в действии:

_context.Stocks.ToList() — превращает таблицу в список объектов C#.

_context.Stocks.Find(id) — быстрый поиск в базе по первичному ключу (ID).

    // 1. Получаем контекст через конструктор (DI)
    private readonly ApplicationDBContext _context;
    public StockController(ApplicationDBContext context)
    {
        _context = context;
    }
    
    // 2. Используем LINQ
    var stocks = _context.Stocks.ToList(); // Достать всё
    var stock = _context.Stocks.Find(id);  // Найти одного по ID

4. Внедрение зависимостей (DI) — без изменений
Суть: Проси инструменты в конструкторе.

Регистрация: builder.Services.AddDbContext... в Program.cs.
    
    builder.Services.AddDbContext<ApplicationDBContext>(options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    public class StockController(ApplicationDBContext context) // Краткая запись в новых версиях C#

5. Сроки жизни (Lifetimes) — без изменений
Transient, Scoped (DbContext), Singleton.

Что мы добавили в общую картину:
Теперь твой путь запроса выглядит еще детальнее:

Пользователь (URL с ID) → Маршрутизация (Attribute Routing) → Контроллер (DI берет DbContext) → Метод (LINQ ищет в БД) → Логика (Проверка на null / 404) → Ответ (JSON + Статус 200/404/500).
    
    builder.Services.AddTransient<IMyService, MyService>(); // Transient
    builder.Services.AddScoped<IMyService, MyService>();    // Scoped (как DbContext)
    builder.Services.AddSingleton<IMyService, MyService>(); // Singleton
путь запроса (Visualized):
Пользователь (GET api/stock/1)
Route("api/stock")] + [HttpGet("{id}")]
public IActionResult GetById([FromRoute] int id)
_context.Stocks.Find(1)
if (stock == null) return NotFound();
JSON { "id": 1, ... } + Status 200 OK
