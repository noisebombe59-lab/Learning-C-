namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility_part1
{
    //Наследуем данные у Vehicle
    public class Truck : Vehicle
    {
        //конструктор базируется на данных конструктора родителя,
        //в котором данные уже чистые, чтобы иметь такие же
        public Truck(string model, Engine engine) : base(model, engine) { }

        //Тут добавляем поведение, которое оставили на будущее в абстрактном классе.
        //Когда будет полноценный полиморфизм, мы будем полноценно менять поведение,
        //а не просто доавлять
        public override void Drive()
        {
            Console.WriteLine($"Грузовик {Model} поехал. Мощность: {WorkEngine?.Power} л.с.");
        }
    }
}
