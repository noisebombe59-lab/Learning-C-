namespace LINQ_part2
{
    public class LogisticsOperator
    {
        const string separator = "---------------------------------------------------------------------";

        private readonly List<DeliveryOrder> _deliveryOrders = new();
        private readonly List<Vehicle> _vehicles = new();
        private readonly List<Drivers> _drivers = new();
        private readonly List<string> _cityBlackList = new();

        public IReadOnlyList<DeliveryOrder> DeliveryOrders => _deliveryOrders.AsReadOnly();
        public IReadOnlyList<Vehicle> Vehicles => _vehicles.AsReadOnly();
        public IReadOnlyList<Drivers> Drivers => _drivers.AsReadOnly();
        public IReadOnlyList<string> cityBlackList => _cityBlackList.AsReadOnly();

        public void GetAvailableCitiesReport()
        {
            int cityNumber = 1;

            var availableCities = _deliveryOrders
                .Select(p => p.Destination)
                .Distinct()
                .Except(_cityBlackList);

            foreach (var c in availableCities)
            {
                Console.WriteLine($"Список уникальных городов");
                Console.WriteLine($"Город No {cityNumber} - {c}");
                cityNumber++;
            }
        }

        public void AddToBlackList(string forbiddenCity)
        {
            _cityBlackList.Add(forbiddenCity);
        }

        public void AddDriver(Drivers driver)
        {
            _drivers.Add(driver);
        }
        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }
        public void AddOrder(DeliveryOrder order)
        {
            _deliveryOrders.Add(order);
        }

        public void GroupByDeliveryStatus()
        {
            var grouping = _deliveryOrders
                .GroupBy(p => p.OrderStatusActivity)
                .Select(group => new
                {
                    OrderStatus = group.Key,
                    OrderCount = group.Count(),
                    TotalCost = group.Sum(s => s.OrderPrice * s.OrderCapacity),
                    AvgWeight = group.Average(w => w.OrderWeight)
                });

            foreach (var group in grouping)
            {
                Console.WriteLine($"Информация по заказу: Статус заказа: {group.OrderStatus}, Кол-во заказов: {group.OrderCount}," +
                    $" Общая стоимость: {group.TotalCost}, Стредний вес: {group.AvgWeight}");
            }
        }

        public void GetRideReport(int pageNumber = 1, int pageSize = 10)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(pageNumber, 1);

            var getRideReport = _deliveryOrders
                .OrderBy(p => p.OrderId)
                .Join(
                _vehicles,
                order => order.VehicleId,
                vehicle => vehicle.VehicleId,
                (order, vehicle) => new { order, vehicle }
                )
                .Join(
                _drivers,
                temp => temp.vehicle.DriverId,
                driver => driver.DriverId,
                (temp, driver) => new
                {
                    carName = temp.vehicle.VehicleName,
                    driverFullName = driver.DriverFullName,
                    destination = temp.order.Destination,
                })
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (_vehicles.Count == 0 || _drivers.Count == 0)
            {
                Console.WriteLine("В списке нет данных");
                return;
            }

            foreach (var item in getRideReport)
            {
                Console.WriteLine($"[{item.carName}] — [{item.driverFullName}] — [{item.destination}].");
            }
        }
    }
}
