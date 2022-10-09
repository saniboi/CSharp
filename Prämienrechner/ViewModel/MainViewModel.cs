using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Prämienrechner.DataBase;
using Prämienrechner.Model;

namespace Prämienrechner.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {

        #region Eigenschaften und Listen

        public Person person;

        private readonly ObservableCollection<Person> personList;
        private readonly ListCollectionView personView;
        public ObservableCollection<GesamteinnahmenMonatlich> gesamteinnahmenMonatliche { get; set; }
        public PrämienContext DbContext { get; set; }
        public ListCollectionView PersonView => personView;

        #endregion

        #region Commands

        public CommandBinding NewCommandBinding { get; }

        public CommandBinding SaveCommandBinding { get; }

        public CommandBinding DeleteCommandBinding { get; }

        #endregion

        #region Personen Laden

        private void LoadPersons()
        {

            if (!DbContext.Persons.Any())
            {
                personList.Add(new Person()
                {
                    Vorname = "Kerim",
                    Nachname = "San",
                    Franchise = "500",
                    VModell = "Hmo"
                });
                personList.Add(new Person()
                {
                    Vorname = "Michael",
                    Nachname = "Rüdisüli",
                    Franchise = "1000",
                    VModell = "Keine"
                });
                personList.Add(new Person()
                {
                    Vorname = "Murat",
                    Nachname = "Müller",
                    Franchise = "2500",
                    VModell = "Telmed"
                });

                DbContext.Persons.AddRange(personList);
            }

            DbContext.Persons.ToList().ForEach(v => { personList.Add(v); });

        }

        #endregion

        #region Konstruktor

        public MainViewModel()
        {
            person = new Person();
            // DB Initialisierung
            DbContext = new PrämienContext();
            DbContext.Database.Initialize(true);

            // Personenliste wird befüllt
            personList = new ObservableCollection<Person>();
            LoadPersons();


            // ListCollectionView wird initialisiert
            personView = new ListCollectionView(personList);

            // Gesamteinnahmen liste initialisieren
            gesamteinnahmenMonatliche = new ObservableCollection<GesamteinnahmenMonatlich>();

            // Commands Initialisierung
            NewCommandBinding = new CommandBinding(ApplicationCommands.New, NewExecuted, NewCanExecute);
            SaveCommandBinding = new CommandBinding(ApplicationCommands.Save, SaveExecuted, SaveCanExecute);
            DeleteCommandBinding = new CommandBinding(ApplicationCommands.Delete, DeleteExecuted, DeleteCanExecute);
        }

        #endregion

        #region Events

        private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            personList.Add(person);
            personView.MoveCurrentTo(person);
            //MonatspraemienGesamt();
        }

        private void NewCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            DbContext.Persons.AddOrUpdate(person);
        }

        private void SaveCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeleteExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Person persDelete = (Person) PersonView.CurrentItem;
            if (persDelete != null)
            {
                personList.Remove(persDelete);
                DbContext.Persons.Remove(persDelete);
            }

            personView.MoveCurrentToFirst();
        }

        private void DeleteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = PersonView.Count > 0;
        }

        #endregion

        //public void MonatspraemienGesamt()
        //    {
        //         Es wäre gut zu wissen wie man hier einen String summieren kann
        //         Ich hoffe du hast hier eine gute lösung dafür :)
        //        var monatsprämienSumme = personList.Sum((Int32).Parse(v => v.Monatspraemie));
        //}
    }

}
