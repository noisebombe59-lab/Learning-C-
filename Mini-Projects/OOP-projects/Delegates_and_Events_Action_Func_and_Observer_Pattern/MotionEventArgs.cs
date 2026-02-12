namespace Delegates_and_Events_Action_Func_and_Observer_Pattern
{
    public class MotionEventArgs : EventArgs
    {
        public string RoomName { get; set; }
        public bool IsDetected { get; set; }

        public MotionEventArgs(string roomName, bool isDetected)
        {
            ArgumentException.ThrowIfNullOrEmpty(roomName, nameof(roomName));

            RoomName = roomName;
            IsDetected = isDetected;
        }
    }
}
