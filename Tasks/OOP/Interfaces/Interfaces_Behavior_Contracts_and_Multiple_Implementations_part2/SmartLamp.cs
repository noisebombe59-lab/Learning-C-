namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations_part2
{
    public class SmartLamp : ISwitchable
    {
        public bool IsOn { get; private set; } = false;

        public SmartLamp(bool isOn)
        {
            IsOn = isOn;
        }
        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"Лампа включена: [{IsOn}]");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"Лампа выкллючена: [{IsOn}]");
        }

    }
}
