namespace LINQ_part2
{
    public class Drivers
    {
        public string DriverFullName { get; set; }
        public string DrivingLicenseCategory { get; set; }
        public bool DriverStatusActivity { get; set; } = true;
        public int DriverId { get; set; }

        public Drivers(string driverFullName, string drivingLicenseCategory, bool driverStatusActivity, int driverId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(driverFullName);
            ArgumentException.ThrowIfNullOrWhiteSpace(drivingLicenseCategory);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(driverId);

            DriverFullName = driverFullName;
            DrivingLicenseCategory = drivingLicenseCategory;
            DriverStatusActivity = driverStatusActivity;
            DriverId = driverId;
        }
    }
}
