using System.Data.Entity;
using Prämienrechner.Model;

namespace Prämienrechner.DataBase
{
    public class PrämienContext : DbContext
    {
        public PrämienContext() : base("Pruefung1Kerim")
        {
            // Die Datenbank Initializer kann auch hier im Konstruktor eingefügt werden
            //Database.SetInitializer(new DropCreateDatabaseAlways<PrämienContext>());
        }

        public DbSet<Person> Persons { get; set; }
    }
}
