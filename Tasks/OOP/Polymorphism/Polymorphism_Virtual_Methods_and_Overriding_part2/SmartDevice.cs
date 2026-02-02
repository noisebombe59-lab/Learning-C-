namespace Polymorphism_Virtual_Methods_and_Overriding_part2
{
    public class SmartDevice
    {
        private readonly string? _name;

        public string? Name { get => _name; }
        public bool IsOn { get; protected set; } = false;
        protected SmartDevice(string? name, bool isOn)
        {
            if (name is null || name is "")
                throw new ArgumentNullException("Имя обязательно", nameof(name));

            _name = name;
            IsOn = isOn;
        }
        public virtual void TurnOn()
        {
            if (!IsOn)
            {
                Console.WriteLine("Девайс включен");
                IsOn = true;
            }
        }

        public virtual void TurnOff()
        {
            if (IsOn)
            {
                Console.WriteLine("Девайс выключен");
                IsOn = false;
            }
        }
    }
}
