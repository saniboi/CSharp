using System;
using System.Data.Entity;
using System.Linq;
using NinjaDomain.Classes;
using NinjaDomain.DataModel;

namespace NinjaDomain.ConsoleApplication
{
    public class Program
    {
        public static void Main()
        {
            //InsertNinja();
            ReadNinja();
        }

        private static void InsertNinja()
        {
            var clan = new Clan
            {
                ClanName = "New clan"
            };

            var ninja = new Ninja
            {
                Name = "JulieSan",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1980, 1, 1),
                Clan = clan
            };

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.Add(ninja);
                context.SaveChanges();
            }
        }

        private static void ReadNinja()
        {
            using (var context = new NinjaContext())
            {
                var ninjas = context.Ninjas.Include(ninja => ninja.Clan);

                foreach (var ninja in ninjas)
                {
                    Console.WriteLine("Name: {0}", ninja.Name);
                    Console.WriteLine("DateOfBirth: {0}", ninja.DateOfBirth);
                    Console.WriteLine("Item: {0}", ninja.Clan.ClanName);
                }
            }
        }
    }
}