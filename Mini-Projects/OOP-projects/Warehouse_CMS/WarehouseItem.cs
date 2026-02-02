namespace Warehouse_CMS
{
    public class WarehouseItem
    {
        private readonly Product _product;
        private int _quantity;

        public Product Product { get => _product; }
        public int Quantity { get => _quantity; }

        public WarehouseItem(Product product, int quantity)
        {
            _product = product;
            _quantity = Validator.IsValidQuantity(quantity);
        }

        public void UpdateQuantity(int amount)
        {
            _quantity = Validator.IsValidQuantity(amount);
        }
    }
}
