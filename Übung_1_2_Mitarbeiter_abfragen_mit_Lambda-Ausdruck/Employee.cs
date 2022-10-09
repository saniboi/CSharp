namespace Übung_1_2_Mitarbeiter_abfragen_mit_Lambda_Ausdruck
{
    public class Employee
    {
        public int EmployeeNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Department { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Phonenumber { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{EmployeeNumber}, {Firstname}, {Lastname}, {Department}, {Street}, {PostalCode}, {City}, {Phonenumber}, {Salary}";
        }
    }
}