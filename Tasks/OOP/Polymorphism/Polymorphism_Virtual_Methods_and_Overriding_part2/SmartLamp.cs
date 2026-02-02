namespace Polymorphism_Virtual_Methods_and_Overriding_part2
{
    public class SmartLamp : SmartDevice
    {
        public int Bright { get; protected set; }

        public SmartLamp(int bright, string? name, bool isOn) : base(name, isOn)
        {
            if (bright < 0)
                throw new ArgumentException("Яркость не может быть отрицательной", nameof(bright));

            Bright = bright;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Bright = 100;
            Console.WriteLine($"Яркость лампы увеличена на: {Bright}");
        }
    }
}
