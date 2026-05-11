8. Async / Await
Сделано, чтобы сервер не «зависал», пока база данных (медленная «черепаха») ищет данные.

Task: Обещание результата.

await: Кнопка паузы для метода, но «трамплин» для потока (он уходит обслуживать других).

IActionResult — это стандартный способ метода контроллера сказать: «Вот что случилось с твоим запросом».

✅ Успех (2xx)
Ok(данные) — 200 OK. «Всё в порядке, вот то, что ты просил». (Самый частый ответ для GET).

CreatedAtAction(...) — 201 Created. «Я создал объект, найти его можно вот по этому адресу». (Для POST).

NoContent() — 204 No Content. «Я всё сделал (например, удалил), но данных в ответ не пришлю». (Для DELETE/PUT).

❌ Ошибки клиента (4xx)
BadRequest() — 400 Bad Request. «Ты прислал некорректные данные (ошибка валидации)».

Unauthorized() — 401 Unauthorized. «Я тебя не знаю, сначала залогинься».

Forbid() — 403 Forbidden. «Я знаю кто ты, но у тебя нет прав на это действие».

NotFound() — 404 Not Found. «Я искал в базе, но по этому ID ничего нет».

💥 Ошибки сервера (5xx)
Problem() — 500 Internal Server Error. «Упс, у меня в коде что-то упало (ошибка в логике или БД)».

[HttpPost]
public async Task<IActionResult> Create([FromBody] CreateStockDto dto) 
{
    var model = dto.ToModel();
    await _context.Stocks.AddAsync(model);
    await _context.SaveChangesAsync();
    
    // Возвращаем 201 статус и путь к новому объекту
    return CreatedAtAction(nameof(GetById), new { id = model.Id }, model.ToStockDto());
}
Суть: Ты возвращаешь не просто «объект или пустоту», а конкретный статус-код, чтобы фронтенд точно знал, выводить данные или показывать ошибку.