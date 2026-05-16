1. DTO (Data Transfer Object)
Это «посылка». Мы не отправляем клиенту всю модель из базы (с паролями и лишними связями), а создаем упрощенную копию. Это защищает от Over-posting (когда хакер пытается обновить поля, которые не должен трогать).

        C#
        // Модель в БД (Тяжелая)
        public class Stock {
            public int Id { get; set; }
            public string Symbol { get; set; }
            public decimal LastDiv { get; set; } // Лишние данные для списка
        }
        
        // DTO для клиента (Легкая)
        public class StockDto {
            public string Symbol { get; set; }
        }

        // Маппер (Метод расширения)
        public static StockDto ToStockDto(this Stock stockModel) => 
            new StockDto { Symbol = stockModel.Symbol };
2. Инъекция зависимостей (DI) и Сроки жизни
Мы не создаем объекты через new, а просим их в конструкторе. Это делает код гибким (как LEGO).

Transient: Новый объект на каждый «чих».

Scoped: Один объект на один HTTP-запрос (идеально для БД).

Singleton: Один на всё время работы сервера.

        C#
        public interface ITransientService { int GetNumber(); }
        public class TransientService : ITransientService 
        {
            private static int _globalCounter = 0;
            private readonly int _number;
        
            public TransientService()
            {
                _globalCounter++; // Увеличиваем общий счетчик
                _number = _globalCounter; // Запоминаем номер этого конкретного объекта
            }
            public int GetNumber() => _number;
        }

// Точно такие же классы делаем для Scoped и Singleton...
// (Они отличаются только названиями, чтобы DI-контейнер их различал)
Шаг 2: Тестируем в Контроллере
Мы точно так же просим в конструкторе по две штуки каждого сервиса:

        C#
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                // Просим номера у двух Transient сервисов
                Transient1 = _transient1.GetNumber(),
                Transient2 = _transient2.GetNumber(),
        
                // Просим у двух Scoped
                Scoped1 = _scoped1.GetNumber(),
                Scoped2 = _scoped2.GetNumber(),
        
                // Просим у двух Singleton
                Singleton1 = _singleton1.GetNumber(),
                Singleton2 = _singleton2.GetNumber()
            });
        }
А теперь смотрим на цифры в ответе:
Вызываем эндпоинт в САМЫЙ ПЕРВЫЙ РАЗ (Запрос №1):
Transient1 = 1, Transient2 = 2.
(Почему? Родился первый объект, счетчик стал 1. Тут же для второго параметра родился второй объект — счетчик стал 2).

Scoped1 = 3, Scoped2 = 3.
(Почему? Для этого HTTP-запроса создался ОДИН объект. И первому, и второму параметру выдали его. Счетчик стал 3).

Singleton1 = 4, Singleton2 = 4.
(Почему? Создался один объект на всё время работы сервера. Счетчик стал 4).

Нажимаем обновить страницу (Запрос №2):
Transient1 = 5, Transient2 = 6.
(Прошлые умерли, родились два абсолютно новых).

Scoped1 = 7, Scoped2 = 7.
(Для нового HTTP-запроса родился один новый объект с номером 7).

Singleton1 = 4, Singleton2 = 4.
(А вот он НЕ ПЕРЕСОЗДАЛСЯ. Он остался жив с прошлого запроса, его номер по-прежнему 4).

3. Middleware (Промежуточное ПО): Стоит самым первым. Проверяет запрос «в целом» (Битый ли JSON? Тот ли протокол? Огромный ли размер файла?). Он не знает деталей твоего C#-кода.

[ApiController] и ModelState (Уровень MVC): Запускаются следом. Фреймворк берет JSON, наполняет твой DTO и проверяет все атрибуты ([Required], [Range]), записывая результаты в словарь ModelState.
Магия «Автопилота»:
Раньше разработчики вручную писали проверку в каждом методе:

        C#
        // Тедди писал это для наглядности, но в реальном коде это НЕ НУЖНО:
        if (!ModelState.IsValid) return BadRequest(ModelState);
Благодаря атрибуту [ApiController] над классом контроллера, этот код работает на автопилоте. Он автоматически проверяет ModelState.IsValid для всех методов. Если в DTO есть ошибка, фреймворк сам перехватит запрос до запуска твоего кода и вернет клиенту 400 Bad Request с детальным описанием ошибок.
