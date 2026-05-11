Теория: Асинхронность нужна для масштабируемости. Пока база данных выполняет запрос (это долго), поток сервера не "зависает" в ожидании, а освобождается для обслуживания других пользователей.

Task: Ожидаемый результат.

await: Точка выхода из метода для потока. Поток возвращается только когда данные от базы готовы.

C#
[HttpPut("{id}")]
public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto dto) {
    // await освобождает поток на время поиска в БД
    var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id); 
    
    if (stock == null) return NotFound();

    stock.Symbol = dto.Symbol; // Изменение в памяти (мгновенно, await не нужен)

    // await освобождает поток на время физической записи на диск
    await _context.SaveChangesAsync(); 

    return Ok(stock.ToStockDto());
}