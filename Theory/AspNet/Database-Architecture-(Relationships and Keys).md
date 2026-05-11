Теория: Реляционная связь строится на паре PK (Primary Key) и FK (Foreign Key). В связи «Один-ко-Многим» (1:N) внешний ключ всегда живет в таблице «Многих».

Required (int): Жесткая связь. Комментарий не может быть «ничейным». Удаление родителя = авто-удаление всех детей (Cascade Delete).

Nullable (int?): Мягкая связь. Если родитель удален, дети остаются, но связь зануляется (Set Null).

C#
public class Stock {
    public int Id { get; set; } // Primary Key (PK)
    public List<Comment> Comments { get; set; } = new(); // Навигация "к детям"
}

public class Comment {
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;

    // Внешний ключ (FK). Знак '?' определяет тип связи (Required vs Nullable)
    public int? StockId { get; set; } 
    public Stock? Stock { get; set; } // Навигация "к родителю"
}