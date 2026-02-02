namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility_part1
{
    public class Engine
    {
        //инкапсуляция с приватным полем и свойством без сеттера,
        //чтобы поведением управлял класс внутри себя
        private int _power; 
        public int Power { get => _power; }
        //конструктор, корый выступит валидатором для будущих наследников,
        //которые будут использовать эти параметры
        public Engine(int power)
        {
            if (power < 50 || power > 1000)
                throw new ArgumentException("Ошибка: Сила не может быть < 50 и > 1000", nameof(power));

            _power = power;
        }
    }
}