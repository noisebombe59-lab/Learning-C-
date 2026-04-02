namespace LINQ_part2
{
    public class Vehicle
    {
        public string VehicleName { get; set; }
        public int VehicleLiftingCapacity { get; set; }
        public bool IsVehicleAvialable { get; set; } = true;
        public int VehicleId { get; set; }
        public int DriverId { get; set; }

        public Vehicle(string vehicleName, int vehicleLiftingCapacity, bool isVehicleAvialable, int vehicleId, int driverId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(vehicleName);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(vehicleLiftingCapacity);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(vehicleId);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(driverId);

            VehicleName = vehicleName;
            VehicleLiftingCapacity = vehicleLiftingCapacity;
            IsVehicleAvialable = isVehicleAvialable;
            VehicleId = vehicleId;
            DriverId = driverId;
        }
    }
}
