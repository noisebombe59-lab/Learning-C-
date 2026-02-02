namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations_part2
{
    public class SmartSensor : ISwitchable, IDataProvider
    {
        public bool IsActive { get; private set; } = false;
        public double LastValue { get; private set; }

        public SmartSensor(bool isActive, double lastValue)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(lastValue);

            IsActive = isActive;
            LastValue = lastValue;
        }
        public void TurnOn()
        {
            IsActive = true;
            Console.WriteLine($"Датчик включен: [{IsActive}]");
        }

        public void TurnOff()
        {
            IsActive = false;
            Console.WriteLine($"Датчик выключен: [{IsActive}]");
        }

        public string GetStatusData()
        {
            return $"Датчик Активен: [{IsActive}], последнее показание: [{LastValue}]";
        }
    }
}
