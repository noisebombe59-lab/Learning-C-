namespace Polymorphism_Virtual_Methods_and_Overriding_part3
{
    public class Truck : Vehicle
    {
        public int MaxCargoWeight { get; }
        public int CurrentLoad { get; }
        public Truck(string? model, int enginePower, int maxCargoWeight, int currentLoad) : base(model, enginePower)
        {
            if (maxCargoWeight < 0)
                throw new ArgumentException("Вес не может быть отрицательным", nameof(maxCargoWeight));

            if (currentLoad > maxCargoWeight)
                throw new ArgumentException("Привышен лимит грузоподъемности", nameof(maxCargoWeight));
            
            MaxCargoWeight = maxCargoWeight;
            CurrentLoad = currentLoad;
        }

        public override double CalculateTax()
        {
            double taxForTruck = EnginePower * 10;
            return taxForTruck;
        }
    }
}
