using Corona_Tracing_App.Model;
using Corona_Tracing_App.PropertyChanged;

namespace Corona_Tracing_App.ViewModel
{
    public class PersonViewModel : ObservableObject
    {
        public PersonViewModel()
        {
            person = new Person();
        }

        private Person person;
        public Person Person
        {
            get => person;
            set => person = value;
        }

        public int Id
        {
            get => person.Id;
            set
            {
                person.Id = value;
                RaisePropertyChanged();
            }
        }

        public string IdTransmit
        {
            get => person.IdTransmit;
            set
            {
                person.IdTransmit = value;
                RaisePropertyChanged();
            }
        }

        public string IdReceived
        {
            get => person.IdReceived;
            set
            {
                person.IdReceived = value;
                RaisePropertyChanged();
            }
        }

        public bool Infected
        {
            get => person.Infected;
            set
            {
                person.Infected = value;
                RaisePropertyChanged();
            }
        }

        public bool Quarantine
        {
            get => person.Quarantine;
            set
            {
                person.Quarantine = value;
                RaisePropertyChanged();
            }
        }
    }
}
