namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part5
{
    public class ClubControl
    {
        public void CheckGuest(Guest guest, Predicate<Guest> filter)
        {
            if (filter(guest))
            {
                Console.WriteLine($"Проходите {guest.Name}");
            }
            else
            {
                Console.WriteLine("Вход запрещен");
            }
        }
    }
}
