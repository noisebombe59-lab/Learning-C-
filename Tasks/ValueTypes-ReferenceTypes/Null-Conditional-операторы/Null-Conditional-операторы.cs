/*using System;
using System.Collections.Generic;
using System.Text;

namespace ValueTypes_ReferenceTypes.Null_Conditional_операторы
{
    public class Programm
    {
        static void Main(string[] args)
        {
            Company tes1 = new Company
            {
                Name = "Apple",
                Address = new Address { City = "New York", Stereet = "Main St" }
            };

            Console.WriteLine($"Сценарий 1 (OK) {GetCompanyCity(tes1)}");

            Company test2 = new Company
            {
                Name = "Apple",
                Address = null
            };

            Console.WriteLine($"Сценарий 2 (Adress == null) {GetCompanyCity(test2)}");

            Company? tes3 = null;

            Console.WriteLine($"Сценарий 3 (Company == null) {GetCompanyCity(tes3)}");
        }
        public static string? GetCompanyCity(Company? company)
        {
            return company?.Address?.City ?? "unknown";
        }
    }
    public class Company
    {
        public string? Name { get; set; }
        public Address? Address { get; set; }
    }

    public class Address
    {
        public string? City { get; set; }
        public string? Stereet { get; set; }
    }
}*/
