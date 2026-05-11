1. PK, FK и Навигационные свойства
Primary Key (PK): Уникальный паспорт записи.

Foreign Key (FK): Ссылка на «паспорт» родителя. В БД «дети» всегда ссылаются на «родителей».

Навигационное свойство: Поле в C#, которое позволяет писать comment.Stock.Symbol вместо сложных запросов.

2. Nullable связи и Каскадное удаление
Знак вопроса ? в типе данных меняет логику удаления:

int StockId (Required) → Акция удалена = Комментарии удалены автоматически (Каскад).

int? StockId (Optional) → Акция удалена = Комментарии остались, но связь стерта (NULL).

    public class Stock 
    {
        public int Id { get; set; } // Primary Key
        public string Symbol { get; set; } = string.Empty;
    
        // Навигационное свойство "к детям" (Коллекция)
        public List<Comment> Comments { get; set; } = new(); 
    }
    
    public class Comment 
    {
        public int Id { get; set; } // Primary Key
        public string Content { get; set; } = string.Empty;

    // --- ВАРИАНТ А: ОБЯЗАТЕЛЬНАЯ СВЯЗЬ (Required) ---
    // public int StockId { get; set; } 
    // Результат в БД: NOT NULL. 
    // Удаление акции => Удаление всех комментариев (Cascade Delete).

    // --- ВАРИАНТ Б: МЯГКАЯ СВЯЗЬ (Optional/Nullable) ---
    public int? StockId { get; set; } 
    // Результат в БД: NULL allowed.
    // Удаление акции => StockId у комментариев станет NULL (они выживут).

    // Навигационное свойство "к родителю" (Объект)
    // Позволяет писать: var name = comment.Stock.Symbol;
    public Stock? Stock { get; set; } 
    }

3. Жадная загрузка (Include) и Циклы в JSON
EF Core по умолчанию «ленивый» и не подгружает связанные данные. Метод .Include() заставляет его сделать JOIN в SQL.

Осторожно: Если модель ссылается на комментарий, а комментарий обратно на модель, возникнет Object Cycle, и JSON «сломается». Решение: Всегда используй DTO!

    C#
    // Правильное получение данных со связями
    var stocks = await _context.Stocks
        .Include(s => s.Comments) // Подгружаем "детей" одним JOIN-ом
        .Select(s => s.ToStockDto()) // Превращаем в DTO, разрывая циклы
        .ToListAsync();
