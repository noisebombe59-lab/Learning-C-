namespace access_modifiers_static_records
{
    public static class BankSettings
    {
        public static decimal MinBalance { get; set; } = 100;
        public static string BankName { get; private set; } = "MyBank";

        static BankSettings()
        {
            Console.WriteLine("BankSettings initialized once.");
        }
    }
}
