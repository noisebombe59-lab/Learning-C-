namespace Polymorphism_Virtual_Methods_and_Overriding_part2
{
    public class Program
    {
        static void Main()
        {
            try
            {
                const string separator = "****************************************************";

                List<SmartDevice> smartDevices = new List<SmartDevice>();
                SmartLamp smartLamp = new SmartLamp(500, "Classic Desktop Lamp", true);
                SmartSpeaker smartSpeaker = new SmartSpeaker(10, "Jbl Extreme", true);

                smartDevices.Add(smartLamp);
                smartDevices.Add(smartSpeaker);

                foreach (var smartDevice in smartDevices)
                {
                    if (smartDevice is SmartLamp)
                    {
                        Console.WriteLine("Класс энергоэффективности - А+");
                        Console.WriteLine(separator);
                    }
                    else
                    {
                        Console.WriteLine($"[{smartDevice.Name}] не является объектом [SmartLamp]");
                        Console.WriteLine(separator);
                    }

                    smartDevice.TurnOn();
                    Console.WriteLine(separator);
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}