1. Архитектура запроса и Контроллеры
Контроллер — это мозг твоего API. Он не должен знать, как работает база данных, он просто принимает «письмо» (запрос) и отправляет «ответ».

[ApiController]: Твой автоматический контролер. Он избавляет тебя от написания if (!ModelState.IsValid) вручную.

[Route]: Твоя карта дорог. Без нее сервер не поймет, какой класс вызвать.

C#
[ApiController]
[Route("api/stock")] // Базовый путь: /api/stock
public class StockController : ControllerBase 
{
    // [HttpGet] без параметров вызовет этот метод при GET /api/stock
    [HttpGet]
    public IActionResult GetAll() 
    {
        return Ok("Список всех акций"); // Статус 200
    }

    // [HttpGet("{id}")] вызовет метод при GET /api/stock/5
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id) 
    {
        return Ok($"Вы запросили акцию с ID: {id}");
    }
}
2. Сроки жизни объектов (Lifetimes) в DI
Это то, как долго живет «инструмент», который ты попросил в конструкторе.

Transient: Как одноразовая салфетка. Нужна — взял, использовал — выбросил.

Scoped: Как поднос в столовой. Он у тебя один, пока ты не доешь (пока не закончится один запрос).

Singleton: Как кулер в офисе. Он один для всех сотрудников и стоит там годами.

        C#
        // Регистрация в Program.cs
        builder.Services.AddTransient<IGenerator, GuidGenerator>(); // Всегда новый ID
        builder.Services.AddScoped<IStockRepository, StockRepository>(); // Один на запрос
        builder.Services.AddSingleton<ICacheService, CacheService>(); // Один на всё время приложения
3. Базы данных и EF Core в Контроллере
Мы не создаем подключение к базе вручную через new. Мы просим DbContext у системы и используем LINQ для общения с таблицами.

_context.Stocks.ToList(): «Достать всех из таблицы Stocks».

_context.Stocks.Find(id): «Найти одного счастливчика по ключу».

        C#
        public class StockController : ControllerBase 
        {
            private readonly ApplicationDBContext _context;
    
            public StockController(ApplicationDBContext context) => _context = context;
        
            [HttpGet]
            public IActionResult GetTopStocks() 
            {
                // LINQ запрос к базе
                var stocks = _context.Stocks.Where(s => s.Price > 100).ToList();
                return Ok(stocks);
            }
        }
4. DTO (Data Transfer Object) и Маппинг
Это «защитный костюм» для твоих данных. Ты никогда не отдаешь саму таблицу из базы наружу.

Маппер: Простой метод, который перекладывает данные из Модели в DTO.

        C#
        // Модель БД (Stock.cs)
        public class Stock { public int Id { get; set; } public string SecretCode { get; set; } }
        
        // DTO для пользователя (StockDto.cs)
        public class StockDto { public int Id { get; set; } }
        
        // Метод маппинга
        public static class StockExtensions {
            public static StockDto ToDto(this Stock stock) => new StockDto { Id = stock.Id };
        }
        
        // Применение в коде:
        var stock = _context.Stocks.Find(1);
        return Ok(stock.ToDto()); // Пользователь не увидит SecretCode
5. IActionResult и Статус-коды
IActionResult — это интерфейс-обертка. Он позволяет методу контроллера возвращать не просто данные, а полноценный HTTP-ответ, включающий тело (JSON) и цифровой код состояния.

200 OK / 201 Created / 204 No Content: Запрос выполнен успешно.

400 Bad Request / 404 Not Found: Ошибка на стороне клиента (неверные данные или ресурс не существует).

500 Internal Server Error: Необработанное исключение в коде сервера.

Пример реализации CRUD-метода:

    C#
    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id) 
    {
        // Поиск сущности в БД по первичному ключу
        var stock = _context.Stocks.Find(id);
        
        // Если объект не найден, возвращаем 404
        if (stock == null) 
        {
            return NotFound(); 
        }
    
        _context.Stocks.Remove(stock);
        _context.SaveChanges();
    
        // 204 No Content: стандарт для успешного удаления (тело ответа пустое)
        return NoContent(); 
    }
6. Жизненный цикл запроса (Middleware)
Middleware — это последовательность обработчиков (делегатов), через которые проходит объект HttpContext. Каждый обработчик может выполнить код до и после следующего компонента в цепочке.

Конвейер: Запрос идет по цепочке методов Use.... Если один из них (например, проверка прав) не вызывает next(), запрос прерывается (Short-circuiting).

Порядок в Program.cs:

    C#
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();
    
    // Middleware для перехвата исключений и возврата 500 ошибки в чистом JSON
    app.UseExceptionHandler("/error"); 
    
    // Middleware для сопоставления URL с конкретным Action-методом контроллера
    app.UseRouting(); 
    
    // Middleware для проверки JWT-токена или прав доступа
    app.UseAuthorization(); 
    
    // Выполнение найденного контроллера
    app.MapControllers(); 
    
    app.Run();
7. SQL в SSMS (Инструментарий)
Когда ты работаешь с базой напрямую, ты используешь скрипты для быстрой проверки.

SQL
-- Массовая вставка для тестов

        INSERT INTO Stocks (Symbol, CompanyName, Purchase)
        VALUES ('AAPL', 'Apple', 150.00), ('MSFT', 'Microsoft', 300.00);
        
        -- Поиск
        SELECT * FROM Stocks WHERE Purchase > 200;
        
        -- Удаление (Будь осторожен!)
        DELETE FROM Stocks WHERE Id = 5;
8. Model Binding (Привязка модели)
Процесс автоматического заполнения параметров метода данными из HTTP-запроса (адресная строка, тело JSON, заголовки).

        C#
        // Данные извлекаются из разных источников автоматически
        [HttpGet("{id}")] // {id} — из Route
        public IActionResult Get([FromRoute] int id, [FromQuery] string name) // name — из ?name=apple
        {
            return Ok($"ID: {id}, Name: {name}");
        }
ModelState
Объект, хранящий информацию о том, соответствуют ли пришедшие данные правилам (атрибутам), установленным в DTO.

    C#
    public class CreateStockDto {
        [Required] // Поле не может быть null
        [MinLength(3)] // Минимум 3 символа
        public string Symbol { get; set; }
    }

[HttpPost]
    
    public IActionResult Create([FromBody] CreateStockDto dto) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState); // Вернет 400 и список ошибок
        }
        return Ok();
    }
Over-posting
Ситуация, когда клиент присылает в JSON поля, которые он не должен менять (например, Id или IsAdmin). DTO предотвращает это, так как содержит только разрешенные поля.

    C#
    // ПЛОХО: Использование модели БД напрямую
    [HttpPost]
    public IActionResult BadCreate([FromBody] Stock model) {
        _context.Stocks.Add(model); // Юзер может прислать { "Id": 999, "Balance": 1000000 }
        _context.SaveChanges();
        return Ok();
    }
Stack Trace
Отчет о цепочке вызовов, который появляется в консоли или логах при ошибке. Помогает найти точное место сбоя.

    C#
    // Пример ошибки в консоли:
    // System.NullReferenceException: Object reference not set to an instance of an object.
    //   at MyApp.Controllers.StockController.Delete(Int32 id) in C:\Project\Controllers\StockController.cs:line 45
    //   ^--- Это и есть Stack Trace (указывает на 45 строку)
HttpContext
Объект, инкапсулирующий всю информацию об отдельном HTTP-запросе и ответе (заголовки, куки, данные пользователя, метод GET/POST).
    
    C#
    [HttpGet]
    public IActionResult GetInfo() {
        var userAgent = Request.Headers["User-Agent"]; // Доступ к данным через HttpContext (Request)
        return Ok(userAgent);
    }
