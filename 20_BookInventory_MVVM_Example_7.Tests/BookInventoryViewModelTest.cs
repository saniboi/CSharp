using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _20_BookInventory_MVVM_Example_7.ViewModel;

namespace _20_BookInventory_MVVM_Example_7.Tests
{
    [TestClass]
    public class BookInventoryViewModelTest
    {
        [TestMethod]
        public void UpdateTitlesCommand_Invoke_AllTitlesAreChanged()
        {
            // Arrange
            var books = new ObservableCollection<BookViewModel>
            {
                new BookViewModel { Title = string.Empty },
                new BookViewModel { Title = string.Empty }
            };
            var vm = new BookInventoryViewModel { Books = books };

            // Act
            vm.UpdateTitles.Execute(null);

            // Assert
            Assert.AreNotEqual(string.Empty, vm.Books.FirstOrDefault()?.Title);
            Assert.AreNotEqual(string.Empty, vm.Books.LastOrDefault()?.Title);
        }

        [TestMethod]
        public void UpdateAuthorCommand_Invoke_AllAuthorsAreChanged()
        {
            // Arrange
            var books = new ObservableCollection<BookViewModel>
            {
                new BookViewModel { Author = string.Empty },
                new BookViewModel { Author = string.Empty }
            };
            var vm = new BookInventoryViewModel { Books = books };

            // Act
            vm.UpdateAuthors.Execute(null);

            // Assert
            Assert.AreNotEqual(string.Empty, vm.Books.FirstOrDefault()?.Author);
            Assert.AreNotEqual(string.Empty, vm.Books.LastOrDefault()?.Author);
        }

        [TestMethod]
        public void UpdatePriceCommand_Invoke_AllPricesAreChanged()
        {
            // Arrange
            var books = new ObservableCollection<BookViewModel>
            {
                new BookViewModel { Price = 0m },
                new BookViewModel { Price = 0m }
            };
            var vm = new BookInventoryViewModel { Books = books };

            // Act
            vm.UpdatePrices.Execute(null);

            // Assert
            Assert.AreNotEqual(0m, vm.Books.FirstOrDefault()?.Price);
            Assert.AreNotEqual(0m, vm.Books.LastOrDefault()?.Price);
        }

        [TestMethod]
        public void AddBookCommand_Invoke_BooklistContainsAnAdditionalBook()
        {
            // Arrange
            var books = new ObservableCollection<BookViewModel>
            {
                new BookViewModel { Price = 0m }
            };
            var vm = new BookInventoryViewModel { Books = books };

            // Act
            vm.AddBook.Execute(null);

            // Assert
            Assert.AreEqual(2, vm.Books.Count);
        }
    }
}