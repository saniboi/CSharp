using System;
using System.Collections.Generic;
using System.Linq;

namespace Übung_1_1_Mitarbeiterdaten_abfragen
{
    public class Program
    {
        public List<Employee> Employees { get; set; }

        public static void Main()
        {
            var program = new Program();
            program.TeilaufgabeB();
            program.GibOriginallisteAus();
            program.TeilaufgabeC1_OrderedByLastname_ReturnEntireEmployeeObject();
            program.TeilaufgabeC1_OrderedByLastname_ReturnLastnameOnly();
            program.TeilaufgabeC2_GroupedByDepartment();
            program.TeilaufgabeC3_WhereEmployeeEarnsMoreThan100000();
            program.TeilaufgabeC4_AllCitiesThatStartWithPostalCode8();
        }

        private void GibOriginallisteAus()
        {
            Console.WriteLine("\n--- Originalliste ---");
            foreach (Employee employee in Employees)
            {
                Console.WriteLine(employee);
            }

            ZeichneTrennlinie();
        }

        private void ZeichneTrennlinie()
        {
            Console.WriteLine("-----------------------------");
        }

        private void TeilaufgabeB()
        {
            Employees = new List<Employee>
            {
                // https://raw.githubusercontent.com/datacharmer/test_db/master/load_employees.dump
                new() { EmployeeNumber = 1, Firstname ="Bezalel", Lastname = "Simmel", Department = "Sales", Street = "Berufsschulstrasse 1", PostalCode = 8610, City = "Uster", Phonenumber = "044 943 64 22", Salary = 60000 },
                new() { EmployeeNumber = 2, Firstname ="Parto", Lastname = "Bamford", Department = "Sales", Street = "Berufsschulstrasse 1", PostalCode = 8710, City = "Egg", Phonenumber = "044 943 64 22", Salary = 70000 },
                new() { EmployeeNumber = 3, Firstname ="Chirstian", Lastname = "Koblick", Department = "Marketing", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Uster", Phonenumber = "044 943 64 23", Salary = 80000 },
                new() { EmployeeNumber = 4, Firstname ="Kyoichi", Lastname = "Zielinski", Department = "Marketing", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Uster", Phonenumber = "044 943 64 24", Salary = 90000 },
                new() { EmployeeNumber = 5, Firstname ="Maliniak", Lastname = "Kalloufi", Department = "Marketing", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Uster", Phonenumber = "044 943 64 25", Salary = 100000 },
                new() { EmployeeNumber = 6, Firstname ="Anneke", Lastname = "Peac", Department = "Engineering", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Uster", Phonenumber = "044 943 64 26", Salary = 110000 },
                new() { EmployeeNumber = 7, Firstname ="Preusig", Lastname = "Duangkaew", Department = "Engineering", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Uster", Phonenumber = "044 943 64 27", Salary = 120000 },
                new() { EmployeeNumber = 8, Firstname ="Tzvetan", Lastname = "Piveteau", Department = "Engineering", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Uster", Phonenumber = "044 943 64 28", Salary = 130000 },
                new() { EmployeeNumber = 9, Firstname ="Saniya", Lastname = "Mary", Department = "Engineering", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Uster", Phonenumber = "044 943 64 29", Salary = 140000 },
                new() { EmployeeNumber = 10, Firstname ="Sumant", Lastname = "Patricio", Department = "Management", Street = "Berufsschulstrasse 1", PostalCode = 9000, City = "Uster", Phonenumber = "044 943 64 30", Salary = 150000 }
            };
        }

        private void TeilaufgabeC1_OrderedByLastname_ReturnEntireEmployeeObject()
        {
            Console.WriteLine("\n--- C.1) Alle Mitarbeiter, sortiert nach Nachname ---");

            // Abfragesyntax
            //IOrderedEnumerable<Employee> employeesSortedByLastname =
            //    from employee in Employees
            //    orderby employee.Lastname
            //    select employee;

            // Erweiterungsmethodensyntax
            IOrderedEnumerable<Employee> employeesSortedByLastname = Employees.OrderBy(employee => employee.Lastname);

            // Beachte 1
            // OrderBy funktioniert hier einfach so, weil .NET weiss, wie man strings sortiert
            // Wollte nach eigenen Kriterien sortieren, müsste man wie in CS1 gelernt das IComparable-Interface implementieren
            // Test
            //      Employees.OrderBy(employee => employee)
            // verwenden und Exception anschauen:
            //      Unhandled Exception: System.ArgumentException: At least one object must implement IComparable.
            //
            // Beachte 2
            // Der Rückgabewert ist IOrderedEnumerable<T>, nicht IEnumerable<T>
            //
            // Beachte 3
            // Optional noch Employees.OrderByDescending(employee => employee.Lastname) ausprobieren und Ausgabe betrachten.

            foreach (Employee employee in employeesSortedByLastname)
            {
                Console.WriteLine(employee);
            }
            ZeichneTrennlinie();
        }

        private void TeilaufgabeC1_OrderedByLastname_ReturnLastnameOnly()
        {
            Console.WriteLine("\n--- C.1) Alle Mitarbeiter, sortiert nach Nachname, aber nur die Nachnamen ausgeben ---");

            // Abfragesyntax
            //var employeesSortedByLastname =
            //    from employee in Employees
            //    orderby employee.Lastname
            //    select employee.Lastname;

            // Erweiterungsmethodensyntax
            IEnumerable<string> employeesSortedByLastname = Employees
                                                                .OrderBy(employee => employee.Lastname)
                                                                .Select(employee => employee.Lastname);

            foreach (string lastname in employeesSortedByLastname)
            {
                Console.WriteLine(lastname);
            }

            ZeichneTrennlinie();
        }

        private void TeilaufgabeC2_GroupedByDepartment()
        {
            Console.WriteLine("\n--- C.2) Alle Mitarbeiter, gruppiert nach Abteilung ---");

            // Abfragesyntax
            //IEnumerable<IGrouping<string, Employee>> employeesGroupedByDepartment =
            //    from employee in Employees
            //    group employee by employee.Department; // Endet mit group-Klausel; kein select danach

            // Erweiterungsmethodensyntax
            IEnumerable<IGrouping<string, Employee>> employeesGroupedByDepartment = Employees.GroupBy(employee => employee.Department);


            // Direkte Ausgabe mit einer foreach-Schlaufe
            Console.WriteLine("\n-- 1x foreach: Direkte Ausgabe mit einer foreach-Schlaufe --");
            foreach (IGrouping<string, Employee> group in employeesGroupedByDepartment)
            {
                string gruppierungsschlüssel = group.Key;
                int anzahlElementeInDerGruppe = group.Count();
                var listeAllerVornamen = group.Select(employee => employee.Firstname);
                string alleVornamenAlsEinStringZusammengefasst = string.Join(",", listeAllerVornamen);
                Console.WriteLine($"IGrouping<string, Employee>: Key(string)={gruppierungsschlüssel}(Count={anzahlElementeInDerGruppe})\t group(IEnumerable<Employee>)={alleVornamenAlsEinStringZusammengefasst}");
            }

            // Gruppierte Ausgabe mit zwei foreach-Schlaufen
            Console.WriteLine("\n-- 2x foreach: Gruppierte Ausgabe mit zwei foreach-Schlaufen --");
            foreach (var group in employeesGroupedByDepartment)
            {
                Console.WriteLine($"\n--- {group.Key} ---");
                foreach (Employee employee in group)
                {
                    Console.WriteLine(employee);
                }
            }
            ZeichneTrennlinie();
        }

        private void TeilaufgabeC3_WhereEmployeeEarnsMoreThan100000()
        {
            Console.WriteLine("\n--- C.3) Alle Mitarbeiter, deren Salär > CHF 100'000 ist ---");

            // Abfragesyntax
            //IEnumerable<Employee> employeesWhoEarnMoreThan100000 =
            //    from employee in Employees
            //    where employee.Salary > 100000
            //    select employee;

            // Erweiterungsmethodensyntax
            IEnumerable<Employee> employeesWhoEarnMoreThan100000 = Employees.Where(employee => employee.Salary > 100000);

            foreach (Employee employee in employeesWhoEarnMoreThan100000)
            {
                Console.WriteLine(employee);
            }
            ZeichneTrennlinie();
        }

        private void TeilaufgabeC4_AllCitiesThatStartWithPostalCode8()
        {
            Console.WriteLine("\n--- C.4) Alle Wohnorte mit PLZ = 8xxx ---");

            // Abfragesyntax
            //var citiesThatStartWithPostalCode8 =
            //    from employee in Employees
            //    where employee.PostalCode.ToString().StartsWith("8")
            //    where employee.PostalCode.HasNumberOfDigits() == 4
            //    select new { Name = employee.City, employee.PostalCode };

            // Erweiterungsmethodensyntax
            var citiesThatStartWithPostalCode8 = Employees
                                                    .Where(employee => employee.PostalCode.ToString().StartsWith("8"))
                                                    .Where(employee => employee.PostalCode.HasNumberOfDigits() == 4)
                                                    .Select(employee => new { Name = employee.City, employee.PostalCode });

            foreach (var city in citiesThatStartWithPostalCode8)
            {
                Console.WriteLine($"{city.PostalCode} {city.Name}");
            }
            ZeichneTrennlinie();
        }
    }
}