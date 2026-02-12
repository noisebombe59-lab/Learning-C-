namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part3
{
    public class Prorgam
    {
        static void Main()
        {
            try
            {
                var motionSensor = new MotionSensor();
                var securityTerminal = new SecurityTerminal();

                motionSensor.Trigger("Спальня");
                motionSensor.OnMotionData += securityTerminal.Activity;

                motionSensor.Trigger("Спальня");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}