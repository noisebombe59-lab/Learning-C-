namespace Inheritance_and_Composition_Hierarchy_vs_Flexibility_part4
{
    public class Processor
    {
        public string Model { get; init; }
        public int Cores { get; init; }

        public Processor(string model, int cores)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentNullException("Название модели обязательно", nameof(model));

            if (cores <= 0)
                throw new ArgumentException("Количество ядер не может быть отрицательным или равно 0", nameof(cores));

            Model = model;
            Cores = cores;
        }
    }
}
