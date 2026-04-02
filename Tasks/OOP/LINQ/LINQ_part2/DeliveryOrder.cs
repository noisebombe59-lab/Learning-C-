namespace LINQ_part2
{
    public class DeliveryOrder
    {
        public string Destination { get; set; }
        public string OrderStatusActivity { get; set; }
        public string OrderName { get; set; }
        public int OrderCapacity { get; set; }
        public int OrderId { get; }
        public int VehicleId { get; set; }
        public decimal OrderWeight { get; set; }
        public decimal OrderPrice { get; }

        public DeliveryOrder(string orderName, decimal orderPrice, int orderId, string orderStatusActivity, int orderCapacity, decimal orderWeight, int vehicleId, string destination)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(orderName);
            ArgumentException.ThrowIfNullOrWhiteSpace(destination);
            ArgumentException.ThrowIfNullOrWhiteSpace(orderStatusActivity);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(orderPrice);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(orderId);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(orderCapacity);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(orderWeight);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(vehicleId);

            OrderName = orderName;
            OrderPrice = orderPrice;
            OrderId = orderId;
            OrderCapacity = orderCapacity;
            OrderStatusActivity = orderStatusActivity;
            OrderWeight = orderWeight;
            VehicleId = vehicleId;
            Destination = destination;
        }
    }
}
