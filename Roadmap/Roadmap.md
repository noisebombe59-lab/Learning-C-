# План обучения: C# и .NET разработчик

## Фаза 1: C# и .NET База (The Core Language)
Здесь проверяют понимание того, как управляемый код работает с памятью и структурами данных.

### Что искать (Подтемы)

#### Система типов (Type System)
* **Value Types vs Reference Types** (Значимые и ссылочные типы).
* **Stack vs Heap memory C#** (Стек и куча: что где хранится).
* **Boxing and Unboxing C#** (Упаковка и распаковка, почему это бьет по производительности).
* **Nullable reference types C#** (Операторы `?`, `!`, `??`, `??=`).

#### ООП в C# (OOP Implementation)
* **Интерфейсы против Абстрактных классов** (`Interface vs Abstract class C#` — классика собеседований).
* **Модификаторы доступа** (`public`, `private`, `protected`, `internal`, `protected internal`, `private protected`).
* **Переопределение методов** (`virtual`, `override`, `new` оператор сокрытия).

#### Коллекции и Дженерики (Collections & Generics)
* **Generic constraints C#** (Ограничения обобщений: `where T : class`, `where T : new()`).
* **Внутреннее устройство `List<T>`** (Как расширяется массив внутри, что такое `Capacity` и `Count`).
* **Внутреннее устройство `Dictionary<TKey, TValue>`** (Что такое хэш-таблица, коллизии, `GetHashCode`).

#### LINQ (Language Integrated Query)
* **Deferred execution LINQ** (Отложенное выполнение: разница между подготовкой запроса и его выполнением).
* **Основные операторы:** `Select`, `Where`, `SelectMany`, `FirstOrDefault`, `GroupBy`, `ToDictionary`, `ToList`.

#### Управление памятью (Memory Management)
* **Garbage Collector C# basics** (Поколения GC: 0, 1, 2 и куча больших объектов LOH).
* **IDisposable pattern and using statement** (Освобождение неуправляемых ресурсов).

---

## Фаза 2: Создание REST API (ASP.NET Core)
Фокус на обработке HTTP-запросов и жизненном цикле приложения.

### Что искать (Подтемы)

#### Протокол HTTP (Web Basics)
* **HTTP Methods** (`GET`, `POST`, `PUT`, `DELETE`, `PATCH`).
* **HTTP Status Codes** (`2xx`, `3xx`, `4xx`, `5xx` — знать основные наизусть).
* **Структура запроса/ответа** (Headers, Body, Query string, Route params).

#### Архитектура ASP.NET Core
* **ASP.NET Core Middleware pipeline** (Конвейер обработки запроса, как работают `App.Use...`).
* **Dependency Injection lifetimes** (`Transient`, `Scoped`, `Singleton` — где какой применять).

#### Маршрутизация и Эндпоинты (Routing)
* **Minimal APIs C# tutorial** (Современный синтаксис через `MapGet`, `MapPost`).
* **Controllers in ASP.NET Core** (Атрибуты `[ApiController]`, `[Route]`, `[FromBody]`, `[FromRoute]`).

#### Валидация и Обработка ошибок
* **FluentValidation ASP.NET Core** (Стандарт индустрии для проверки входящих DTO).
* **Global Exception Handling ASP.NET Core** (Как отловить любую ошибку в одном месте и вернуть красивый JSON).

#### Аутентификация и Авторизация
* **JWT Bearer authentication ASP.NET Core** (Как работает токен, из чего состоит: Header, Payload, Signature).
* **Role-based authorization C#** (Ограничение доступа через атрибут `[Authorize(Roles = "Admin")]`).

---

## Фаза 3: Базы данных (PostgreSQL & EF Core)
Джуниор должен уметь не просто писать код, но и понимать, во что этот код превращается на стороне СУБД.

### Что искать (Подтемы)

#### Чистый SQL и Реляционные концепции
* **SQL Joins explanation** (`INNER`, `LEFT`, `RIGHT`, `FULL`).
* **SQL Group By and Aggregate functions** (`COUNT`, `SUM`, `AVG`).
* **Первичные и Внешние ключи** (`Primary Key vs Foreign Key`), каскадное удаление.
* **Индексы:** `B-Tree index basics` (Зачем нужны, как ускоряют `WHERE` и почему замедляют `INSERT`).

#### Entity Framework Core (ORM)
* **EF Core Code First Migrations** (Создание таблиц из C# классов, `Add-Migration`, `Update-Database`).
* **DbContext lifecycle** (Почему `DbContext` обычно регистрируют как `Scoped`).
* **Data Loading EF Core** (Разница между Eager Loading через `.Include()` и Lazy Loading).

#### Оптимизация запросов
* **IQueryable vs IEnumerable EF Core** (Что выполняется на стороне базы, а что выкачивается в память приложения).
* **EF Core N+1 query problem** (Главная ошибка новичков: выполнение запроса в цикле).
* **AsNoTracking EF Core** (Отключение отслеживания сущностей для ускорения запросов на чтение).

---

## Фаза 4: Архитектура, Паттерны и Тестирование
Переход от "просто кода" к поддерживаемому коду.

### Что искать (Подтемы)

#### Принципы SOLID (на практических примерах C#)
* **Single Responsibility Principle C#** (Разделение контроллера, сервиса и репозитория).
* **Dependency Inversion Principle C#** (Почему мы внедряем интерфейсы, а не конкретные классы).

#### Структурирование проекта
* **Three-Tier Architecture .NET** (Трехуровневая архитектура: API -> Business Logic -> Data Access). Этого для уровня Junior+ более чем достаточно.

#### Unit-тестирование
* **xUnit tutorial .NET** (Пишем базовые тесты, атрибуты `[Fact]` и `[Theory]`).
* **FluentAssertions C#** (Красивые проверки: `result.Should().BeEquivalentTo(...)`).
* **NSubstitute C# или Moq C#** (Создание заглушек для интерфейсов, чтобы изолировать логику при тестировании).

#### Интеграционное тестирование
* **WebApplicationFactory integration testing ASP.NET Core** (Запуск API в памяти для реального тестирования эндпоинтов).

---

## Фаза 5: Асинхронность и Обмен сообщениями (Messaging)
Бэкэнд асинхронен по своей природе.

### Что искать (Подтемы)

#### Асинхронность в C# (Async/Await)
* **Async await state machine C#** (Концептуально: как компилятор превращает метод в автомат состояний).
* **Task vs ValueTask C#** (Когда использовать `ValueTask` ради производительности).
* **Deadlocks async await C#** (Почему нельзя вызывать `.Result` или `.Wait()`).
* **CancellationToken usage .NET** (Как отменить долгую операцию, если пользователь закрыл вкладку).

#### Брокеры сообщений (Концепт + Инструмент)
* **What is Message Broker (Producer, Consumer, Queue)** (Общая теория очередей).
* **MassTransit RabbitMQ ASP.NET Core** (Изучите MassTransit — это обертка, которая экономит недели написания шаблонного кода).

---

## Фаза 6: Фронтенд (React + TypeScript)
Бэкендеру фронтенд нужен на уровне "умею собрать форму, вывести список и обработать ошибки сети".

### Что искать (Подтемы)
* **Functional components and JSX** (Компоненты-функции и верстка внутри JS).
* **React hooks: useState** (Хранение состояния формы или данных).
* **React hooks: useEffect** (Вызов кода при загрузке страницы — именно тут дергают API).
* **Axios in React TypeScript или Fetch API React** (Отправка GET/POST запросов).
* **CORS error ASP.NET Core** (Что нужно включить на бэкенде, чтобы браузер разрешил React-приложению делать запросы к API).

---

## Фаза 7: Развертывание и DevOps (Контейнеризация)
Локальный запуск на Windows "у меня всё работает" больше не котируется. Всё должно жить в Linux-контейнерах.

### Что искать (Подтемы)
* **How to write Dockerfile for ASP.NET Core** (Сборка вашего приложения в образ).
* **Multi-stage builds Docker C#** (Правильный шаблон Dockerfile: сначала `dotnet restore/publish`, затем копирование готовых бинарей в чистый образ).
* **Docker Compose multi-container tutorial** (Связывание вашего API-контейнера и официального контейнера postgres в одну сеть).

---

## Фаза 8: Инструменты ИИ (AI Tools)

### Что искать и как внедрять
Вместо гугления синтаксиса, пишите в Cursor / Copilot промпты вида:
* *«Напиши xUnit тест для этого метода, используй NSubstitute для изоляции DbContext»*
* *«Сгенерируй FluentValidation правила для этого DTO: email должен быть валидным, пароль минимум 8 символов»*
```
