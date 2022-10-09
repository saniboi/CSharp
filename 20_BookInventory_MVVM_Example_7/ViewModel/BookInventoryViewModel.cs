using System.Collections.ObjectModel;
using System.Windows.Input;
using _20_BookInventory_MVVM_Example_7.DataAccessLayer;
using _20_MvvmFramework;

namespace _20_BookInventory_MVVM_Example_7.ViewModel
{
    public class BookInventoryViewModel
    {
        #region Fields

        private readonly BookRepository bookRepository = new BookRepository();

        #endregion

        #region Properties

        public ObservableCollection<BookViewModel> Books { get; set; }
        public ICommand UpdateTitles { get { return new RelayCommand(UpdateTitleExecute, UpdateTitleCanExecute); } }
        public ICommand AddBook { get { return new RelayCommand(AddBookExecute, AddBookCanExecute); } }
        public ICommand UpdateAuthors { get { return new RelayCommand(UpdateAuthorsExecute, UpdateAuthorsCanExecute); } }
        public ICommand UpdatePrices { get { return new RelayCommand(UpdatePricesExecute, UpdatePricesCanExecute); } }

        #endregion

        #region Constructor

        public BookInventoryViewModel()
        {
            Books = new ObservableCollection<BookViewModel>();

            for (int i = 0; i < 3; i++)
            {
                Books.Add(new BookViewModel
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

            Books.Add(new BookViewModel
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

        void UpdateAuthorsExecute()
        {
            if (Books == null)
                return;

            foreach (var book in Books)
            {
                book.Author = bookRepository.GetRandomAuthors;
            }
        }

        bool UpdateAuthorsCanExecute()
        {
            return true;
        }

        void UpdatePricesExecute()
        {
            if (Books == null)
                return;

            foreach (var book in Books)
            {
                book.Price = bookRepository.GetRandomPrices;
            }
        }

        bool UpdatePricesCanExecute()
        {
            return true;
        }

        #endregion
    }
}