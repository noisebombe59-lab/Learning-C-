namespace Generics_and_Constraints
{
    public class ElectronicsOrder : BaseOrder
    {
        public int WarrantyMonths { get; set; }

        public ElectronicsOrder() { }
        public ElectronicsOrder(int warrantyMonths)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(warrantyMonths, 12);

            WarrantyMonths = warrantyMonths;
        }
    }
}
