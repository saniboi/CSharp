using System.Collections.Generic;

namespace DataGridViewExample
{
    public static class PersonRepository
    {
        public static List<Person> GetPeopleList()
        {
            List<Person> peopleList = new List<Person>
            {
                new Person {Id = 1, FirstName = "Urs", LastName = "Hug", City = "Au"},
                new Person {Id = 2, FirstName = "Beno", LastName = "Haug", City = "Zürich"},
                new Person {Id = 3, FirstName = "John", LastName = "Leder", City = "Uster"},
                new Person {Id = 4, FirstName = "Max", LastName = "Meier", City = "Rüti"},
            };

            return peopleList;
        }
    }
}
