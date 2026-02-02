namespace Dependency_Injection
{
    public class Program
    {
        static void Main()
        {
            ISender smsSender = new SmsSender();
            NotificationService notification = new NotificationService(smsSender);

            notification.Notify("Тестовое уведомление от SmsSender");

            ISender emailSender = new EmailSender();
            NotificationService notification1 = new NotificationService(emailSender);

            notification1.Notify("Тестовое уведомление от EmailSender");
            Console.ReadKey();
        }
    }
}