namespace Generics_and_Constraints
{
    public class ClothingOrder : BaseOrder
    {
        public int Size { get; set; }

        public ClothingOrder() { }

        public ClothingOrder(int size)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(size);
        }
    }
}
