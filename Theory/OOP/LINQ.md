(Самая частая цепочка в работе):

        Источник ➔ Where (фильтр) ➔ Join (связь) ➔ GroupBy (папки) ➔ Select (итоги) ➔ OrderBy (красота) ➔ ToList (финал).


I. Архитектурные основы
1. Декларативный стиль (Declarative Programming)
Определение: Подход, при котором код описывает «что» нужно получить, а не «как» (пошаговая реализация циклов и проверок скрыта внутри методов LINQ).

        C#
        // Императивный стиль (КАК делать):
        var result = new List<Goods>();
        foreach (var item in _allGoods) {
            if (item.Price > 100) result.Add(item);
        }
        
        // Декларативный стиль (ЧТО получить):
        var result = _allGoods.Where(g => g.Price > 100);
2. Отложенное выполнение (Deferred Execution)
Определение: Механизм, при котором запрос не выполняется в момент создания. Он «срабатывает» только тогда, когда вы начинаете перечислять элементы (через foreach, .ToList(), .Count()).

        C#
        var query = _allGoods.Where(g => g.Price > 5000); // Поиск еще не начался
        // ... здесь можно добавить еще условий ...
        var list = query.ToList(); // Выполнение началось только здесь
3. IEnumerable<T>
Определение: Интерфейс-контракт, который позволяет перечислять элементы коллекции. Все методы LINQ — это методы расширения для этого интерфейса.

        // 1. Любой список (List) реализует IEnumerable
        IEnumerable<string> names = new List<string> { "TV", "Smartphone", "Tablet" };
        
        // 2. Благодаря интерфейсу мы можем вызывать методы LINQ (это методы расширения)
        IEnumerable<string> filteredNames = names.Where(n => n.Length > 5);
        
        // 3. IEnumerable работает через итератор: данные подтягиваются только при переборе
        foreach (string name in filteredNames)
        {
            Console.WriteLine(name); // Выведет: Smartphone, Tablet
        }
🛠️ II. Базовые операции (Фильтрация и Поиск)
1. Where (Фильтрация)
Определение: Отбирает элементы, соответствующие заданному условию (предикату).

        C#
        var electronics = _allGoods.Where(g => g.Category == "Electronics" && g.Price < 1000);
2. Select (Проекция)
Определение: Трансформирует элементы одного типа в другой или выбирает конкретные поля.

        C#
        // Трансформация объекта в строку
        var names = _allGoods.Select(g => g.Name);
        
        // Создание анонимного объекта (только имя и цена)
        var simpleItems = _allGoods.Select(g => new { g.Name, g.Price });
3. First / FirstOrDefault (Поиск одного)
Определение: Возвращает первый найденный элемент. FirstOrDefault возвращает null, если ничего не найдено.

        C#
        var item = _allGoods.FirstOrDefault(g => g.Name == "iPhone");
4. Кванторы (Any, All, Contains)
Определение: Методы, возвращающие bool (проверка условий на всей коллекции).

        C#
        bool hasDebt = _allGoods.Any(g => g.Stock == 0); // Есть ли хоть один пустой?
        bool allValid = _allGoods.All(g => g.Price > 0); // Все ли цены положительные?
📊 III. Сортировка и Агрегация
1. OrderBy / ThenBy (Сортировка)
Определение: Упорядочивание данных. ThenBy используется для вторичной сортировки.

        C#
        var sorted = _allGoods
            .OrderBy(g => g.Category)          // Сначала по категории
            .ThenByDescending(g => g.Price);   // Внутри категории по цене (от дорогих)
2. Агрегатные функции (Sum, Max, Count)
Определение: Вычисление одного итогового значения на основе всей коллекции.

        C#
        var totalValue = _allGoods.Sum(g => g.Price * g.Stock);
        var maxPrice = _allGoods.Max(g => g.Price);
🚀 IV. Продвинутые манипуляции данными
1. GroupBy (Группировка)
Определение: Распределяет элементы по «корзинам» на основе ключа.

        C#
        
        var report = _allGoods
            .GroupBy(g => g.Category)
            .Select(group => new {
                CategoryName = group.Key,
                Count = group.Count(),
                AvgPrice = group.Average(x => x.Price)
            });
2. Множества (Distinct, Except, Union, Intersect)
Определение: Операции сравнения коллекций как математических множеств.

        C#
        var listA = new[] { "TV", "Phone" };
        var listB = new[] { "Phone", "Laptop" };
        
        var uniqueInA = listA.Except(listB);    // "TV" (есть в А, нет в Б)
        var shared = listA.Intersect(listB);    // "Phone" (есть в обоих)
        var combined = listA.Union(listB);      // "TV", "Phone", "Laptop" (объединение без дублей)
        var distinct = listA.Distinct();        // Убрать дубликаты
3. Join (Соединение)
Определение: Объединение двух разных коллекций по совпадающему ключу.

        C#
        
        var discounts = new Dictionary<string, decimal> { { "Electronics", 0.15m } };
        
        var discountedGoods = _allGoods.Join(
            discounts,
            g => g.Category,          // Ключ первой коллекции
            d => d.Key,               // Ключ второй (словаря)
            (g, d) => new { g.Name, SalePrice = g.Price * (1 - d.Value) }
        );

4. SelectMany (Сплющивание / Flattening)
Определение: Операция, которая проецирует каждый элемент последовательности во вложенную коллекцию и объединяет все полученные подколлекции в один «плоский» поток.

        var departments = new List<Department>
        {
            new Department { Name = "IT", Staff = new[] { "Ivan", "Oleg" } },
            new Department { Name = "HR", Staff = new[] { "Anna", "Maria" } }
        };
        
        // Плоский список всех имен: ["Ivan", "Oleg", "Anna", "Maria"]
        var allStaffNames = departments.SelectMany(d => d.Staff);

5. GroupJoin: «Один ко многим»
Теория: Это аналог LEFT JOIN в SQL, но в мире объектов он работает интереснее. Он берет «левую» коллекцию и для каждого её элемента находит все соответствующие элементы в «правой» коллекции, отдавая их вам в виде готовой группы (набора).

        var categories = new[] { "Electronics", "Food", "Books" };
        var products = new[] 
        { 
            new { Name = "Phone", Cat = "Electronics" }, 
            new { Name = "Bread", Cat = "Food" },
            new { Name = "Laptop", Cat = "Electronics" }
        };
        
        var summary = categories.GroupJoin(
            products,
            cat => cat,             // Ключ из категорий
            prod => prod.Cat,       // Ключ из товаров
            (cat, prodGroup) => new 
            { 
                Category = cat, 
                Count = prodGroup.Count() // Работаем сразу с группой
            }
        );
        
        // Результат:
        // Electronics: 2
        // Food: 1
        // Books: 0 (Обычный Join просто выкинул бы книги)
6. Пагинация (Skip, Take)
Определение: Пропуск определенного количества элементов и взятие следующей «порции».

        C#
        int pageSize = 10;
        int pageNumber = 3;
        var page = _allGoods.Skip((pageNumber - 1) * pageSize).Take(pageSize);
7. Zip (Попарное соединение)
Определение: Склеивает два списка по индексу (первый с первым и т.д.).

        C#
        var names = new[] { "Item1", "Item2" };
        var codes = new[] { "A-01", "B-02" };
        var zipped = names.Zip(codes, (n, c) => $"{n} [{c}]"); // "Item1 [A-01]"
🛡️ V. Безопасность и ошибки
1. Замыкание (Closure)
Определение: Ситуация, когда лямбда-выражение захватывает внешнюю переменную, значение которой может измениться к моменту выполнения.

        C#
        var filters = new List<Func<int, bool>>();
        for (int i = 0; i < 3; i++) {
            int currentI = i; // Создаем локальную копию для захвата
            filters.Add(x => x > currentI);
        }
2. Лишние преобразования
Определение: Избыточный вызов .ToList() или .ToArray() внутри цепочки, что приводит к ненужному копированию данных в память.
