using System.Collections.Generic;
using Corona_Tracing_App.Model;

namespace Corona_Tracing_App.Data
{
    public class InitData : IPersonData
    {
        
        public List<Person> GetPersons()
        {
            var persons = new List<Person>
            {
                new Person() 
                {
                    Id = 1,
                    IdTransmit = "ABC",
                    IdReceived = "D",
                    Infected = false,
                    Quarantine = false
                },
                new Person()
                {
                    Id = 2,
                    IdTransmit = "DEF",
                    IdReceived = "GA",
                    Infected = false,
                    Quarantine = false
                },
                new Person()
                {
                    Id = 3,
                    IdTransmit = "GHI",
                    IdReceived = "D",
                    Infected = false,
                    Quarantine = false

                },
                new Person()
                {
                    Id = 4,
                    IdTransmit = "JKL",
                    IdReceived = "",
                    Infected = false,
                    Quarantine = false
                }
            };

            return persons;
        }

        public void SetPersons(List<Person> persons)
        {
            throw new System.NotImplementedException();
        }
    }
}
