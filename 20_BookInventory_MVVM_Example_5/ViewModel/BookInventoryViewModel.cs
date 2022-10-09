using System.Collections.ObjectModel;
using System.Windows.Input;
using _20_BookInventory_MVVM_Example_5.DataAccessLayer;
using _20_BookInventory_MVVM_Example_5.Model;
using _20_MvvmFramework;

namespace _20_BookInventory_MVVM_Example_5.ViewModel
{
    public class BookInventoryViewModel
    {
        #region Fields

        private readonly BookRepository bookRepository = new BookRepository();

        #endregion

        #region Properties

        public ObservableCollection<Book> Books { get; set; }
        public ICommand UpdateTitles { get { return new RelayCommand(UpdateTitleExecute, UpdateTitleCanExecute); } }
        public ICommand AddBook { get { return new RelayCommand(AddBookExecute, AddBookCanExecute); } }

        #endregion

        #region Constructor

        public BookInventoryViewModel()
        {
            Books = new ObservableCollection<Book>();

            for (int i = 0; i < 3; i++)
            {
                Books.Add(new Book
                {
                    Title = bookRepository.GetRandomBookTitles,
                    Author = bookRepository.GetRandomAuthors,
                    Price = bookRepository.GetRandomPrices
                });
            }
        }

        #endregion

        #region Commands

        void UpdateTitleExecute()
        {
            if (Books == null)
                return;

            foreach (var book in Books)
            {
                book.Title = bookRepository.GetRandomBookTitles;
            }
        }

        bool UpdateTitleCanExecute()
        {
            return true;
        }

        void AddBookExecute()
        {
            if (Books == null)
                return;

            Books.Add(new Book
            {
                Title = bookRepository.GetRandomBookTitles,
                Author = bookRepository.GetRandomAuthors,
                Price = bookRepository.GetRandomPrices
            });
        }

        bool AddBookCanExecute()
        {
            return true;
        }

        #endregion
    }
}