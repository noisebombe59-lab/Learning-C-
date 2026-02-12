namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part2
{
    public class Program
    {
        static void Main()
        {
            var powerOffSystem = new PowerOffSystem();
            var waterHeater = new WaterHeater();

            waterHeater.BoillingFinished += powerOffSystem.TurnOff;
            waterHeater.StartHeating();
            Console.ReadKey();
        }
    }
}