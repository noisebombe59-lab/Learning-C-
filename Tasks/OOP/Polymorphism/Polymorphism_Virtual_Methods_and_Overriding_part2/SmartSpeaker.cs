namespace Polymorphism_Virtual_Methods_and_Overriding_part2
{
    public class SmartSpeaker : SmartDevice
    {
        public int Volume { get; protected set; }

        public SmartSpeaker(int volume, string? name, bool isOn) : base(name, isOn)
        {
            if (volume < 0)
                throw new ArgumentException($"Громкость не может быть отрицательной", nameof(volume));

            Volume = volume;
        }

        public override void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"Привет, колонка включена [{IsOn}], и готова к работе, Громкость колонки: {Volume}");
        }
    }
}
