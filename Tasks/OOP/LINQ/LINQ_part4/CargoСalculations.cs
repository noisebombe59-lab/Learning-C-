namespace LINQ_part4
{
    public class CargoСalculations
    {
        const string separator = "------------------------------------------------------------------";
        public void GroupByDestination(IEnumerable<Cargo> cargos)
        {
            var grouping = cargos.GroupBy(g => g.CargoDestination)
                .Select(group => new
                {
                    City = group.Key,
                    TotalCount = group.Sum(s => s.CargoQuantity),
                    TotalCost = group.Sum(s => s.CargoCost),
                    AverageVolume = group.Average(a => a.CargoVolume),
                });

            Console.WriteLine("[Маршрутный лист]:");
            foreach (var group in grouping)
            {
                Console.WriteLine($"Город: {group.City}");
                Console.WriteLine($"    * Общее количество посылок: {group.TotalCount}");
                Console.WriteLine($"    * Общая ценность груза: {group.TotalCost:n0}");
                Console.WriteLine($"    * Средний объем груза: {group.AverageVolume:f2}");
                Console.WriteLine(separator);
            }
        }

        public void FindTopFiveByCost(IEnumerable<Cargo> cargos)
        {
            var topFive = cargos.Where(w => w.CargoUrgencyStatus == "Critical")
                .OrderByDescending(o => o.CargoCost)
                .ThenByDescending(o => o.CargoWeight)
                .Take(5);

            Console.WriteLine("[Топ 5 грузов]:");
            foreach (var cargo in topFive)
            {
                Console.WriteLine($"    *Цена: {cargo.CargoCost}");
                Console.WriteLine($"    *Статус: {cargo.CargoUrgencyStatus}");
                Console.WriteLine($"    *Вес: {cargo.CargoWeight}");
                Console.WriteLine(separator);
            }
        }

        public void FindVehicleForHeavyCargo(IEnumerable<Vehicle> vehicles, IEnumerable<Cargo> cargos)
        {
            var isCompatible = cargos
                .Where(w => w.CargoWeight > 500)
                .Join(vehicles,
                cargId => cargId.CargoId,
                vehId => vehId.VehicleId,
                (cargId, vehId) => new
                {
                    vId = vehId.CargoId,
                    cName = cargId.CargoType,
                    vLiftingLimits = vehId.LiftingCapacity,
                    vStatus = vehId.AvailabilityStatus,
                    cWeight = cargId.CargoWeight,
                })
                .GroupBy(g => g.vId)
                .Select(group => new
                {
                    VehId = group.Key,
                    isFits = group.Where(w => w.vLiftingLimits >= w.cWeight && w.vStatus == "Ready"),
                    CargoName = group.First().cName
                });

            Console.WriteLine("[Распределение груза по соответственному транспорту]");

            foreach (var item in isCompatible)
            {
                Console.WriteLine($"    *[Название груза]: {item.CargoName}");
                Console.WriteLine($"    *[ID подходящей машины]: {item.VehId}");
                Console.WriteLine(separator);
            }
        }

        public void CheckCargoByInsurenceLimits(IEnumerable<Cargo> cargos, IInsurancePolicy policy)
        {
            var currentLimit = policy.GetLimit();

            var badCargoIds = cargos
                .Where(w => w.CargoCost > currentLimit)
                .Select(s => s.CargoId);

            Console.WriteLine("[Проверка лимитов по страховке]:");
            if (badCargoIds.Any())
            {
                Console.WriteLine($"    *[Грузы с ID: [{String.Join(", ", badCargoIds)}] привысили лимит страховки! [{currentLimit}]]");
                Console.WriteLine(separator);
            }
            else
            {
                Console.WriteLine($"    *[Все грузы в пределах лимита [{currentLimit}]]");
                Console.WriteLine(separator);
            }
        }

        public void CheckUniqueCities(IEnumerable<Cities> cities, IEnumerable<Delivery> deliveries)
        {
            var dateFilter = deliveries.Where(w => w.DeliveryTime.Date == DateTime.Today);

            var uniqueCities = cities
                .GroupJoin(
                dateFilter,
                city => city.CityId,
                delivery => delivery.CityId,
                (city, cityDeliveries) => new
                {
                    CityName = city.Name,
                    HasDeliveries = cityDeliveries.Any()
                })
                .Where(w => w.HasDeliveries);

            if (uniqueCities.Any())
            {
                Console.WriteLine("Список уникальных городов с доставкой на сегодня:");
                foreach (var item in uniqueCities)
                {
                    Console.WriteLine($"    *{String.Join("\n", item.CityName)}");
                }

            }
            else
            {
                Console.WriteLine($"На сегодня доставок в уникальные города нет");
            }
        }
    }
}
