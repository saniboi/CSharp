using System.Windows.Input;
using _20_BookInventory_MVVM_Example_7.Model;
using _20_MvvmFramework;

namespace _20_BookInventory_MVVM_Example_7.ViewModel
{
    public class BookViewModel : ObservableObject
    {
        public ICommand UpdateTitle
        {
            get { return new RelayCommand(UpdateTitleExecute); }
        }

        private Book book;
        private int count;

        public BookViewModel()
        {
            book = new Book { Author = "Unbekannt", Title = "Unbekannt", Price = 0 };
        }

        public Book Book
        {
            get { return book; }
            set { book = value;}
        }

        public string Title
        {
            get { return book.Title; }
            set
            {
                book.Title = value;
                RaisePropertyChanged(); // Als Test diese Zeile auskommentieren, Programm starten
                                        // und den "Titel setzen" knopf drücken. Wie bisher wird
                                        // sich der Titel nicht ändern, weil kein
                                        // "PropertyChanged" -Ereignis geworfen  wird, wodurch WPF
                                        // über die Änderung informiert würde.
            }
        }

        public string Author
        {
            get { return book.Author; }
            set
            {
                book.Author = value;
                RaisePropertyChanged();
            }
        }

        public decimal Price
        {
            get { return book.Price; }
            set
            {
                book.Price = value;
                RaisePropertyChanged();
            }
        }

        #region Commands

        private void UpdateTitleExecute()
        {
            count++;
            Title = $"Mit Commands {count}";
        }

        #endregion
    }
}