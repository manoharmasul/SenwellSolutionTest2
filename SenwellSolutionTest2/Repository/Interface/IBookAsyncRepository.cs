using SenwellSolutionTest2.Model;

namespace SenwellSolutionTest2.Repository.Interface
{
    public interface IBookAsyncRepository
    {
        Task<int> AddNewBook(Book book);
        Task<List<Book>> GetAllBooks();
    }
}
