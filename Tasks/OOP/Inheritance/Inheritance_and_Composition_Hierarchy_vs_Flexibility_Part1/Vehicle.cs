namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility_part1
{
    public abstract class Vehicle
    {
        //хранилище данных
        private string? _model;
        private Engine? _engine;

        //доступ к хранилищу только у наследников, и только для просмотра.
        protected string? Model => _model;
        protected Engine? WorkEngine => _engine;

        //проверка данных
        protected Vehicle(string? model, Engine engine)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentNullException("Название модели обязательно!", nameof(model));

            if (engine == null)
                throw new ArgumentException("Двигатель не можеть быть null!", nameof(engine));

            _model = model;
            _engine = engine;
        }

        //Метка для того, чтобы класс не был пустым, и имел поведение, закидываем идею, а
        //дальнейшую реализацию оставим для наследников
        public abstract void Drive();
    }
}
