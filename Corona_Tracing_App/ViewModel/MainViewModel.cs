using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Input;
using Corona_Tracing_App.Data;
using Corona_Tracing_App.Model;
using Corona_Tracing_App.PropertyChanged;

namespace Corona_Tracing_App.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        #region Eigenschaften

        public IPersonData Data;
        public PersonViewModel Person1 { get; set; }
        public PersonViewModel Person2 { get; set; }
        public PersonViewModel Person3 { get; set; }
        public PersonViewModel Person4 { get; set; }
        private bool onceSimulated;

        private string quarantineList;
        public string QuarantineList
        {
            get => quarantineList;
            set
            {
                quarantineList = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<PersonViewModel> Persons => new() { Person1, Person2, Person3, Person4 };

        public PersonViewModel PersonTest { get; set; }

        #endregion
        
        #region Konstruktor
        public MainViewModel(IPersonData data)
        {
            //InitData initData = new();
            //var persons = initData.GetPersons();
            Data = data;
            List<Person> persons = data.GetPersons();

            Person1 = new PersonViewModel { Person = persons[0] };
            Person2 = new PersonViewModel { Person = persons[1] };
            Person3 = new PersonViewModel { Person = persons[2] };
            Person4 = new PersonViewModel { Person = persons[3] };

            // Erstellt eine Liste aus PersonViewModel und wird in Person Konvertiert und als Liste ausgegeben ;) LINQMAGIC
            // var Test = Persons.Select(p => p.Person).ToList();
        }

        #endregion

        #region Commands

        public ICommand Reset => new RelayCommand(ResetExecute, ResetCanExecute);

        private void ResetExecute()
        {
            ResetFunction();
            SetBack();
            QuarantineList = "";
            onceSimulated = false;
        }

        private bool ResetCanExecute()
        {
            return true;
        }

        public ICommand SimulateContact => new RelayCommand(SimulateContactExecute, SimulateContactCanExecute);

        private void SimulateContactExecute()
        {
            Simulation();
        }

        private bool SimulateContactCanExecute()
        {
            return true;
        }

        public ICommand EvaluateQuaratine => new RelayCommand(EvaluateQuarantineExecute, EvaluateQuarantineCanExecute);
        private void EvaluateQuarantineExecute()
        {
            QuarantineList = GetQuarantineList();
        }
        private bool EvaluateQuarantineCanExecute()
        {
            return true;
        }

        #endregion

        #region Funktionen

        public string GetQuarantineList()
        {
            ResetFunction();

            for (int i = 0; i < Persons.Count; i++)
            {
                if (Persons[i].Infected != true) continue;

                for (int j = 0; j < Persons.Count; j++)
                {

                    if (i == j || Persons[j].Infected) continue;

                    foreach (var unused in Persons[i].IdTransmit.Where(id => Persons[j].IdReceived.Contains(id)))
                    {
                        Persons[j].Quarantine = true;
                    }
                }
                Persons[i].Quarantine = true;
            }

            var message = "";
            foreach (var person in Persons)
            {
                if (person.Quarantine)
                    message = message + "Person " + person.Id + "\n";
            }

            return message;
        }

        public void ResetFunction()
        {
            foreach (var p in Persons)
            {
                p.Quarantine = false;
            }

            onceSimulated = false;
        }

        public void Simulation()
        {
            if (!onceSimulated)
            {
                Person3.IdTransmit += "X";
                Person3.IdReceived += "Y";

                Person4.IdTransmit += "Y";
                Person4.IdReceived += "X";
                onceSimulated = true;
            }
        }

        public void SetBack()
        {
            Person1.IdTransmit = "ABC";
            Person1.IdReceived = "D";
            Person1.Infected = false;

            Person2.IdTransmit = "DEF";
            Person2.IdReceived = "AG";
            Person2.Infected = false;

            Person3.IdTransmit = "GHI";
            Person3.IdReceived = "D";
            Person3.Infected = false;

            Person4.IdTransmit = "JKL";
            Person4.IdReceived = "";
            Person3.Infected = false;
        }

        #endregion
    }
}
