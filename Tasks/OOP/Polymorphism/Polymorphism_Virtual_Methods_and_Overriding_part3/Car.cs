namespace Polymorphism_Virtual_Methods_and_Overriding_part3
{
    public class Car : Vehicle
    {
        public Car(string? model, int enginePower) : base(model, enginePower) { }

        public override double CalculateTax()
        {
            double taxForCar = EnginePower * 7;
            return taxForCar;
        }
    }
}
