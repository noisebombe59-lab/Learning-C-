namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part5
{
    public class Program
    {
        static void Main()
        {
            try
            {
                var guest1 = new Guest("Сергей", 17);
                var guest2 = new Guest("Антон", 18);
                var clubControl = new ClubControl();

                clubControl.CheckGuest(guest1, IsAdult);
                clubControl.CheckGuest(guest2, IsAdult);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)    
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
        static bool IsAdult(Guest g)
        {
            if (g.Age >= 18)
            {
                return true;
            }
            return false;
        }
    }
}