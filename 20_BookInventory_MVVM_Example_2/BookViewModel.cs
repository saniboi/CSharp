using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _20_BookInventory_MVVM_Example_4
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private Book book;

        public BookViewModel()
        {
            book = new Book { Author = "Unbekannt", Title = "Unbekannt", Price = 0 };
        }

        public Book Book
        {
            get { return book; }
            set { book = value; }
        }

        public string Title
        {
            get { return book.Title; }
            set
            {
                book.Title = value;
                RaisePropertyChanged(); // Als Test diese Zeile auskommentieren, Programm starten
                                        // und den "Titel setzen"-Knopf drücken. Wie bisher wird
                                        // sich der Titel nicht ändern, weil kein
                                        // "PropertyChanged"-Ereignis geworfen wird, wodurch WPF
                                        // über die Änderung informiert werden würde.
            }
        }

        public string Author
        {
            get { return book.Author; }
            set { book.Author = value; }
        }

        public decimal Price
        {
            get { return book.Price; }
            set { book.Price = value; }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        // Die von ReSharper generierte Methode wird "OnPropertyChanged" genannt;
        // wir benennen sie um zu "RaisePropertyChanged", weil "RaisePropertyChanged"
        // an der Aufrufstelle sinnvoller klingt
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}