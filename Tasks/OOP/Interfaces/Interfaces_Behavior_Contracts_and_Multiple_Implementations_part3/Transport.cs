namespace Interfaces_Behavior_Contracts_and_Multiple_Implementations_part3
{
    public abstract class Transport
    {
        private string _model;
        private int _speed;

        public string Model { get => _model; }
        public int Speed { get => _speed; }

        public Transport(string model, int speed)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(model);
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(speed, 0);

            _model = model;
            _speed = speed;
        }

        public abstract void Move();
    }
}
