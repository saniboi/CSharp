using System.Collections.Generic;
using Corona_Tracing_App.Model;

namespace Corona_Tracing_App.Data
{
    public interface IPersonData
    {
        List<Person> GetPersons();
        void SetPersons(List<Person> persons);
    }
}
