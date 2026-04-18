1. Контроллеры и Маршрутизация
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

Transient: Как одноразовая салфетка. Нужна — взял, использовал — выбросил. (Всегда новый экземпляр).

Scoped: Как поднос в столовой. Он у тебя один, пока ты не доешь (пока не закончится один HTTP-запрос). Стандарт для DbContext.

Singleton: Как кулер в офисе. Он один для всех сотрудников и стоит там годами. (Один на всё время работы приложения).

    C#
    // Регистрация в Program.cs

    builder.Services.AddTransient<IGenerator, GuidGenerator>();
    builder.Services.AddScoped<IStockRepository, StockRepository>();
    builder.Services.AddSingleton<ICacheService, CacheService>();
3. Базы данных и EF Core в Контроллере
Мы не создаем подключение к базе вручную через new. Мы просим DbContext у системы (через конструктор) и используем LINQ для общения с таблицами.

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
        var stocks = _context.Stocks.Where(s => s.Price > 100).ToList();
        return Ok(stocks);
    }
    }
Блок 2: Данные и Безопасность
4. DTO (Data Transfer Object) и Маппинг
Это «защитный костюм» для твоих данных. Ты никогда не отдаешь саму таблицу из базы наружу (чтобы не светить пароли или системные поля).

Маппер: Простой метод, который перекладывает данные из Модели в DTO.

Over-posting: Ситуация, когда клиент присылает лишние поля (например, IsAdmin). DTO предотвращает это, так как содержит только разрешенные поля.

    C#
    // Модель БД (Stock.cs)
    public class Stock { public int Id { get; set; } public string SecretCode { get; set; } }
    
    // DTO для пользователя (StockDto.cs)
    public class StockDto { public int Id { get; set; } }
    
    // Метод маппинга
    public static class StockExtensions {
        public static StockDto ToDto(this Stock stock) => new StockDto { Id = stock.Id };
    }

    // Применение:
    var stock = _context.Stocks.Find(1);
return Ok(stock.ToDto()); // Скрыли SecretCode
5. IActionResult и Статус-коды
Это способ сказать клиенту: «Всё прошло хорошо» или «У нас проблемы».

    2xx (Success): 200 OK, 201 Created (успех в POST), 204 No Content (успех в Delete).
    
    4xx (Client Error): 400 Bad Request (кривые данные), 404 Not Found (не нашел).
    
    5xx (Server Error): 500 Internal Server Error (твой код упал).

Блок 3: Продвинутые термины и Middleware
6. Middleware (Конвейер)
Последовательность обработчиков, через которые проходит запрос.

Конвейер: Запрос идет сверху вниз по Program.cs. Если авторизация не прошла, запрос прерывается (Short-circuiting).

    C#
    app.UseExceptionHandler("/error"); // 1. Ловим ошибки
    app.UseRouting();                // 2. Ищем маршрут
    app.UseAuthorization();          // 3. Проверяем права
    app.MapControllers();           // 4. Запускаем код контроллера
7. Глоссарий (Коротко)
Model Binding: Автоматическое заполнение параметров (например, int id) из URL или JSON.

ModelState: Словарь ошибок валидации. (Если юзер прислал текст в поле для цифр — ошибка будет здесь).

Stack Trace: Отчет о цепочке вызовов при ошибке. Указывает конкретный файл и строку, где всё сломалось.

Блок 4: Практика POST (Создание данных) — Видео №6
1. Схема работы (Data Flow)
JSON (Client) → Request DTO → Entity (Model) → Database → Response DTO (Client).

2. Реализация CreateStockRequestDto
Создаем DTO без ID, так как ID генерирует база данных.

        C#
        public class CreateStockRequestDto
        {
            public string Symbol { get; set; } = string.Empty;
            public string CompanyName { get; set; } = string.Empty;
            public decimal Purchase { get; set; }
            public decimal LastDiv { get; set; }
            public string Industry { get; set; } = string.Empty;
            public long MarketCap { get; set; }
        }
3. Маппинг «наоборот» (DTO -> Модель)
В StockMappers.cs добавляем метод превращения DTO в Модель для сохранения в базу.

        C#
        public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }
4. Метод Create в Контроллере
Главное: [FromBody] и CreatedAtAction.

        C#
        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
        {
            // 1. Превращаем DTO в Модель
            var stockModel = stockDto.ToStockFromCreateDto();
        
            // 2. Добавляем в контекст (начало отслеживания)
            _context.Stocks.Add(stockModel);
        
            // 3. Сохраняем (SQL INSERT). После этого у stockModel появится реальный Id
            _context.SaveChanges();
        
            // 4. Возвращаем 201 Created + ссылку на новый объект + сам объект
            return CreatedAtAction(
                nameof(GetById), 
                new { id = stockModel.Id }, 
                stockModel.ToStockDto()
            );
        }
5. Разбор CreatedAtAction
Эта строчка делает магию:

nameof(GetById): Ссылается на твой метод получения.

new { id = stockModel.Id }: Подставляет ID созданной акции в маршрут.

stockModel.ToStockDto(): Показывает пользователю результат.

Результат: В заголовках ответа (Headers) появится ссылка Location на новую акцию.
