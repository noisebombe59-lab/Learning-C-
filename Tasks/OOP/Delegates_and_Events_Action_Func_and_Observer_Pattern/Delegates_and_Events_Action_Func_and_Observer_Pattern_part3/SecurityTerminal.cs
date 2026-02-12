namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part3
{
    public class SecurityTerminal
    {
        public void Activity(MotionData motionData)
        {
            Console.WriteLine($"Зафиксировано движение: {motionData.Location}");
        }
    }
}
