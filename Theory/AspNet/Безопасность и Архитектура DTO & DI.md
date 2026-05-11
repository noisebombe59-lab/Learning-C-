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
