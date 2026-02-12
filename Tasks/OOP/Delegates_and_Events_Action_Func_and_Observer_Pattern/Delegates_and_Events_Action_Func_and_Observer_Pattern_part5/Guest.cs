namespace Delegates_and_Events_Action_Func_and_Observer_Pattern_part5
{
    public class Guest
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Guest(string name, int age)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(age, nameof(age));

            Name = name;
            Age = age;
        }
    }
}
