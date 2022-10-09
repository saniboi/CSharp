using System;
using System.Collections.Generic;
using System.Linq;

namespace Übung_1_2_Mitarbeiter_abfragen_mit_Lambda_Ausdruck
{
    public class Program
    {
        public List<Employee> Employees { get; set; }

        public static void Main()
        {
            var program = new Program();
            program.TeilaufgabeB();
            program.OriginalListeAusgeben();
            program.TeilaufgabeA1_AllEmployeesWithSalaryAbove100000();
            program.TeilaufgabeA2_AllCitiesWithLengthLessThan6();
        }

        private void TeilaufgabeB()
        {
            Employees = new List<Employee>
            {
                // https://raw.githubusercontent.com/datacharmer/test_db/master/load_employees.dump
                new() { EmployeeNumber = 1, Firstname ="Bezalel", Lastname = "Simmel", Department = "Sales", Street = "Berufsschulstrasse 1", PostalCode = 8610, City = "Uster", Phonenumber = "044 943 64 22", Salary = 60000 },
                new() { EmployeeNumber = 2, Firstname ="Parto", Lastname = "Bamford", Department = "Sales", Street = "Berufsschulstrasse 1", PostalCode = 8710, City = "Egg", Phonenumber = "044 943 64 22", Salary = 70000 },
                new() { EmployeeNumber = 3, Firstname ="Chirstian", Lastname = "Koblick", Department = "Marketing", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Uster", Phonenumber = "044 943 64 23", Salary = 80000 },
                new() { EmployeeNumber = 4, Firstname ="Kyoichi", Lastname = "Zielinski", Department = "Marketing", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Winterthur", Phonenumber = "044 943 64 24", Salary = 90000 },
                new() { EmployeeNumber = 5, Firstname ="Maliniak", Lastname = "Kalloufi", Department = "Marketing", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Winterthur", Phonenumber = "044 943 64 25", Salary = 100000 },
                new() { EmployeeNumber = 6, Firstname ="Anneke", Lastname = "Peac", Department = "Engineering", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Winterthur", Phonenumber = "044 943 64 26", Salary = 110000 },
                new() { EmployeeNumber = 7, Firstname ="Preusig", Lastname = "Duangkaew", Department = "Engineering", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Winterthur", Phonenumber = "044 943 64 27", Salary = 120000 },
                new() { EmployeeNumber = 8, Firstname ="Tzvetan", Lastname = "Piveteau", Department = "Engineering", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Winterthur", Phonenumber = "044 943 64 28", Salary = 130000 },
                new() { EmployeeNumber = 9, Firstname ="Saniya", Lastname = "Mary", Department = "Engineering", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Winterthur", Phonenumber = "044 943 64 29", Salary = 140000 },
                new() { EmployeeNumber = 10, Firstname ="Sumant", Lastname = "Patricio", Department = "Management", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Winterthur", Phonenumber = "044 943 64 30", Salary = 150000 },
              };
        }

        private void OriginalListeAusgeben()
        {
            Console.WriteLine("\n--- Originalliste ---");
            foreach (Employee employee in Employees)
            {
                Console.WriteLine(employee);
            }

            TrennlinieZeichnen();
        }

        private void TrennlinieZeichnen()
        {
            Console.WriteLine("-----------------------------");
        }

        private void TeilaufgabeA1_AllEmployeesWithSalaryAbove100000()
        {
            Console.WriteLine("\n--- A.1) Alle Mitarbeiter, derer Salär > CHF 100‘000 ---");

            // Abfragesyntax
            //var employeesWithSalaryAbove100000 =
            //    from employee in Employees
            //    where employee.Salary > 100000
            //    select new {employee.Lastname, employee.Salary};

            // Erweiterungssyntax
            var employeesWithSalaryAbove100000 = Employees
                                                    .Where(employee => employee.Salary > 100000)
                                                    .Select(employee => new {employee.Lastname, employee.Salary});

            foreach (var employee in employeesWithSalaryAbove100000)
            {
                Console.WriteLine($"{employee.Lastname} verdient {employee.Salary:C}");
            }
            TrennlinieZeichnen();
        }

        private void TeilaufgabeA2_AllCitiesWithLengthLessThan6()
        {
            Console.WriteLine("\n--- A.2) Alle Wohnorte, derer Länge < 6 ---");

            // Abfragesyntax
            //var allCitiesWithLengthLessThan6 =
            //    from employee in Employees
            //    where employee.City.Length < 6
            //    select employee.City;

            // Erweiterungssyntax
            var allCitiesWithLengthLessThan6 = Employees
                                                .Where(employee => employee.City.Length < 6)
                                                .Select(employee => employee.City);

            foreach (string city in allCitiesWithLengthLessThan6)
            {
                Console.WriteLine(city);
            }
            TrennlinieZeichnen();
        }
    }
}