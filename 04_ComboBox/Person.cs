using System.ComponentModel;

namespace _04_ComboBox
{
    #region Variante 2
    // Ohne INotifyPropertyChanged
    //public class Person
    //{
    //    public int Id { get; set; }
    //    public string Firstname { get; set; }
    //    public string Lastname { get; set; }
    //}
    #endregion


    #region Variante 1
    // Mit INotifyPropertyChanged
    public class Person : INotifyPropertyChanged // https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/how-to-implement-property-change-notification
    {
        private string firstname;
        private string lastname;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        public string Firstname
        {
            get { return firstname; }
            set
            {
                firstname = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Firstname");
            }
        }

        public string Lastname
        {
            get { return lastname; }
            set
            {
                lastname = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Lastname");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            // Schreibeweise 1
            // Event auslösen und alle Abonennten informieren
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

            // Schreibeweise 2
            // Alte Schreibweise, bevor es den Null-conditional-Operator mit C# 6 (2015) gab
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(name));
            //}

            // Schreibeweise 3
            // Der PropertyChanged-Aufruf ruft alle Abonennten auf, sprich die Event-handler
            // Um den Code sprechender zu machen, könnte man das Beispiel hier wie folgt mit "listOfEventHandlers" umbennen, um es noch klarer auszudrücken
            //PropertyChangedEventHandler listOfEventHandlers = PropertyChanged; // "listOfEventHandlers" wird hier bloss eingeführt, um einen sprechenden Namen zu haben in diesem Beispiel.
            //if (listOfEventHandlers != null)
            //{
            //    listOfEventHandlers(this, new PropertyChangedEventArgs(name));
            //}
        }
    }
    #endregion
}