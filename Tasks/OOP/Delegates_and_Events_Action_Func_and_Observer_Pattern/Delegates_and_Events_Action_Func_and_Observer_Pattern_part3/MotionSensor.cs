namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part3
{
    public class MotionSensor
    {
        public event Action<MotionData>? OnMotionData;

        public void Trigger(string place)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(place, nameof(place));

            if (OnMotionData == null)
            {
                Console.WriteLine("Данные о движении отсутствуют");
                return;
            }
            else
            {
                MotionData motionData = new MotionData(place);
                OnMotionData?.Invoke(motionData);
            }
        }
    }
}
