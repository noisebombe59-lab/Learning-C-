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
Это способ сказать клиенту: «Всё прошло хорошо» или «У нас проблемы».

2xx: Всё отлично.

4xx: Ошибка пользователя (не нашел, не ввел данные).

5xx: Твоя ошибка (код упал).

        C#
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var stock = _context.Stocks.Find(id);
            if (stock == null) return NotFound(); // 404
        
            _context.Stocks.Remove(stock);
            _context.SaveChanges();
        
            return NoContent(); // 204 (Успех, но возвращать нечего)
        }
6. Жизненный цикл запроса (Middleware)
Это фильтры, через которые проходит запрос, прежде чем попасть в твой контроллер.

        C#
        // Program.cs - порядок ВАЖЕН
        var app = builder.Build();
        
        app.UseSwagger(); // Показывает документацию
        app.UseHttpsRedirection(); // Переводит на безопасное соединение
        app.UseAuthorization(); // Проверяет права
        app.MapControllers(); // В самом конце отправляет к контроллеру
        
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
8. Разбор критических терминов
Middleware: Слой кода между сервером и твоим контроллером. Как охрана на входе в клуб.

Over-posting: Когда юзер шлет в JSON поле IsAdmin: true. Если нет DTO, база может это сохранить и дать ему права админа.

ModelState: Встроенный охранник. Если ты сказал, что Price — это число, а пришла строка «дорого», ModelState запомнит это как ошибку.

Binding: «Склеивание». ASP.NET берет JSON из тела запроса и превращает его в объект C#.

Stack Trace: Карта того, как код умирал. Показывает путь от начала программы до места, где вылетела ошибка.
