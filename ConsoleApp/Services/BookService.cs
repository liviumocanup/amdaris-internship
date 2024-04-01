using ConsoleApp.Models;
using ConsoleApp.Repositories;

namespace ConsoleApp.Services
{
    public class BookService
    {
        private IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public Book? GetBookById(Guid id)
        {
            return _bookRepository.GetById(id);
        }

        public void AddBook(Book book)
        {
            _bookRepository.Add(book);
        }

        public void DeleteBook(Book book)
        {
            _bookRepository.Delete(book);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return _bookRepository.GetAll().Where(book => book.Author == author);
        }

        public IEnumerable<Book> GetBooksByTitle(string title)
        {
            return _bookRepository.GetAll().Where(book => book.Title == title);
        } 
    }
}