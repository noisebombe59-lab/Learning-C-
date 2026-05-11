Теория: Когда объекты ссылаются друг на друга (Stock -> Comment -> Stock), JSON-сериализатор зацикливается. Чтобы этого избежать, данные «перекладываются» в DTO — плоские объекты без обратных ссылок. Это разрывает петлю.

C#
// Маппинг в контроллере через .Select()
[HttpGet]
public async Task<IActionResult> GetAll() {
    var stocks = await _context.Stocks.Include(s => s.Comments).ToListAsync();

    // Превращаем тяжелую модель БД в легкий DTO
    var stockDto = stocks.Select(s => new StockDto {
        Id = s.Id,
        Symbol = s.Symbol,
        // Мапим вложенную коллекцию в CommentDto (у которого нет свойства Stock)
        Comments = s.Comments.Select(c => new CommentDto {
            Id = c.Id,
            Content = c.Content
        }).ToList()
    });

    return Ok(stockDto); // Теперь JSON чист и без циклов
}