      1. Фундамент связей: PK, FK и Навигационные свойства
.

      Primary Key (PK) — Первичный ключ
Суть: Главный уникальный идентификатор строки в таблице. Гарантирует, что в таблице нет двух абсолютно одинаковых записей.

На уровне БД: Чаще всего это автоинкрементное число (1, 2, 3...) или уникальная строка (GUID). На одну таблицу может быть только один PK. По нему база ищет записи мгновенно.

На уровне C#: Обычное свойство класса, которое чаще всего называется Id.

      Foreign Key (FK) — Внешний ключ
Суть: Поле, которое связывает одну таблицу с другой. Это «ссылка на паспорт» (PK) родительской записи. Физически всегда хранится на стороне «ребенка» (зависимой сущности).

На уровне БД: В зависимой таблице создается колонка (например, AuthorId). В неё можно записать только то число, которое уже существует в колонке Id таблицы Authors. Иначе БД заблокирует запрос.

На уровне C#: Числовое свойство в зависимом классе.

      Навигационные свойства (Navigation Properties)
Суть: Чистая магия EF Core. В самой БД их не существует (там только ID и циферки). Они созданы для того, чтобы C#-разработчик работал со связями как с обычными объектами в памяти, избегая ручного написания тяжелых SQL-запросов с оператором JOIN.
   
        C#
        public class Author
        {
            public int Id { get; set; } // Primary Key (PK)
            public string Name { get; set; }
        
            // НАВИГАЦИОННОЕ СВОЙСТВО (Коллекция): 
            // Позволяет у автора сразу посмотреть список его книг
            public List<Book> Books { get; set; } = new();
        }

        public class Book
        {
            public int Id { get; set; } // Собственный PK книги
            public string Title { get; set; }
            
            public int AuthorId { get; set; } // Foreign Key (FK). Ссылка на автора!
        
            // НАВИГАЦИОННОЕ СВОЙСТВО (Одиночное): 
            // Позволяет у книги сразу прыгнуть в объект её автора
            public Author Author { get; set; } 
        }
   
Как это меняет код (Использование LINQ):C#// EF Core сам под капотом сделает нужный SQL JOIN:

      string country = currentBook.Author.Country; 
      
      // Вытащить имена всех книг автора без лишних запросов:
      var bookTitles = currentAuthor.Books.Select(b => b.Title);

      2. Nullable-связи и Каскадное удаление
Тип данных внешнего ключа (int или int?) в C# определяет поведение базы данных при удалении родительской записи:
Вариант А: ОБЯЗАТЕЛЬНАЯ СВЯЗЬ (public int StockId)

В БД колонка становится NOT NULL.

При удалении Акции автоматически удаляются все её Комментарии (Каскадное удаление — Cascade Delete).

Вариант Б: МЯГКАЯ СВЯЗЬ (public int? StockId)

В БД колонка разрешает значение NULL.

При удалении Акции её Комментарии выживают, но их поле StockId зануляется (Set NULL).

        C#public class Comment 
        {
            public int Id { get; set; }
            public string Content { get; set; } = string.Empty;
        
            public int? StockId { get; set; } // Знак вопроса включает мягкую связь (Optional)
            public Stock? Stock { get; set; } 
        }
   
      3. Загрузка связанных данных и ловушка циклов
Жадная загрузка (Eager Loading) через .Include()
По умолчанию в EF Core включено ленивое поведение (Lazy by default): если сделать запрос _context.Stocks.ToList(), навигационное свойство Comments будет равно null ради экономии ресурсов.

Чтобы принудительно подтянуть «детей» за один запрос (через SQL-оператор JOIN), используется метод .Include():

      var stocksWithComments = await _context.Stocks.Include(s => s.Comments).ToListAsync();
.

      Технический сбой: Циклы в JSON (Object Cycle)

Если попытаться отправить сущности БД со связями напрямую клиенту (return Ok(stocks)), сериализатор уйдет в бесконечный цикл, гуляя по ссылкам: Акция $\rightarrow$ Комментарий $\rightarrow$ Акция. Приложение упадет с ошибкой JsonException: A possible object cycle was detected.

Решение: Проекция в DTO
Единственный правильный способ избежать зацикливания — разорвать петлю на этапе маппинга, переложив данные в плоскую структуру DTO, где нет обратных навигационных свойств.

        C#// 1. Плоская модель DTO без объектов базы данных внутри
        public class StockDto
        {
            public int Id { get; set; }
            public string Symbol { get; set; }
            public List<string> CommentsContent { get; set; } // Только чистый текст!
        }

        // 2. Правильный запрос в репозитории:
        List<StockDto> stocks = await _context.Stocks
            .Include(s => s.Comments)  // Подтягиваем комменты из БД
            .Select(s => new StockDto  // Проекция: перекладываем данные и РАЗРЫВАЕМ петлю
            {
                Id = s.Id,
                Symbol = s.Symbol,
                CommentsContent = s.Comments.Select(c => c.Content).ToList()
            })
            .ToListAsync();
