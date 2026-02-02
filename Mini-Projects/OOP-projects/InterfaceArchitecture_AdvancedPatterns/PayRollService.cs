namespace InterfaceArchitecture_AdvancedPatterns
{
    public class PayRollService
    {
        public void ProcessSalary(IEmployee employee)
        {
            employee.CalculateSalary();
            employee.GetInfo();
        }
    }
}
