namespace _20_BookInventory_MVVM_Example_4
{
    public class BookViewModel
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
            set { book.Title = value; }
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
    }
}