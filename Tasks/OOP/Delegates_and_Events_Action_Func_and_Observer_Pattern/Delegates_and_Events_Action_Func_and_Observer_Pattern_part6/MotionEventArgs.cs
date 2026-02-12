namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part6
{
    public class MotionEventArgs : EventArgs
    {
        public string Location { get; set; }

        public MotionEventArgs(string location)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(location, "location");
            Location = location;
        }
    }
}
