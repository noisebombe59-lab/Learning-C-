      1. Фундамент связей: PK, FK и Навигационные свойства
Primary Key (PK) — Первичный ключ

Суть: Главный уникальный идентификатор строки в таблице. Гарантирует, что в таблице нет двух одинаковых записей.

БД: Автоинкрементное число (1, 2, 3...) или GUID. По нему база ищет записи мгновенно.

Код: Обычное свойство класса, которое чаще всего называется Id.

Foreign Key (FK) — Внешний ключ

Суть: Связующее поле. Это «ссылка на паспорт» (PK) родительской записи. Всегда хранится на стороне «ребенка» (зависимой сущности).

БД: Колонка в зависимой таблице (например, AuthorId). База заблокирует запрос, если попытаться записать туда ID несуществующего автора.

Код: Числовое свойство в зависимом классе (public int AuthorId { get; set; }).

Навигационные свойства (Navigation Properties)

Суть: Магия EF Core. В самой БД их не существует. Нужны, чтобы работать со связями как с объектами в памяти, избегая ручного написания SQL JOIN.

БД: Отсутствуют (там только ID и циферки).

Код: Объект или коллекция объектов внутри сущности.

Пример структуры (C#):

      public class Author
      {
          public int Id { get; set; } // Primary Key (PK)
          public string Name { get; set; }
          
          // НАВИГАЦИОННОЕ СВОЙСТВО (Коллекция)
          public List<Book> Books { get; set; } = new();
      }
      
      public class Book
      {
          public int Id { get; set; } // Собственный PK книги
          public string Title { get; set; }
          
          public int AuthorId { get; set; } // Foreign Key (FK)
          
          // НАВИГАЦИОННОЕ СВОЙСТВО (Одиночное)
          public Author Author { get; set; } 
      }

Использование в LINQ:

// EF Core сам под капотом сделает нужный SQL JOIN
string country = currentBook.Author.Country; 
  
// Вытащить имена всех книг автора
var bookTitles = currentAuthor.Books.Select(b => b.Title);

      2. Nullable-связи и Каскадное удаление

Суть: Тип данных внешнего клюка (int или int?) определяет поведение базы данных при удалении родительской записи.

Вариант А: ОБЯЗАТЕЛЬНАЯ СВЯЗЬ (public int StockId)

БД: Колонка становится NOT NULL. При удалении Акции автоматически удаляются все её Комментарии (Cascade Delete).

Вариант Б: МЯГКАЯ СВЯЗЬ (public int? StockId)

БД: Колонка разрешает значение NULL. При удалении Акции её Комментарии выживают, но их поле StockId зануляется (Set NULL).

Пример структуры (C#):

      public class Comment 
      {
          public int Id { get; set; }
          public string Content { get; set; } = string.Empty;
          
          public int? StockId { get; set; } // Знак вопроса включает мягкую связь (Optional)
          public Stock? Stock { get; set; } 
      }

      3. Загрузка связанных данных и ловушка циклов
Жадная загрузка (Eager Loading) через .Include()

Суть: По умолчанию в EF Core включено ленивое поведение. Если сделать обычный запрос, навигационные свойства будут равны null ради экономии ресурсов.

Код: Чтобы принудительно подтянуть зависимые данные за один SQL-запрос, используется метод .Include():

      var stocksWithComments = await _context.Stocks.Include(s => s.Comments).ToListAsync();

Технический сбой: Циклы в JSON (Object Cycle)

Суть: Если отправить сущности со связями напрямую клиенту (return Ok(stocks)), сериализатор уйдет в бесконечный цикл, гуляя по ссылкам: Акция $\rightarrow$ Комментарий $\rightarrow$ Акция. Приложение упадет с ошибкой JsonException.

Решение: Проекция данных в плоскую структуру DTO на этапе маппинга, что полностью разрывает петлю обратных ссылок.Пример решения (C#):

      // 1. Плоская модель DTO без объектов базы данных внутри
      public class StockDto
      {
          public int Id { get; set; }
          public string Symbol { get; set; }
          public List<string> CommentsContent { get; set; } // Только чистый текст!
      }
      
      // 2. Запрос в репозитории с разрывом петли
      List<StockDto> stocks = await _context.Stocks
          .Include(s => s.Comments)
          .Select(s => new StockDto
          {
              Id = s.Id,
              Symbol = s.Symbol,
              CommentsContent = s.Comments.Select(c => c.Content).ToList()
          })
          .ToListAsync();

 Цепочки связей и ограничение FindAsync: Для загрузки глубоких связей (Акция $\rightarrow$ Комментарии $\rightarrow$ Автор) используется связка .Include().ThenInclude(). Метод .FindAsync() не поддерживает .Include(), поэтому для подгрузки связей его всегда заменяют на .FirstOrDefaultAsync().

      4. Связи Many-to-Many (Многие-ко-многим)
Join-таблица (Таблица-прослойка)

Суть: One-to-Many не может связать сущности «Многие-ко-многим», так как он жестко привязывает запись только к одному родителю. Для бесконечных комбинаций связей создается промежуточная таблица, которая хранит только пары внешних ключей.

БД: Создается физическая таблица (например, Portfolios), где базовыми колонками являются AppUserId и StockId.

Код: Создается отдельный класс доменной модели, связывающий две сущности.

      public class Portfolio
      {
          public string AppUserId { get; set; } // FK на юзера
          public AppUser AppUser { get; set; }  // Навигационное свойство
          
          public int StockId { get; set; }      // FK на акцию
          public Stock Stock { get; set; }      // Навигационное свойство
      }

Навигационные свойства на краях связи

Суть: Чтобы сущности взаимодействовали на уровне LINQ, они должны ссылаться не друг на друга напрямую, а на списки из промежуточной таблицы Portfolios.

БД: Изменений нет.

Код: В обе доменные модели добавляются коллекции промежуточной сущности.

      public class AppUser : IdentityUser
      {
          public List<Portfolio> Portfolios { get; set; } = new();
      }
      
      public class Stock
      {
          public int Id { get; set; }
          public List<Portfolio> Portfolios { get; set; } = new();
      }

      5. Конфигурация Many-to-Many во Fluent API (OnModelCreating)
Составной Первичный Ключ (Composite Key)

Суть: Промежуточная таблица не имеет одиночного Id. Первичным ключом является комбинация двух Foreign Key. Это исключает дубликаты (нельзя добавить одну и ту же акцию в один портфель дважды).

Код (ApplicationDBContext):

      builder.Entity<Portfolio>().HasKey(p => new { p.AppUserId, p.StockId });

Симметричная привязка связей

Суть: Жесткое указание правил связи для каждой из двух родительских таблиц, чтобы EF Core правильно построил схему ограничений в БД.

Код (ApplicationDBContext):

      // 1. Привязка портфеля к Пользователю
      builder.Entity<Portfolio>()
          .HasOne(u => u.AppUser)
          .WithMany(u => u.Portfolios)
          .HasForeignKey(p => p.AppUserId);
      
      // 2. Привязка портфеля к Акции
      builder.Entity<Portfolio>()
          .HasOne(u => u.Stock)
          .WithMany(u => u.Portfolios)
          .HasForeignKey(p => p.StockId);

      6. Явное именование через Атрибут [Table]

Суть: Защита схемы БД от автоматических нечитаемых имен, которые EF Core генерирует для промежуточных таблиц по умолчанию.

БД: Таблица получает строго заданное имя в SQL Server.

Код: Над классом сущности явно прописывается дата-атрибут.

      [Table("Portfolios")]
      public class Portfolio 
      { 
          // ... поля класса
      }

Архитектурное правило: Всегда жестко задавай имена таблиц через [Table("имя")] на бэкенде, чтобы избежать каши в миграциях.

Техника безопасности: Очистка базы при изменении связей

Суть: При глобальной перестройке связей на этапе разработки старые миграции начинают конфликтовать со схемой БД. Проще всего «сбросить холст» и пересоздать базу с нуля.

Порядок действий (Только локально!):

Удалить папку Migrations в проекте.

В SSMS удалить базу данных (поставив чекбокс "Close existing connections").

Создать чистую миграцию: net ef migrations add InitialCreate

Накатить на пустую БД: net ef database update
