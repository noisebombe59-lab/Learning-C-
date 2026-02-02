namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations_part2
{
    public class Program
    {
        static void Main()
        {
            try
            {
                const string separator = "--------------------------------------------------";

                List<ISwitchable> switchables = new List<ISwitchable>(  );
                SmartLamp smartLamp = new SmartLamp(true);
                SmartSensor smartSensor = new SmartSensor(false, 55);

                switchables.Add(smartLamp);
                switchables.Add(smartSensor);

                foreach (var device in switchables)
                {
                    device.TurnOn();

                    if (device is IDataProvider dataProvider)
                    {
                        string checkResult = dataProvider.GetStatusData();
                        Console.WriteLine(checkResult);
                    }
                    Console.WriteLine(separator);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}