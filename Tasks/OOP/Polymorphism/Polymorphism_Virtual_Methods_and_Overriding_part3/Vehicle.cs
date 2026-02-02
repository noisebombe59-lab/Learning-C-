namespace Polymorphism_Virtual_Methods_and_Overriding_part3
{
    public class Vehicle
    {
        public string? Model { get; }
        public int EnginePower { get; }

        public Vehicle(string? model, int enginePower)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentNullException("Название модели обязательно", nameof(model));

            if (enginePower < 0)
                throw new ArgumentException("Мощность двигатель не может быть отрицательной", nameof(enginePower));

            Model = model;
            EnginePower = enginePower;
        }

        public virtual double CalculateTax()
        {
            double standartTax = EnginePower * 5;
            return standartTax;
        }
    }
}
