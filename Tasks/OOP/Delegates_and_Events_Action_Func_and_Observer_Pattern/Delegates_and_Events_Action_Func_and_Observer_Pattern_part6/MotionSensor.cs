namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part6
{
    public class MotionSensor
    {
        public event EventHandler<MotionEventArgs>? SensorTriggered;

        public void Detect(string location)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(location, "location");
            SensorTriggered?.Invoke(this, new MotionEventArgs(location));
        }
    }
}
