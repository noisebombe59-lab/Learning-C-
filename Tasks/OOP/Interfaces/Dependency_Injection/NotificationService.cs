namespace Dependency_Injection
{
    public class NotificationService
    {
        private readonly ISender _sender;

        public NotificationService(ISender sender)
        {
            _sender = sender;
        }

        public void Notify(string message)
        {
            _sender.Send(message);
        }
    }
}
