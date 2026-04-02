namespace LINQ_part4
{
    public record Cargo(
        int CargoId,
        int CargoWeight,
        int CargoCost,
        int CargoQuantity,
        double CargoVolume,
        string CargoType,
        string CargoUrgencyStatus,
        string CargoDestination
        );

    public record Vehicle(int VehicleId, int LiftingCapacity, int CargoId, string AvailabilityStatus, string BrandName);
    public record Delivery(DateTime DeliveryTime, int CityId, IEnumerable<Cargo> Cargo);
    public record Cities(int CityId, string Name, string Country);

    public class SortingСenter
    {
        private readonly List<Cities> _cities = new();
        private readonly List<Cargo> _cargos = new();
        private readonly List<Vehicle> _vehicles = new();
        private readonly List<Delivery> _deliveries = new();

        public IReadOnlyList<Cities> Cities => _cities.AsReadOnly();
        public IReadOnlyList<Delivery> Deliveries => _deliveries.AsReadOnly();
        public IReadOnlyList<Cargo> Cargos => _cargos.AsReadOnly();
        public IReadOnlyList<Vehicle> Vehicles => _vehicles.AsReadOnly();

        public void AddDeliveries(IEnumerable<Delivery> deliveries)
        {
            ArgumentNullException.ThrowIfNull(deliveries);

            if (!deliveries.Any())
            {
                throw new ArgumentException("Список доставок не может быть путым.", nameof(deliveries));
            }
            _deliveries.AddRange(deliveries);
        }

        public void AddCargo(IEnumerable<Cargo> cargos)
        {

            ArgumentNullException.ThrowIfNull(cargos);

            if (!cargos.Any())
            {
                throw new ArgumentException("Список грузов не может быть пустым.", nameof(cargos));
            }
            _cargos.AddRange(cargos);

        }

        public void AddVehicle(IEnumerable<Vehicle> vehicles)
        {
            ArgumentNullException.ThrowIfNull(vehicles);

            if (!vehicles.Any())
            {
                throw new ArgumentException("Список грузов не может быть пустым.", nameof(vehicles));
            }
            _vehicles.AddRange(vehicles);
        }

        public void AddCity(IEnumerable<Cities> cities)
        {
            ArgumentNullException.ThrowIfNull(cities);

            if (!cities.Any())
            {
                throw new ArgumentException("Список городов  не может быть пустыми.", nameof(_cities));
            }
            _cities.AddRange(cities);
        }

        public void GetRouteSheetReport()
        {
            var cargoСalculations = new CargoСalculations();
            cargoСalculations.GroupByDestination(_cargos);
        }

        public void GetTopFiveReport()
        {
            var displayTopReport = new CargoСalculations();
            displayTopReport.FindTopFiveByCost(_cargos);
        }

        public void GetVehicleForCargoReport()
        {
            var displayVehicleReport = new CargoСalculations();
            displayVehicleReport.FindVehicleForHeavyCargo(_vehicles, _cargos);
        }

        public void GetPolicyLimitsReport()
        {
            var limitsCalculation = new CargoСalculations();
            var limitsReport = new LimitsService();
            limitsCalculation.CheckCargoByInsurenceLimits(_cargos, limitsReport);
        }

        public void GetUniqueCitiesReport()
        {
            var citiesReport = new CargoСalculations();
            citiesReport.CheckUniqueCities(_cities, _deliveries);
        }
    }
}
