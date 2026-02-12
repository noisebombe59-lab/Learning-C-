namespace Delegates_and_Events_Action_Func_and_Observer_Pattern
{
    public class SmartHub
    {
        public Predicate<string>? RoomFilter { get; set; }
        public Action<string>? Logger { get; set; }

        public Func<int, double>? EnergyCalculator;

        public event EventHandler<MotionEventArgs>? MotionStatusChanged;

        public void DetectMotion(string room, bool status)
        {
            Logger?.Invoke($"[Hub System]: начинаю обработку датчика в '{room}'");

            var args = new MotionEventArgs(room, status);

            if (RoomFilter != null && !RoomFilter(room))
            {
                return;
            }

            MotionStatusChanged?.Invoke(this, args);

            Logger?.Invoke($"[Hub System]: Оповещение подписчиков завершено.");
        }

        public void PrintReport(int rooms)
        {
            if (EnergyCalculator == null)
            {
                return;
            }

            double energyCalculeteResult = EnergyCalculator.Invoke(rooms);

            Logger?.Invoke($"[REPORT]: Прогноз потребления энергии: {energyCalculeteResult} кВт");
        }
    }
}
