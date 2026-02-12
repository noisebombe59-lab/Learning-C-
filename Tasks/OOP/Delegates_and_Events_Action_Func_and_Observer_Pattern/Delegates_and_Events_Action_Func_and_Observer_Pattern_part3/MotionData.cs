namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part3
{
    public class MotionData
    {
        public string Location { get; set; }

        public MotionData(string location)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(location, nameof(location));
            Location = location;
        }
    }
}
