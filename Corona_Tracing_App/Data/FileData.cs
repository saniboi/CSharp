using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Corona_Tracing_App.Model;

namespace Corona_Tracing_App.Data
{
    public class FileData : IPersonData
    {
        public List<Person> GetPersons()
        {
            var fileName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "../../ViewModel/json1.json");
            if (File.Exists(fileName))
            {
                File.Create(fileName);
            }
            var jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Person>>(jsonString)!;
        }

        public void SetPersons(List<Person> persons)
        {
            string fileName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "../../ViewModel/json1.json");
            string jsonString = JsonSerializer.Serialize(persons);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
